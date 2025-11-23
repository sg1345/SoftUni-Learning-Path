

namespace CarDealer
{
    using Newtonsoft.Json;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;

    using Models;
    using Data;
    using DTOs.Import;
    using DTOs.Export;
    using Utilities;
    using static Utilities.UtilityToolkit;


    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            Dictionary<string, string> methodDataset = new Dictionary<string, string>()
            {
                { "ImportSuppliers", "suppliers.xml" },
                { "ImportParts", "parts.xml"},
                { "ImportCars", "cars.xml"},
                { "ImportCustomers", "customers.xml"},
                { "ImportSales", "sales.xml"}
            };

            //CreatingDatabase(context);
            //AddDataToDatabase(context, methodDataset);

            //FileLengthTester("suppliers.xml", "../../../Datasets/");

            FileCreator(GetCarsWithDistance(context), "cars-problem-14.xml");
            FileCreator(GetCarsFromMakeBmw(context), "bmw-cars-problem-15.xml");
            FileCreator(GetLocalSuppliers(context), "local-suppliers-problem-16.xml");
            FileCreator(GetCarsWithTheirListOfParts(context), "cars-and-parts-problem-17.xml");
            FileCreator(GetTotalSalesByCustomer(context), "customers-total-sales-problem-18.xml");
            FileCreator(GetSalesWithAppliedDiscount(context), "sales-discounts-problem-19.xml");
        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            ImportSupplierDto[] suppliersDtoArr = XmlSerializerWrapper
                .Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers")!;

            if (suppliersDtoArr != null)
            {
                foreach (var supplierDto in suppliersDtoArr)
                {
                    if (!IsValid(supplierDto))
                        continue;

                    bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);

                    if (!isImporterValid)
                        continue;

                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = isImporter
                    };

