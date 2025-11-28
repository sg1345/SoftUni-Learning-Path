namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Invoices.Utilities;

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

            if(importClientDtoArr != null)
            {
                foreach(ImportClientDto clientDto in importClientDtoArr)
                {
                    ICollection<Address> addressesToImport = new List<Address>();

                    if(!IsValid(clientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach(ImportAddressDto addressDto in clientDto.Addresses)
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

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

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
