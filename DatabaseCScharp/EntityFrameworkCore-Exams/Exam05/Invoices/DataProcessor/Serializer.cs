using Invoices.DataProcessor.ExportDto;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models.Enums;
    using Invoices.Utilities;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {

            //var clientsWithTheirInvoices = context
            //    .Clients
            //    .AsNoTracking()
            //    .Where(c => c.Invoices.Any(i => i.IssueDate > date))
            //    .Select(c => new ExportClientDto()
            //    {
            //        ClientName = c.Name,
            //        VatNumber = c.NumberVat,
            //        InvoicesCount = c.Invoices.Count.ToString(),
            //        Invoices = c.Invoices.Select(i => new ExportInvoiceDto()
            //        {
            //            InvoiceNumber = i.Number.ToString(),
            //            InvoiceAmount = i.Amount.ToString("F2"),
            //            DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
            //            Currency = i.CurrencyType.ToString(),

            //        })
            //        .ToArray()
            //    });

            var clientsWithTheirInvoices = context
                .Clients
                .AsNoTracking()
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new
                {
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c
                        .Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new
                        {
                            InvoiceNumber = i.Number,
                            InvoiceAmount = i.Amount,
                            DueDate = i.DueDate,
                            Currency = i.CurrencyType,

                        })
                        .ToArray()
                })
                .OrderByDescending(c => c.Invoices.Length)
                .ThenBy(c => c.ClientName)
                .ToArray();

            var clientsToExport = clientsWithTheirInvoices
                .Select(c => new ExportClientDto()
                {
                    ClientName = c.ClientName,
                    VatNumber = c.VatNumber,
                    InvoicesCount = c.Invoices.Length.ToString(),
                    Invoices = c.Invoices.Select(i => new ExportInvoiceDto()
                    {
                        InvoiceNumber = i.InvoiceNumber.ToString(),
                        InvoiceAmount = i.InvoiceAmount.ToString("G29"),
                        DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        Currency = i.Currency.ToString(),

                    })
                            .ToArray()
                })
                .ToArray();

            return XmlSerializerWrapper.Serialize<ExportClientDto[]>(clientsToExport, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            var productsWithMostClients = context
                .Products
                .AsNoTracking()
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p
                        .ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new
                        {
                            pc.Client.Name,
                            pc.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p=> p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert
                .SerializeObject(productsWithMostClients, Formatting.Indented);
        }
    }
}