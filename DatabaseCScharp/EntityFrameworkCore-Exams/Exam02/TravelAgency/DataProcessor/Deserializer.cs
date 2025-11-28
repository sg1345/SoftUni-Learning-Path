using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;
using System.Globalization;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Customer> customersToImport = new List<Customer>();

            ImportCustomerDto[] importCustomerDtoArr = XmlSerializerWrapper
                .Deserialize<ImportCustomerDto[]>(xmlString, "Customers")!;

            if (importCustomerDtoArr != null)
            {
                foreach (var customerDro in importCustomerDtoArr)
                {

                    if(!IsValid(customerDro))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isCustomerAlreadyImported = customersToImport
                        .Any(c=> 
                                        c.FullName == customerDro.FullName || 
                                        c.Email == customerDro.Email ||
                                        c.PhoneNumber == customerDro.PhoneNumber);

                    bool isCustomerExists = context
                        .Customers
                        //.AsNoTracking()
                        .Any(c =>
                                        c.FullName == customerDro.FullName ||
                                        c.Email == customerDro.Email ||
                                        c.PhoneNumber == customerDro.PhoneNumber);

                    if(isCustomerAlreadyImported || isCustomerExists)
                    {
                        sb.AppendLine(DuplicationDataMessage);
                        continue;
                    }

                    Customer customer = new Customer()
                    {
                        FullName = customerDro.FullName,
                        Email = customerDro.Email,
                        PhoneNumber = customerDro.PhoneNumber
                    };

                    customersToImport.Add(customer);
                    sb.AppendLine(String.Format(SuccessfullyImportedCustomer, customer.FullName));
                }
                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }
            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Booking> bookingsToImport = new List<Booking>();

            ImportBookingDto[] importBookingDtoArr = JsonConvert
                .DeserializeObject<ImportBookingDto[]>(jsonString)!;

            if (importBookingDtoArr != null)
            {
                foreach (var bookingDto in importBookingDtoArr)
                {
                    if(!IsValid(bookingDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isBookingDateValid  = DateTime
                        .TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime bookingDate);

                    if (!isBookingDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isBookingExists = context
                        .Bookings
                        .Any(b =>
                                b.Customer!.FullName == bookingDto.CustomerName &&
                                b.TourPackage!.PackageName == bookingDto.TourPackageName &&
                                b.BookingDate == bookingDate);

                    bool isBookingAlreadyImported = bookingsToImport
                        .Any(b =>
                                b.Customer!.FullName == bookingDto.CustomerName &&
                                b.TourPackage!.PackageName == bookingDto.TourPackageName &&
                                b.BookingDate == bookingDate);

                    if (isBookingExists || isBookingAlreadyImported)
                    {
                        sb.Append(DuplicationDataMessage);
                        continue;
                    }

                    Booking booking = new Booking()
                    {
                        BookingDate = bookingDate,
                        Customer = context.Customers
                            .FirstOrDefault(c => c.FullName == bookingDto.CustomerName)!,
                        TourPackage = context.TourPackages
                            .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName)!
                    };

                    bookingsToImport.Add(booking);
                    sb.AppendLine(String
                        .Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName, booking.BookingDate.ToString("yyyy-MM-dd")));
                }
                context.Bookings.AddRange(bookingsToImport);
                context.SaveChanges();
            }


            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
