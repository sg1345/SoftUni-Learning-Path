using System.Collections;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Cadastre.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            StringBuilder stringBuilder = new StringBuilder();

            ICollection<District> districtsToImport = new List<District>();


            ImportDistrictDto[] importDistrictDtos = XmlSerializerWrapper
                .Deserialize<ImportDistrictDto[]>(xmlDocument, "Districts")!;

            if (importDistrictDtos != null)
            {
                foreach (ImportDistrictDto districtDto in importDistrictDtos)
                {
                    ICollection<Property> propertiesToImport = new List<Property>();

                    if (!IsValid(districtDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDistrictExists = dbContext
                        .Districts
                        .Any(d => d.Name == districtDto.Name);

                    bool isDistrictAlreadyImported = districtsToImport
                        .Any(d => d.Name == districtDto.Name);

                    if (isDistrictAlreadyImported || isDistrictExists)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (ImportPropertyDto propertyDto in districtDto.Properties)
                    {
                        if (!IsValid(propertyDto))
                        {
                            stringBuilder.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isPropertyDateCorrectFormat = DateTime.TryParseExact
                        (propertyDto.DateOfAcquisition,
                            "dd/MM/yyyy",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime dateOfAcquisition);

                        bool isAreaNumber = int.TryParse(propertyDto.Area, out int area);
                        bool isAreaNegative = area < 0;

                        bool isPropertyExists = dbContext
                            .Properties
                            .AsNoTracking()
                            .Any(p => 
                                            p.Address == propertyDto.Address || 
                                            p.PropertyIdentifier == propertyDto.PropertyIdentifier);
                        bool isPropertyAlreadyImported = propertiesToImport
                            .Any(p =>
                                p.Address == propertyDto.Address ||
                                p.PropertyIdentifier == propertyDto.PropertyIdentifier);

                        if (!isPropertyDateCorrectFormat ||
                            isPropertyAlreadyImported ||
                            isPropertyExists ||
                            !isAreaNumber ||
                            isAreaNegative)
                        {
                            stringBuilder.AppendLine(ErrorMessage);
                            continue;
                        }

                        Property newProperty = new Property()
                        {
                            PropertyIdentifier = propertyDto.PropertyIdentifier,
                            Area = area,
                            Details = propertyDto.Details,
                            Address = propertyDto.Address,
                            DateOfAcquisition = dateOfAcquisition
                        };

                        propertiesToImport.Add(newProperty);
                    }

                    District newDistrict = new District()
                    {
                        Name = districtDto.Name,
                        PostalCode = districtDto.PostalCode,
                        Properties = propertiesToImport
                    };

                    districtsToImport.Add(newDistrict);
                    stringBuilder
                        .AppendLine(String.Format
                                            (SuccessfullyImportedDistrict,
                                            newDistrict.Name,
                                            newDistrict.Properties.Count));
                }
                dbContext.AddRange(districtsToImport);
                dbContext.SaveChanges();
            }

            return stringBuilder.ToString().TrimEnd();
        }
        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            StringBuilder stringBuilder = new StringBuilder();

            ICollection<Citizen> citizensToImport = new List<Citizen>();

            ImportCitizenDto[] importCitizenDtoArr = JsonConvert
                .DeserializeObject<ImportCitizenDto[]>(jsonDocument)!;

            if (importCitizenDtoArr != null)
            {
                foreach (ImportCitizenDto citizenDto in importCitizenDtoArr)
                {
                    if (!IsValid(citizenDto))
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isDateValid = DateTime
                        .TryParseExact(
                                       citizenDto.BirthDate,
                                       "dd-MM-yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out DateTime birthDate);

                    bool isMaritalStatusValid = Enum
                        .TryParse<MaritalStatus>(citizenDto.MaritalStatus, out MaritalStatus maritalStatus);

                    if (!isMaritalStatusValid || !isDateValid)
                    {
                        stringBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var properties = dbContext
                        .Properties
                        .Where(p => citizenDto.Properties.Contains(p.Id))
                        .ToList();


                    Citizen newCitizen = new Citizen()
                    {
                        FirstName = citizenDto.FirstName,
                        LastName = citizenDto.LastName,
                        BirthDate = birthDate,
                        MaritalStatus = maritalStatus,
                        PropertiesCitizens = properties
                            .Select(p => new PropertyCitizen
                            {
                                Property = p,
                                Citizen = null!
                            })
                            .ToList()
                    };

                    citizensToImport.Add(newCitizen);
                    stringBuilder.AppendLine(String
                        .Format(SuccessfullyImportedCitizen,
                                newCitizen.FirstName,
                                newCitizen.LastName,
                                newCitizen.PropertiesCitizens.Count));
                }
                dbContext.AddRange(citizensToImport);
                dbContext.SaveChanges();
            }

            return stringBuilder.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
