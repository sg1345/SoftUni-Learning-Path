using Medicines.DataProcessor.ImportDtos;

namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Text.Json;
    using System.Xml;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Pharmacy> pharmacyToImport = new List<Pharmacy>();

            ImportPharmacyDto[] importPharmacyDtoArr = XmlSerializerWrapper
                .Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies")!;

            if (importPharmacyDtoArr != null)
            {
                foreach (ImportPharmacyDto pharmacyDto in importPharmacyDtoArr)
                {
                    ICollection<Medicine> medicineToImport = new List<Medicine>();

                    if (!IsValid(pharmacyDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isNonStopValid = bool.TryParse(pharmacyDto.IsNonStop, out bool isNonStop);

                    if (!isNonStopValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    foreach (ImportMedicineDto medicineDto in pharmacyDto.Medicines)
                    {
                        if (!IsValid(medicineDto))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isPriceValid = decimal.TryParse(medicineDto.Price, out decimal price);

                        if (!isPriceValid ||
                            (price < 0.01m || price > 1000.00m))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        bool isProductionDateValid = DateTime.TryParseExact
                        (medicineDto.ProductionDate,
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime productionDate);

                        bool isExpiryDateValid = DateTime.TryParseExact
                        (medicineDto.ExpiryDate,
                            "yyyy-MM-dd",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime expiryDate);

                        bool isCategoryValid = Enum.TryParse<Category>(medicineDto.Category, out Category category)
                                               && Enum.IsDefined(typeof(Category), category);

                        if (!isExpiryDateValid ||
                           !isProductionDateValid ||
                           productionDate >= expiryDate ||
                           !isCategoryValid)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        //bool isMedicineInvalidRecord = context
                        //    .Medicines
                        //    .Include(m => m.Pharmacy)
                        //    .AsNoTracking()
                        //    .Where(m => m.Pharmacy.Name != pharmacyDto.Name)
                        //    .Any(m =>
                        //                    m.Name == medicineDto.Name &&
                        //                    m.Producer == medicineDto.Producer);

                        bool isMedicineAlreadyImported = medicineToImport
                            .Any(m => m.Name == medicineDto.Name && m.Producer == medicineDto.Producer);

                        if (isMedicineAlreadyImported )
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Medicine newMedicine = new Medicine()
                        {
                            Name = medicineDto.Name,
                            Price = price,
                            Category = category,
                            ProductionDate = productionDate,
                            ExpiryDate = expiryDate,
                            Producer = medicineDto.Producer
                        };

                        medicineToImport.Add(newMedicine);
                    }

                    Pharmacy newPharmacy = new Pharmacy()
                    {
                        Name = pharmacyDto.Name,
                        PhoneNumber = pharmacyDto.PhoneNumber,
                        IsNonStop = isNonStop,
                        Medicines = medicineToImport
                    };


                    pharmacyToImport.Add(newPharmacy);
                    sb.AppendLine(String
                        .Format(SuccessfullyImportedPharmacy, newPharmacy.Name, newPharmacy.Medicines.Count));
                }
                context.AddRange(pharmacyToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ICollection<Patient> patientsToImport = new List<Patient>();

            ImportPatientDto[] importPatientDtoArr = JsonConvert
                .DeserializeObject<ImportPatientDto[]>(jsonString)!;

            if (importPatientDtoArr != null)
            {
                foreach (ImportPatientDto patientDto in importPatientDtoArr)
                {
                    if (!IsValid(patientDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool isGenderValid = Enum
                        .TryParse<Gender>(patientDto.Gender, out Gender gender)
                                          && Enum.IsDefined(typeof(Gender), gender);

                    bool isAgeGroupValid = Enum
                        .TryParse<AgeGroup>(patientDto.AgeGroup, out AgeGroup ageGroup)
                                           && Enum.IsDefined(typeof(AgeGroup), ageGroup);

                    if (!isGenderValid || !isAgeGroupValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var seen = new Dictionary<int, int>();
                    foreach (int medicineId in patientDto.Medicines)
                    {
                        if (!seen.ContainsKey(medicineId))
                        {
                            seen[medicineId] = 1;
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                            seen[medicineId]++;
                        }
                    }

                    var medicines = context
                        .Medicines
                        .Where(m => patientDto.Medicines.Contains(m.Id))
                        .ToList();

                    Patient newPatient = new Patient()
                    {
                        FullName = patientDto.FullName,
                        AgeGroup = ageGroup,
                        Gender = gender,
                        PatientsMedicines = medicines
                            .Select(m => new PatientMedicine()
                            {
                                Medicine = m,
                                Patient = null!
                            })
                            .ToList()
                    };

                    patientsToImport.Add(newPatient);

                    sb.AppendLine(String
                        .Format(SuccessfullyImportedPatient, newPatient.FullName, newPatient.PatientsMedicines.Count));
                }
                context.AddRange(patientsToImport);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
