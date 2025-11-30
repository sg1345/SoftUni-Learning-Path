using SocialNetwork.Data;
using SocialNetwork.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using SocialNetwork.Data.Models;
using SocialNetwork.DataProcessor.ImportDTOs;
using static SocialNetwork.Utilities.Utility.UtilityHelper;
using SocialNetwork.Data.Enum;
using Newtonsoft.Json;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Message> messagesToImport = new List<Message>();

            ImportMessageDto[] importMessageDtoArr = XmlSerializerWrapper
                .Deserialize<ImportMessageDto[]>(xmlString, "Messages")!;

            if (importMessageDtoArr != null)
            {
                foreach (ImportMessageDto messageDto in importMessageDtoArr)
                {
                    if (!IsValid(messageDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isSendAtValid =
                        DateTime.TryParseExact(
                            messageDto.SentAt,
                            "yyyy-MM-ddTHH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime sendAt);

                    bool isStatusEnum = TryParseEnum<MessageStatus>(messageDto.Status, out MessageStatus status);

                    bool isConversationIdInt = int.TryParse(messageDto.ConversationId, out int conversationIdInt);
                    bool isSenderIdInt = int.TryParse(messageDto.SenderId, out int senderIdInt);

                    bool isConversationIdValid = dbContext
                        .Conversations
                        .Any(c => c.Id == conversationIdInt);

                    bool isSenderIdValid = dbContext
                        .Users
                        .Any(u => u.Id == senderIdInt);

                    if (!isSendAtValid ||
                        !isStatusEnum ||
                        !isConversationIdInt ||
                        !isSenderIdInt ||
                        !isConversationIdValid ||
                        !isSenderIdValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isMessageExists = dbContext
                        .Messages
                        .Any(m => m.ConversationId == conversationIdInt &&
                                        m.Content == messageDto.Content &&
                                        m.SentAt == sendAt &&
                                        m.SenderId == senderIdInt);

                    bool isMessageAlreadyImported = messagesToImport
                        .Any(m => m.ConversationId == conversationIdInt &&
                                         m.Content == messageDto.Content &&
                                         m.SentAt == sendAt &&
                                         m.SenderId == senderIdInt);

                    if (isMessageAlreadyImported || isMessageExists)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Message message = new Message()
                    {
                        Content = messageDto.Content,
                        SentAt = sendAt,
                        SenderId = senderIdInt,
                        ConversationId = conversationIdInt,
                        Status = status
                    };

                    messagesToImport.Add(message);

                    sb.AppendLine(String.Format(SuccessfullyImportedMessageEntity, message.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"), message.Status));

                }

                dbContext.AddRange(messagesToImport);
                dbContext.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder sb = new StringBuilder();


            ICollection<Post> postsToImport = new List<Post>();

            ImportPostDto[] importPatientDtoArr = JsonConvert
                .DeserializeObject<ImportPostDto[]>(jsonString)!;

            if (importPatientDtoArr != null)
            {
                foreach (ImportPostDto postDto in importPatientDtoArr)
                {
                    if (!IsValid(postDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCreatorIdValid = dbContext.Users.Any(u => u.Id == postDto.CreatorId);
                    bool isCreatedAtValid = TryParseExactDate(
                            postDto.CreatedAt,
                            "yyyy-MM-ddTHH:mm:ss",
                            out DateTime createdAt);

                    if (!isCreatedAtValid || !isCreatorIdValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isPostDublicated = dbContext
                        .Posts
                        .Any(p => p.CreatorId == postDto.CreatorId &&
                                      p.CreatedAt == createdAt &&
                                      p.Content == postDto.Content);

                    bool isPostAlreadyImported = postsToImport.Any(p => p.CreatorId == postDto.CreatorId &&
                                                                        p.CreatedAt == createdAt &&
                                                                        p.Content == postDto.Content);

                    if(isPostAlreadyImported || isPostDublicated)
                    {
                        sb.AppendLine(DuplicatedDataMessage);
                        continue;
                    }

                    Post post = new Post()
                    {
                        Content = postDto.Content,
                        CreatedAt = createdAt,
                        CreatorId = postDto.CreatorId,
                    };

                    string username = dbContext.Users.FirstOrDefault(u => u.Id == post.CreatorId)!.Username;

                    postsToImport.Add(post);

                    sb.AppendLine(String
                        .Format(SuccessfullyImportedPostEntity,
                                username,
                                post.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")));
                }

                dbContext.AddRange(postsToImport);
                dbContext.SaveChanges();
            }


            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
