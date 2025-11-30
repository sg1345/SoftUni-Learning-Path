namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    using Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using static Utilities.Utility.UtilityHelper;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Client> clientsToImport = new List<Client>();

            ImportClientDto[] importClientDtoArr = XmlSerializerWrapper
                .Deserialize<ImportClientDto[]>(xmlString, "Clients")!;

            if (importClientDtoArr != null)
            {
                foreach (ImportClientDto clientDto in importClientDtoArr)
                {
                    ICollection<Address> addressesToImport = new List<Address>();

                    if (!IsValid(clientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (ImportAddressDto addressDto in clientDto.Addresses)
                    {
                        if (!IsValid(addressDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isStreetNumberValid = int.TryParse(addressDto.StreetNumber, out int streetNumber);

                        if (!isStreetNumberValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Address newAddress = new Address()
                        {
                            StreetName = addressDto.StreetName,
                            StreetNumber = streetNumber,
                            PostCode = addressDto.PostCode,
                            City = addressDto.City,
                            Country = addressDto.Country,
                        };

                        addressesToImport.Add(newAddress);


                    }

                    Client newClient = new Client()
                    {
                        Name = clientDto.Name,
                        NumberVat = clientDto.NumberVat,
                        Addresses = addressesToImport
                    };

                    clientsToImport.Add(newClient);

                    sb.AppendLine(String.Format(SuccessfullyImportedClients, newClient.Name));
                }

                context.AddRange(clientsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Invoice> invoicesToImport = new List<Invoice>();

            ImportInvoiceDto[] importInvoiceDtoArr = JsonConvert
                .DeserializeObject<ImportInvoiceDto[]>(jsonString)!;

            if (importInvoiceDtoArr != null)
            {
                foreach (ImportInvoiceDto invoiceDto in importInvoiceDtoArr)
                {
                    if (!IsValid(invoiceDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCurrencyTypeValid = IsValidEnum<CurrencyType>(invoiceDto.CurrencyType);

                    bool isDueDateValid =
                        TryParseExactDate(invoiceDto.DueDate, "yyyy-MM-dd'T'HH:mm:ss", out var dueDate);

                    bool isIssueDateValid =
                        TryParseExactDate(invoiceDto.IssueDate, "yyyy-MM-dd'T'HH:mm:ss", out var issueDate);

                    bool isClientIdValid = context
                        .Clients
                        .AsNoTracking()
                        .Any(c => c.Id == invoiceDto.ClientId);

                    if (!isCurrencyTypeValid ||
                       !isDueDateValid ||
                       !isIssueDateValid ||
                       !isClientIdValid ||
                       dueDate < issueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (invoiceDto.Amount <= 0m)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Invoice newInvoice = new Invoice()
                    {
                        Number = invoiceDto.Number,
                        IssueDate = issueDate,
                        DueDate = dueDate,
                        Amount = invoiceDto.Amount,
                        CurrencyType = (CurrencyType)invoiceDto.CurrencyType,
                        ClientId = invoiceDto.ClientId
                    };

                    invoicesToImport.Add(newInvoice);

                    sb.AppendLine(String.Format(SuccessfullyImportedInvoices, newInvoice.Number));
                }

                context.AddRange(invoicesToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Product> productsToImport = new List<Product>();

            ImportProductDto[] importProductDtoArr = JsonConvert
                .DeserializeObject<ImportProductDto[]>(jsonString)!;

            if (importProductDtoArr != null)
            {
                foreach (var productDto in importProductDtoArr)
                {
                    if (!IsValid(productDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCategoryTypeValid = IsValidEnum<CategoryType>(productDto.CategoryType);

                    if (!isCategoryTypeValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var uniqueClientsIds = productDto.Clients.Distinct().ToList();


                    var clients = context
                        .Clients
                        .Where(m => uniqueClientsIds.Contains(m.Id))
                        .ToArray();

                    var existingClientsIds = clients.Select(c => c.Id).ToArray();

                    var missingClientsIds = uniqueClientsIds.Except(existingClientsIds).ToArray();

                    if (missingClientsIds.Any())
                    {
                        foreach (var existingClient in missingClientsIds)
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    Product newProduct = new Product()
                    {
                        Name = productDto.Name,
                        Price = productDto.Price,
                        CategoryType = (CategoryType)productDto.CategoryType,
                        ProductsClients = clients.Select(c => new ProductClient()
                        {
                            Client = c,
                            Product = null!
                        })
                        .ToArray(),
                    };

                    productsToImport.Add(newProduct);

                    sb.AppendLine(
                        String
                        .Format(SuccessfullyImportedProducts, newProduct.Name, newProduct.ProductsClients.Count));
                }
                context.AddRange(productsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
