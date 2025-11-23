

namespace ProductShop
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using Data;
    using DTOs.Import;
    using DTOs.Export;
    using Utilities;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            //CreatingDatabase(context);
            //AddDataToDatabase(context);

            string result = GetUsersWithProducts(context);
            XmlCreator(result, "users-and-products-problem-8");

        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            ICollection<User> usersToImport = new List<User>();

            ImportUserDto[]? importUserDtoArray =
                XmlSerializerWrapper.Deserialize<ImportUserDto[]>(inputXml, "Users");

            if (importUserDtoArray != null)
            {
                foreach (var importUserDto in importUserDtoArray)
                {
                    if (!IsValid(importUserDto))
                        continue;

                    bool isAgeValid = TryParseNullableInt(importUserDto.Age, out int? age);

                    if (!isAgeValid)
                        continue;

                    User user = new User()
                    {
                        FirstName = importUserDto.FirstName,
                        LastName = importUserDto.LastName,
                        Age = age
                    };

                    usersToImport.Add(user);
                }
                context.Users.AddRange(usersToImport);
                context.SaveChanges();

            }

            return $"Successfully imported {usersToImport.Count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            ICollection<Product> productsToImport = new List<Product>();

            ImportProductDto[]? importUserDtoArray =
                XmlSerializerWrapper.Deserialize<ImportProductDto[]>(inputXml, "Products");

            if (importUserDtoArray != null)
            {
                foreach (ImportProductDto importProductDto in importUserDtoArray)
                {
                    if (!IsValid(importProductDto))
                        continue;

                    bool isPriceValid = decimal
                        .TryParse(importProductDto.Price, out decimal price);
                    bool isSellerIdValid = int
                        .TryParse(importProductDto.SellerId, out int sellerId);
                    bool isBuyerIdValid = TryParseNullableInt(importProductDto.BuyerId, out int? buyerId);

                    if (!isPriceValid || !isSellerIdValid || !isBuyerIdValid)
                        continue;

                    Product product = new Product()
                    {
                        Name = importProductDto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = buyerId
                    };

                    productsToImport.Add(product);
                }
                context.Products.AddRange(productsToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {productsToImport.Count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            ICollection<Category> CategoriesToImport = new List<Category>();

            ImportCategoryDto[]? importCategoryDtoArray =
                XmlSerializerWrapper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");

            if (importCategoryDtoArray != null)
            {
                foreach (var importCategotyDto in importCategoryDtoArray)
                {
                    if (!IsValid(importCategotyDto))
                        continue;

                    Category category = new Category()
                    {
                        Name = importCategotyDto.Name
                    };

                    CategoriesToImport.Add(category);
                }
                context.Categories.AddRange(CategoriesToImport);
                context.SaveChanges();
            }
            return $"Successfully imported {CategoriesToImport.Count}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            ICollection<CategoryProduct> categoriesProductsToImport = new List<CategoryProduct>();

            ImportCategoryProductDto[]? importCategoryProductDtoArray =
                XmlSerializerWrapper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");

            if (importCategoryProductDtoArray != null)
            {
                foreach (var importCategoryProductDto in importCategoryProductDtoArray)
                {
                    if (!IsValid(importCategoryProductDto))
                        continue;

                    bool isCategoryIdValid = int.TryParse(importCategoryProductDto.CategoryId, out int categoryId);
                    bool isProductIdValid = int.TryParse(importCategoryProductDto.ProductId, out int productId);

                    if (!isCategoryIdValid || !isProductIdValid)
                        continue;

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };

                    categoriesProductsToImport.Add(categoryProduct);
                }
                context.CategoryProducts.AddRange(categoriesProductsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesProductsToImport.Count}";
        }

        //Problem 5
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context
                .Products
                .AsNoTracking()
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                })
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .ToArray();

            var productsInRangeDtoArr = productsInRange
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Buyer = p.Buyer
                })
                .ToArray();

            string result = XmlSerializerWrapper.Serialize<ExportProductsInRangeDto[]>(productsInRangeDtoArr,"Products");

            return result;
        }

        //Problem 6
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u
                        .ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            ProductName = p.Name,
                            ProductPrice = p.Price
                            //BuyerFirstName = p.Buyer!.FirstName,
                            //BuyerLastName = p.Buyer.LastName
                        })
                        //.OrderBy(p => p.BuyerLastName)
                        //.ThenBy(p => p.BuyerFirstName)
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var usersWithSoldProductsDtoArr = usersWithSoldProducts
                .Select(u => new ExportSoldProductDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.SoldProducts
                        .Select(p => new SoldProductDetailsDto()
                        {
                            Name = p.ProductName,
                            Price = p.ProductPrice
                            //BuyerFirstName = p.BuyerFirstName,
                            //BuyerLastName = p.BuyerLastName
                        })
                        .ToArray()
                }).ToArray();

            //Console.WriteLine(usersWithSoldProductsDtoArr.Length);

            string result = XmlSerializerWrapper.Serialize<ExportSoldProductDto[]>(usersWithSoldProductsDtoArr, "Users");
            //Console.WriteLine(result.Length);
            return result;
        }

        //Problem 7
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .AsNoTracking()
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(c => c.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();


            var categoriesDtoArr = categories
                .Select(e => new ExportCategoriesByProductsCountDto()
                {
                    CategoryName = e.Category,
                    ProductsCount = e.ProductsCount,
                    AveragePrice = $"{e.AveragePrice}",
                    TotalRevenue = $"{e.TotalRevenue:F2}"
                })
                .ToArray();

            string result = XmlSerializerWrapper.Serialize<ExportCategoriesByProductsCountDto[]>(categoriesDtoArr, "Categories");
            return result;
        }

        //Problem 8
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithProducts = context
                .Users
                .AsNoTracking()
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    users = new
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Age = u.Age,
                        SoldProducts = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                ProductName = p.Name,
                                ProductPrice = p.Price
                            })
                            .OrderByDescending(p => p.ProductPrice)
                            .ToArray(),

                    }
                })
                .ToArray()
                .OrderByDescending(u => u.users.SoldProducts.Length)
                //.Take(10)
                .ToArray();


            var usersWithProductsArr = new ExportUsersWithProductsDto
            {
                UsersCount = usersWithProducts.Length,
                Users = usersWithProducts
                    .Select(u => new UserWithProductsDto
                    {
                        FirstName = u.users.FirstName,
                        LastName = u.users.LastName,
                        Age = u.users.Age,
                        SoldProducts = new SoldProductsDto
                        {
                            Count = u.users.SoldProducts.Length,
                            Products = u.users.SoldProducts
                                .Select(p => new SoldProductDetailsDto
                                {
                                    Name = p.ProductName,
                                    Price = p.ProductPrice
                                })
                                .ToArray()
                        }
                    })
                    .Take(10)
                    .ToArray()
            };

            var options = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string result = XmlSerializerWrapper
                .Serialize<ExportUsersWithProductsDto>(usersWithProductsArr, "Users");

            return result;
        }

        //Add-on methods
        static void CreatingDatabase(ProductShopContext context)
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

        static void AddDataToDatabase(ProductShopContext context)
        {
            string inputXml = ReadDatasetFileContents("users.xml");
            string result = ImportUsers(context, inputXml);
            Console.WriteLine(result);

            inputXml = ReadDatasetFileContents("products.xml");
            result = ImportProducts(context, inputXml);
            Console.WriteLine(result);

            inputXml = ReadDatasetFileContents("categories.xml");
            result = ImportCategories(context, inputXml);
            Console.WriteLine(result);

            inputXml = ReadDatasetFileContents("categories-products.xml");
            result = ImportCategoryProducts(context, inputXml);
            Console.WriteLine(result);
        }

        private static bool IsValid(object obj)
        {
            ValidationContext validationContext = new ValidationContext(obj);
            ICollection<ValidationResult> validationResults
                = new List<ValidationResult>();

            return Validator
                .TryValidateObject(obj, validationContext, validationResults);
        }

        private static bool TryParseNullableInt(string? input, out int? val)
        {
            // TODO: Refactor as generic method
            int? outValue = null;
            if (input != null)
            {
                bool isInputValid = int
                    .TryParse(input, out int ageVal);
                if (!isInputValid)
                {
                    val = outValue;
                    return false;
                }

                outValue = ageVal;
            }

            val = outValue;
            return true;
        }

        private static string ReadDatasetFileContents(string fileName)
        {
            string xmlFileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string xmlFileText = File
                .ReadAllText(xmlFileDirPath + fileName);

            return xmlFileText;
        }

        private static void XmlCreator(string inputXml, string xmlName)
        {

            string fileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string fileSaveName = xmlName + ".xml"; //"formatted-test-results-problem-8.json";
            File.WriteAllText(fileSavePath + fileSaveName, inputXml);
        }
    }
}