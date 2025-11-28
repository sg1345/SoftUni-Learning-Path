using Cadastre.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Newtonsoft.Json;
using Cadastre.DataProcessor.ExportDtos;
using Cadastre.Utilities;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            DateTime startDate = DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            var propertiesWithOwners = dbContext
                .Properties
                .AsNoTracking()
                .Where(p => p.DateOfAcquisition >= startDate)
                .OrderByDescending(p => p.DateOfAcquisition)
                .ThenBy(p => p.PropertyIdentifier)
                .Select(p => new
                {
                    p.PropertyIdentifier,
                    p.Area,
                    p.Address,
                    p.DateOfAcquisition,
                    Owners = p.PropertiesCitizens                            
                        .Select(pc => new
                        {
                            pc.Citizen.LastName,
                            pc.Citizen.MaritalStatus
                        })
                        .OrderBy(pc => pc.LastName)
                        .ToArray()
                })
                .ToArray();

            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatString = "dd/MM/yyyy",
                Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() }
            };

            return JsonConvert.SerializeObject(propertiesWithOwners, settings); 
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {

            var propertiesWithDistrict = dbContext
                .Properties
                .AsNoTracking()
                .Where(p => p.Area >= 100)
                .OrderByDescending(p=>p.Area)
                .ThenBy(p=>p.DateOfAcquisition)
                .Select(p => new ExportProperty()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area.ToString(),
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                })
                .ToArray();

            return XmlSerializerWrapper.Serialize<ExportProperty[]>(propertiesWithDistrict, "Properties");
        }
    }
}
