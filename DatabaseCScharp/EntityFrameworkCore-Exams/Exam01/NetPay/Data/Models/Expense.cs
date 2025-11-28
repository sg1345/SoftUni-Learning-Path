using NetPay.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static NetPay.Common.EntityValidation.Expense;

namespace NetPay.Data.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ExpenseNameMaxLength)]
        public string ExpenseName { get; set; } = null!;

        [Required]
        [Column(TypeName = AmountTypeName)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [ForeignKey(nameof(Household))]
        public int HouseholdId { get; set; }
        public Household Household { get; set; } = null!;

        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        public Service Service { get; set; } = null!;
    }
}
