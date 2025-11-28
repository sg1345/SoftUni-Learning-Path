using Microsoft.EntityFrameworkCore;
using TravelAgency.Data;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;
using TravelAgency.Data.Models.Enums;
using TravelAgency.Data.Models;
using Newtonsoft.Json;
using System.Data;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guidesWithTourPackages = context
                .Guides
                .AsNoTracking()
                .Include(g => g.TourPackagesGuides)
                .ThenInclude(tpg => tpg.TourPackage)
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new GuideWithTourPackagesDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .OrderByDescending(tpg => tpg.TourPackage.Price)
                        .ThenBy(tpg => tpg.TourPackage.PackageName)
                        .Select(tpg => new TourPackageDto()
                        {
                            Name = tpg.TourPackage.PackageName,
                            Description = tpg.TourPackage.Description,
                            Price = tpg.TourPackage.Price.ToString("F2")
                        })
                        .ToArray()

                })
                .OrderByDescending(g => g.TourPackages.Length)
                .ThenBy(g => g.FullName)
                .ToArray();

            return XmlSerializerWrapper
                .Serialize<GuideWithTourPackagesDto[]>(guidesWithTourPackages, "Guides");

        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customersForHorseRidingTour = context
                .Customers
                .AsNoTracking()
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))

                .Select(c => new
                {
                    FullName = c.FullName,
                    PhoneNumber = c.PhoneNumber,
                    Bookings = c
                        .Bookings
                        .Where(b=> b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd")
                        })
                        .ToArray()

                })
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customersForHorseRidingTour, Formatting.Indented);
        }
    }
}
