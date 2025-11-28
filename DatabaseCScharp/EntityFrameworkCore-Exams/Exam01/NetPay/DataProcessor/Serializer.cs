using Microsoft.EntityFrameworkCore;
using NetPay.Data;
using NetPay.Data.Models.Enums;
using NetPay.DataProcessor.ExportDtos;
using NetPay.Utilities;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            var householdsWhichHaveExpensesToPay = context
                .Households
                .AsNoTracking()
                .Include(h => h.Expenses)
                .ThenInclude(e => e.Service)
                .Where(h => h.Expenses.Any(e => e.PaymentStatus != (PaymentStatus)1))
                .OrderBy(h => h.ContactPerson)
                .ToArray()
                .Select(h => new ExportHouseholdWithExpensesToPayDto()
                {
                    ContactPerson = h.ContactPerson,
                    Email = h.Email,
                    PhoneNumber = h.PhoneNumber,
                    Expenses = h.Expenses
                        .Where(e => e.PaymentStatus != (PaymentStatus)1)                      
                        .Select(e => new ExportExpenseToPayDto()
                        {
                            ExpenseName = e.ExpenseName,
                            Amount = e.Amount.ToString("F2"),
                            DueDate = e.DueDate.ToString("yyyy-MM-dd"),
                            ServiceName = e.Service.ServiceName
                        })  
                        .OrderBy(e => e.DueDate)
                        .ThenBy(e => e.Amount)
                        .ToArray()


                })
                .ToArray();

            return XmlSerializerWrapper
                .Serialize<ExportHouseholdWithExpensesToPayDto[]>(householdsWhichHaveExpensesToPay, "Households");


        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var servicesWithSuppliers = context
                .Services
                .AsNoTracking()
                .Include(s => s.SuppliersServices)
                .ThenInclude(ss => ss.Supplier)
                .OrderBy(s => s.ServiceName)
                .Select(s => new
                {
                    s.ServiceName,
                    Suppliers = s
                    .SuppliersServices
                    .Select(ss => new 
                    {
                        SupplierName = ss.Supplier.SupplierName 
                    })
                    .OrderBy(sn => sn.SupplierName)
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(servicesWithSuppliers, Formatting.Indented);

        }
    }
}
