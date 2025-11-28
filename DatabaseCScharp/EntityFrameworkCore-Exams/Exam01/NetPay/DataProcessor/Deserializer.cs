using NetPay.Data;
using NetPay.Data.Models;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ImportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace NetPay.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedHousehold = "Successfully imported household. Contact person: {0}";
        private const string SuccessfullyImportedExpense = "Successfully imported expense. {0}, Amount: {1}";

        public static string ImportHouseholds(NetPayContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Household> householdsToImport = new List<Household>();

            ImportHouseholdDto[] importHouseholdDtoArr = XmlSerializerWrapper
                .Deserialize<ImportHouseholdDto[]>(xmlString, "Households")!;

            if (importHouseholdDtoArr != null)
            {
                foreach (var importHouseholdDto in importHouseholdDtoArr)
                {
                    if (!IsValid(importHouseholdDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isHouseholdAlreadyImported = householdsToImport
                        .Any(h =>
                                h.PhoneNumber == importHouseholdDto.PhoneNumber ||
                                h.ContactPerson == importHouseholdDto.ContactPerson ||
                                (h.Email != null && h.Email == importHouseholdDto.Email));

                    bool isHouseholdExists = context
                        .Households
                        .Any(h =>
                            h.PhoneNumber == importHouseholdDto.PhoneNumber ||
                            h.ContactPerson == importHouseholdDto.ContactPerson ||
                            (h.Email != null && h.Email == importHouseholdDto.Email));


                    if (isHouseholdAlreadyImported || isHouseholdExists)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Household household = new Household()
                    {
                        PhoneNumber = importHouseholdDto.PhoneNumber,
                        ContactPerson = importHouseholdDto.ContactPerson,
                        Email = importHouseholdDto.Email
                    };


                    householdsToImport.Add(household);
                    sb.AppendLine(String.Format(SuccessfullyImportedHousehold, household.ContactPerson));
                }

                context.Households.AddRange(householdsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportExpenses(NetPayContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Expense> expensesToImport = new List<Expense>();

            ImportExpenseDto[] importExpenseDtoArr = JsonConvert
                .DeserializeObject<ImportExpenseDto[]>(jsonString)!;

            if (importExpenseDtoArr != null)
            {
                foreach (ImportExpenseDto importExpenseDto in importExpenseDtoArr)
                {
                    if (!IsValid(importExpenseDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isHouseholdExists = context
                        .Households
                        .Any(h => h.Id == importExpenseDto.HouseholdId!.Value);

                    bool isServiceExists = context
                        .Services
                        .Any(s => s.Id == importExpenseDto.ServiceId!.Value);


                    if (!isHouseholdExists || !isServiceExists)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDueDateValid = DateTime
                        .TryParseExact(importExpenseDto.DueDate, "yyyy-MM-dd", CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out DateTime dueDateVal);

                    bool isPaymentStatusValid = Enum
                        .TryParse<PaymentStatus>(importExpenseDto.PaymentStatus, out PaymentStatus paymentStatusVal);

                    if (!isDueDateValid || !isPaymentStatusValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Expense expense = new Expense()
                    {
                        ExpenseName = importExpenseDto.ExpenseName,
                        Amount = importExpenseDto.Amount!.Value,
                        DueDate = dueDateVal,
                        PaymentStatus = paymentStatusVal,
                        HouseholdId = importExpenseDto.HouseholdId!.Value,
                        ServiceId = importExpenseDto.ServiceId!.Value
                    };

                    expensesToImport.Add(expense);
                    sb.AppendLine(String
                        .Format(SuccessfullyImportedExpense, expense.ExpenseName, expense.Amount.ToString("F2")));
                }
                context.Expenses.AddRange(expensesToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (var result in validationResults)
            {
                string currvValidationMessage = result.ErrorMessage;
            }

            return isValid;
        }
    }
}