                    suppliersToImport.Add(supplier);
                }
                context.Suppliers.AddRange(suppliersToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {suppliersToImport.Count}";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            ICollection<Part> partsToImport = new List<Part>();

            ImportPartDto[] partsDtoArr = XmlSerializerWrapper
                .Deserialize<ImportPartDto[]>(inputXml, "Parts")!;

            IEnumerable<int> existingSupplierId = context
                .Suppliers
                .AsNoTracking()
                .Select(s => s.Id)
                .ToArray();

            if (partsDtoArr != null)
            {
                foreach (var supplierDto in partsDtoArr)
                {
                    if (!IsValid(supplierDto))
                        continue;

                    bool isPriceValid = decimal.TryParse(supplierDto.Price, out decimal price);
                    bool isQuantityValid = int.TryParse(supplierDto.Quantity, out int quantity);
                    bool isSupplierIdValid = int.TryParse(supplierDto.SupplierId, out int supplierId);

                    if (!isPriceValid)
                        continue;
                    if (!isQuantityValid)
                        continue;
                    if (!isSupplierIdValid ||
                        !existingSupplierId.Contains(supplierId))
                        continue;

                    Part part = new Part()
                    {
                        Name = supplierDto.Name,
                        Price = price,
                        Quantity = quantity,
                        SupplierId = supplierId
                    };

                    partsToImport.Add(part);
                }
                context.Parts.AddRange(partsToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {partsToImport.Count}";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            ICollection<Car> carsToImport = new List<Car>();
            ICollection<PartCar> partsCarsToImport = new List<PartCar>();

            ImportCarsDto[] carsDtoArr = XmlSerializerWrapper
                    .Deserialize<ImportCarsDto[]>(inputXml, "Cars")!;

            if (carsDtoArr != null)
            {
                foreach (var carDto in carsDtoArr)
                {
                    if (!IsValid(carDto))
                        continue;

                    bool isTraveledDistanceValid = long.TryParse(carDto.TraveledDistance, out long traveledDistance);
                    bool isPartsIdValid = carDto.Parts.Length > 0;

                    if (!isTraveledDistanceValid)
                        continue;
                    if (!isPartsIdValid)
                        continue;


                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = traveledDistance
                    };

                    carsToImport.Add(car);

                    foreach (string part in carDto.Parts.Select(p => p.Id).Distinct())
                    {
                        if (!IsValid(part))
                            continue;

                        bool isPartIdValid = int.TryParse(part, out int partId);

                        if (!isPartIdValid)
                            continue;

                        if (!context.Parts.Any(p => p.Id == partId))
                            continue;

                        PartCar partCar = new PartCar()
                        {
                            Car = car,
                            PartId = partId

                        };

                        partsCarsToImport.Add(partCar);

                    }
                }
                context.PartsCars.AddRange(partsCarsToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {carsToImport.Count}";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            ICollection<Customer> customersToImport = new List<Customer>();
            ImportCustomerDto[] customersDtoArr = XmlSerializerWrapper
                .Deserialize<ImportCustomerDto[]>(inputXml, "Customers")!;

            if (customersDtoArr != null)
            {
                foreach (ImportCustomerDto customerDto in customersDtoArr)
                {
                    if (!IsValid(customerDto))
                        continue;

                    bool isBirthDateValid = DateTime.TryParseExact(
                        customerDto.BirthDate,
                        "yyyy-MM-ddTHH:mm:ss",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime birthDate
                    );

                    bool isYoungDriverValid = bool.TryParse(customerDto.IsYoungDriver, out bool isYoungDriver);

                    if (!isYoungDriverValid)
                        continue;
                    if (!isBirthDateValid)
                        continue;

                    Customer customerToAdd = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = isYoungDriver
                    };

                    customersToImport.Add(customerToAdd);
                }
                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {customersToImport.Count}";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            ICollection<Sale> salesToImport = new List<Sale>();

            ImportSaleDto[] salesDtoArr = XmlSerializerWrapper
                .Deserialize<ImportSaleDto[]>(inputXml, "Sales")!;

            if (salesDtoArr != null)
            {
                foreach (var saleDto in salesDtoArr)
                {
                    if (!IsValid(saleDto))
                        continue;

                    bool isCarIdValid = int.TryParse(saleDto.CarId, out int carId);
                    bool isCustomerIdValid = int.TryParse(saleDto.CustomerId, out int customerId);
                    bool isDiscountValid = decimal.TryParse(saleDto.Discount, out decimal discount);

                    bool isCarIdExisting = context
                        .Cars
                        .AsNoTracking()
                        .Any(c => c.Id == carId);

                    if (!isCarIdValid || !isCustomerIdValid || !isDiscountValid)
                        continue;

                    if (!isCarIdExisting)
                        continue;

                    Sale saleToAdd = new Sale()
                    {
                        CarId = carId,
                        CustomerId = customerId,
                        Discount = discount
                    };

                    salesToImport.Add(saleToAdd);
                }
                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {salesToImport.Count}";
        }

        //Problem 14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context
                .Cars
                .AsNoTracking()
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var exportCarsWithDistanceDtoArr = carsWithDistance
                .Select(c => new ExportCarWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                })
                .ToArray();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonResult = XmlSerializerWrapper.Serialize<ExportCarWithDistanceDto[]>(exportCarsWithDistanceDtoArr, "cars");

            return jsonResult;
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var carsFromBmw = context
                .Cars
                .AsNoTracking()
                .Where(c => c.Make == "BMW")
                .Select(c => new
                {
                    Id = c.Id,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            var carDtoArr = carsFromBmw
                .Select(c => new ExportCarsFromMakeBmw
                {
                    Id = c.Id.ToString(),
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString()
                })
                .ToArray();

            string jsonResult = XmlSerializerWrapper
                .Serialize<ExportCarsFromMakeBmw[]>(carDtoArr, "cars");

            return jsonResult;
        }

        //Problem 16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .AsNoTracking()
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSupplierDto
                {
                    Id = s.Id.ToString(),
                    Name = s.Name,
                    PartsCount = s.Parts.Count.ToString()
                })
                .ToArray();

            string jsonResult = XmlSerializerWrapper
                .Serialize<ExportLocalSupplierDto[]>(suppliers, "suppliers");

            return jsonResult;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context
                .Cars
                .AsNoTracking()
                .Select(c => new
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance,
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ToArray()
                })
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            var carWithPartsDtoArr = carsWithParts
                .Select(c => new ExportCarAndPartsDto
                {

                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance.ToString(),
                    Parts = c.parts.Select(p => new ExportPartDto
                    {
                        Name = p.Name,
                        Price = p.Price.ToString("G29")
                    })
                    .ToArray()

                })
                .ToArray();

            string jsonResult = XmlSerializerWrapper
                .Serialize<ExportCarAndPartsDto[]>(carWithPartsDtoArr, "cars");

            return jsonResult;
        }

        //Problem 18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithBoughtCars = context
                .Customers
                .AsNoTracking()
                .Where(c => c.Sales.Any())
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.IsYoungDriver
                        ? c.Sales
                            .SelectMany(s => s.Car.PartsCars)
                            .Sum(pc => Math.Round(pc.Part.Price * 0.95m * 100) / 100)
                        : c.Sales
                            .SelectMany(s => s.Car.PartsCars)
                            .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                //.ThenByDescending(c => c.BoughtCars)
                .ToArray();

            var exportCustomerTotalSalesDtoArr = customersWithBoughtCars
                .Select(c => new ExportCustomerTotalSales
                {
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars.ToString(),
                    SpentMoney = c.SpentMoney.ToString("F2")
                })
                .ToArray();

            var jsonResult = XmlSerializerWrapper
                .Serialize<ExportCustomerTotalSales[]>(exportCustomerTotalSalesDtoArr, "customers");

            return jsonResult;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var customersWithAppliedDiscount = context
                .Sales
                .AsNoTracking()
                .Select(s => new ExportSalesWithAppliedDiscountDto
                {
                    Car = new ExportCarInfoDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance.ToString()
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("G29"),
                    Price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price)
                        .ToString("F2"),
                    PriceWithDiscount = (Math.Round((s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)) * 10000) / 10000).ToString("G29")
                })
                //.Take(10)
                .ToArray();

            string jsonResult = XmlSerializerWrapper
                .Serialize<ExportSalesWithAppliedDiscountDto[]>(customersWithAppliedDiscount, "sales");

            return jsonResult;
        }

    }
}