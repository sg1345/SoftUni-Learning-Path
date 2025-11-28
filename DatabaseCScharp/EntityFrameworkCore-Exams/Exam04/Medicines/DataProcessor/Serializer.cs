namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            DateTime givenDate = DateTime.Parse(date, CultureInfo.InvariantCulture, DateTimeStyles.None);

            var patientsWithMedicines = context
                .Patients                
                .AsNoTracking()
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > givenDate))                
                .Select(p => new ExportPatientDto()
                {
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                                .Where(pm => pm.Medicine.ProductionDate > givenDate)
                                .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                                .ThenBy(pm => pm.Medicine.Price)
                                .Select(pm => new ExportMedicineDto()
                                {
                                    Name = pm.Medicine.Name,
                                    Price = pm.Medicine.Price.ToString("F2"),
                                    Producer = pm.Medicine.Producer.ToString(),
                                    BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd"),
                                    Category = pm.Medicine.Category.ToString().ToLower()
                                })
                                .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            return XmlSerializerWrapper.Serialize<ExportPatientDto[]>(patientsWithMedicines, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {

            var medicinesFromDesiredCategoryInNonStopPharmacies = context
                .Medicines
                .Include(m => m.Pharmacy)
                .AsNoTracking()
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        m.Pharmacy.Name,
                        m.Pharmacy.PhoneNumber
                    }
                })
                
                .ToArray();



                return JsonConvert
                    .SerializeObject(medicinesFromDesiredCategoryInNonStopPharmacies, Formatting.Indented);
        }
    }
}
