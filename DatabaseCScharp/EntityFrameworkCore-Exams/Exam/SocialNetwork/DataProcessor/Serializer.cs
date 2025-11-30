using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using SocialNetwork.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Newtonsoft.Json;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {

            var usersWithFriendShipsCountAndTheirPosts = dbContext
                .Users
                .AsNoTracking()
                .OrderBy(u => u.Username)
                .Select(u => new ExportUserDto()
                {
                    Username = u.Username,
                    Friendship = (u.FriendshipTwo.Count() + u.FriendshipOne.Count()).ToString(),
                    Posts = u.Posts.Select(p => new ExportPostDto()
                    {
                        Content = p.Content,
                        CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
                    })
                    .ToArray()
                })
                .ToArray();

            return XmlSerializerWrapper.Serialize<ExportUserDto[]>(usersWithFriendShipsCountAndTheirPosts, "Users");
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversationsWithMessagesChronologically = dbContext
                .Conversations
                .AsNoTracking()
                .OrderBy(c=> c.StartedAt)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    Messages = c.Messages
                                .OrderBy(m=>m.SentAt)
                                .Select(m => new 
                    {
                        m.Content,
                        SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                        Status = (int)m.Status,
                        SenderUsername = m.Sender.Username
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert
                .SerializeObject(conversationsWithMessagesChronologically, Formatting.Indented);
        }
    }
}
