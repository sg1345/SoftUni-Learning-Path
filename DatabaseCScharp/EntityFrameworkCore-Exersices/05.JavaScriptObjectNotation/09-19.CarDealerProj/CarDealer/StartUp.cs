

namespace CarDealer
{
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    using DTOs.Import;
    using Models;
    using Data;
    using System.IO;
    using DTOs.Export;

    public class StartUp
    {
        public static void Main()
        {
            using CarDealerContext context = new CarDealerContext();

            CreatingDatabase(context);
            AddDataToDatabase(context);

            //"suppliers";
            //"parts";
            //"cars";
            //"customers";
            //"sales";

            //string inputJson = GetJsonFromFile("cars");
            ////string result = ImportCars(context, inputJson);
            //string result = GetSalesWithAppliedDiscount(context);
 
            //Console.WriteLine(result);

            //JsonCreatorFromJudge("formatted-test-results-problem-18");
            //JsonCreator(result, "json-problem-17");
        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            ICollection<Supplier> suppliersToImport = new List<Supplier>();

            IEnumerable<ImportSupplierDto> suppliersDtoArr =
                JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson)!;

            if (suppliersDtoArr != null)
            {
                foreach (var supplierDto in suppliersDtoArr)
                {
                    if (!IsValid(supplierDto))
                        continue;

                    bool isImporterValid = bool.TryParse(supplierDto.IsImporter, out bool isImporter);
                    bool isNameValid = !string.IsNullOrEmpty(supplierDto.Name);

                    if (!isImporterValid)
                        continue;

                    if (!isNameValid)
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

            return $"Successfully imported {suppliersToImport.Count}.";
        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            ICollection<Part> partsToImport = new List<Part>();

            IEnumerable<ImportPartDto> partsDtoArr =
                JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson)!;

            IEnumerable<int> existingSupplierId = context.Suppliers.AsNoTracking().Select(s => s.Id).ToArray();

            if (partsDtoArr != null)
            {
                foreach (var supplierDto in partsDtoArr)
                {
                    if (!IsValid(supplierDto))
                        continue;

                    bool isNameValid = !string.IsNullOrEmpty(supplierDto.Name);
                    bool isPriceValid = decimal.TryParse(supplierDto.Price, out decimal price);
                    bool isQuantityValid = int.TryParse(supplierDto.Quantity, out int quantity);
                    bool isSupplierIdValid = int.TryParse(supplierDto.SupplierId, out int supplierId);

                    if (!isNameValid)
                        continue;
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
            return $"Successfully imported {partsToImport.Count}.";
        }

        //Problem 11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            ICollection<Car> carsToImport = new List<Car>();
            ICollection<PartCar> partsCarsToImport = new List<PartCar>();

            IEnumerable<ImportCarsDto> carsDtoArr =
                JsonConvert.DeserializeObject<ImportCarsDto[]>(inputJson)!;

            //int carsDtoArrCount = carsDtoArr.Count();

            //var existingPartsId = context
            //    .Parts
            //    .AsNoTracking()
            //    .Select(p => p.Id)
            //    .ToArray();


            if (carsDtoArr != null)
            {
                foreach (var carDto in carsDtoArr)
                {
                    if (!IsValid(carDto))
                        continue;

                    bool isMakeValid = !string.IsNullOrEmpty(carDto.Make);
                    bool isModelValid = !string.IsNullOrEmpty(carDto.Model);
                    //bool isTraveledDistanceValid = long.TryParse(carDto.TraveledDistance, out long traveledDistance);
                    bool isPartsIdValid = carDto.PartsIds.Length > 0;

                    if (!isMakeValid)
                        continue;
                    if (!isModelValid)
                        continue;
                    //if (!isTraveledDistanceValid)
                    //continue;
                    if (!isPartsIdValid)
                        continue;


                    Car car = new Car()
                    {
                        Make = carDto.Make,
                        Model = carDto.Model,
                        TraveledDistance = carDto.TraveledDistance
                    };

                    carsToImport.Add(car);

                    foreach (var part in carDto.PartsIds.Distinct())
                    {
                        if (!context.Parts.Any(p => p.Id == part))
                            continue;

                        PartCar partCar = new PartCar()
                        {
                            PartId = part,
                            Car = car
                        };

                        partsCarsToImport.Add(partCar);

                    }
                }
                context.PartsCars.AddRange(partsCarsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {carsToImport.Count}.";
        }

        //Problem 12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            ICollection<Customer> customersToImport = new List<Customer>();
            IEnumerable<ImportCustomerDto> customersDtoArr =
                JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson)!;

            if (customersDtoArr != null)
            {
                foreach (ImportCustomerDto customerDto in customersDtoArr)
                {
                    if (!IsValid(customerDto))
                        continue;

                    bool isNameValid = !string.IsNullOrEmpty(customerDto.Name);
                    bool isBirthDateValid = DateTime.TryParseExact(
                        customerDto.BirthDate,
                        "yyyy-MM-ddTHH:mm:ss",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out DateTime birthDate
                    );

                    if (!isNameValid)
                        continue;
                    if (!isBirthDateValid)
                        continue;

                    Customer customerToAdd = new Customer()
                    {
                        Name = customerDto.Name,
                        BirthDate = birthDate,
                        IsYoungDriver = customerDto.IsYoungDriver
                    };

                    customersToImport.Add(customerToAdd);
                }
                context.Customers.AddRange(customersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {customersToImport.Count}.";
        }

        //Problem 13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            ICollection<Sale> salesToImport = new List<Sale>();

            IEnumerable<ImportSaleDto> salesDtoArr =
                JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson)!;

            if (salesDtoArr != null)
            {
                foreach (var saleDto in salesDtoArr)
                {
                    //if (!IsValid(saleDto))
                    //    continue;

                    bool isCarIdExisting = context
                        .Cars
                        .Any(c => c.Id == saleDto.CarId);

                    if (!isCarIdExisting)
                        continue;

                    bool isCustomerIdExisting = context
                        .Customers
                        .Any(c => c.Id == saleDto.CustomerId);

                    if (!isCustomerIdExisting)
                        continue;

                    Sale saleToAdd = new Sale()
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };

                    salesToImport.Add(saleToAdd);
                }
                context.Sales.AddRange(salesToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {salesToImport.Count}.";
        }

        //Problem 14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .AsNoTracking()
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .Select(c => new
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var orderedCustomersArr = customers
                .Select(c => new ExportOrderedCustomerDto
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = c.IsYoungDriver
                })
                .ToArray();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(orderedCustomersArr, options);

            return jsonResult;
        }

        //Problem 15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var carsFromToyota = context
                .Cars
                .AsNoTracking()
                .Where(c => c.Make == "Toyota")
                .Select(c => new
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ToArray();

            var carDtoArr = carsFromToyota
                .Select(c => new ExportCarDto
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .ToArray();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(carDtoArr, options);

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
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count
                })
                .ToArray();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(suppliers, options);

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
                    car = new
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TraveledDistance = c.TraveledDistance
                    },
                    parts = c.PartsCars.Select(pc => new
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price
                    })
                })
                .ToArray();

            var carWithPartsDtoArr = carsWithParts.Select(c => new
            {
                car = new
                {
                    Make = c.car.Make,
                    Model = c.car.Model,
                    TraveledDistance = c.car.TraveledDistance
                },
                parts = c.parts.Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price.ToString("F2")
                })
                .ToArray()
            })
                .ToArray();

            var options = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string jsonResult = JsonConvert.SerializeObject(carWithPartsDtoArr, options);

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
                    fullName = c.Name,
                    boughtCars = c.Sales.Count,
                    spentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(pc => pc.Part.Price)
                })
                .OrderByDescending(c => c.spentMoney)
                .ThenByDescending(c => c.boughtCars)
                .ToArray();

            var jsonResult = JsonConvert.SerializeObject(customersWithBoughtCars, Formatting.Indented);

            return jsonResult;
        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context) 
        {
            var customersWithAppliedDiscount = context
                .Sales
                .AsNoTracking()
                .Select(s=> new
                {
                    car = new 
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = s.Discount.ToString("F2"),
                    price = s.Car.PartsCars
                        .Sum(pc => pc.Part.Price)
                        .ToString("F2"),
                    priceWithDiscount = (s.Car.PartsCars.Sum(pc => pc.Part.Price) * (1 - s.Discount / 100)).ToString("F2")
                })
                .Take(10)
                .ToArray();

            string jsonResult = JsonConvert.SerializeObject(customersWithAppliedDiscount, Formatting.Indented);

            return jsonResult;
        }

        //Add-ons
        private static void CreatingDatabase(CarDealerContext context)
        {
            try
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Console.WriteLine("Database created!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void AddDataToDatabase(CarDealerContext context)
        {
            string jsonFileNameSuppliersJson = "suppliers.json";
            string jsonFileNamePartsJson = "parts.json";
            string jsonFileNameCarsJson = "cars.json";
            string jsonFileNameCustomersJson = "customers.json";
            string jsonFileNameSalesJson = "sales.json";

            string jsonFileDirPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

            string inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameSuppliersJson);
            string result = ImportSuppliers(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNamePartsJson);
            result = ImportParts(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameCarsJson);
            result = ImportCars(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameCustomersJson);
            result = ImportCustomers(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameSalesJson);
            result = ImportSales(context, inputJson);
            Console.WriteLine(result);
        }

        private static void JsonCreatorFromJudge(string jsonName)
        {
            string temp = "[{\"fullName\":\"Emmitt Benally\",\"boughtCars\":2,\"spentMoney\":12176.73},{\"fullName\":\"Natalie Poli\",\"boughtCars\":3,\"spentMoney\":9376.39},{\"fullName\":\"Marcelle Griego\",\"boughtCars\":1,\"spentMoney\":6211.03},{\"fullName\":\"Zada Attwood\",\"boughtCars\":1,\"spentMoney\":3405.02},{\"fullName\":\"Lino Subia\",\"boughtCars\":1,\"spentMoney\":1246.67},{\"fullName\":\"Hai Everton\",\"boughtCars\":1,\"spentMoney\":267.32}]";


            var parsedTemp = JsonConvert.DeserializeObject(temp);
            string prettyTemp = JsonConvert.SerializeObject(parsedTemp, Formatting.Indented);
            Console.WriteLine(prettyTemp);
            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string jsonFileSaveName = jsonName + ".json"; //"formatted-test-results-problem-8.json";
            File.WriteAllText(jsonFileSavePath + jsonFileSaveName, prettyTemp);
        }

        private static void JsonCreator(string inputJson, string jsonName)
        {

            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string jsonFileSaveName = jsonName + ".json"; //"formatted-test-results-problem-8.json";
            File.WriteAllText(jsonFileSavePath + jsonFileSaveName, inputJson);
        }

        private static void JsonTester()
        {
            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string jsonFileSaveName = "formatted-test-results.json";
            string input = File.ReadAllText(jsonFileSavePath + jsonFileSaveName);

            Console.WriteLine($"Test results - {input.Length}");
        }

        private static string GetJsonFromFile(string fileNameNoJson)
        {
            string jsonFileNameJson = fileNameNoJson + ".json";
            string jsonFileDirPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameJson);

            return inputJson;
        }

        private static bool IsValid(object obj)
        {
            // These two variables are required by the Validator.TryValidateObject method
            // We will not use them for now...
            // We are just using the Validation result (true or false)
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults
                = new List<ValidationResult>();

            return Validator
                .TryValidateObject(obj, validationContext, validationResults);
        }

    }
}