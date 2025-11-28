using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NetPay.Common.EntityValidation.Expense;

namespace NetPay.DataProcessor.ImportDtos
{
    public class ImportExpenseDto
    {
        [JsonProperty("ExpenseName")]
        [Required]
        [MinLength(ExpenseNameMinLength)]
        [MaxLength(ExpenseNameMaxLength)]
        public string ExpenseName { get; set; } = null!;

        [JsonProperty("Amount")]
        [Required]
        [Range(typeof(decimal), AmountMin, AmountMax)]
        public decimal? Amount { get; set; }

        [JsonProperty("DueDate")]
        [Required]
        public string DueDate { get; set; } = null!;

        [JsonProperty("PaymentStatus")]
        [Required]
        public string PaymentStatus { get; set; } = null!;

        [JsonProperty("HouseholdId")]
        [Required]
        public int? HouseholdId { get; set; }

        [JsonProperty("ServiceId")]
        [Required]
        public int? ServiceId { get; set; }
    }
}
