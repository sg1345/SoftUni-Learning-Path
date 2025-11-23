namespace ProductShop
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    using DTOs.Export;
    using DTOs.Import;
    using Data;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            CreatingDatabase(context);
            AddDataToDatabase(context);

            string jsonFileName = "categories-products.json";
            string jsonFileDirPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string inputJson = File.ReadAllText(jsonFileDirPath + jsonFileName);

            //string result = GetUsersWithProducts(context);
            //Console.WriteLine(result);

            //JsonTester();
            //JsonCreator();


        }

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
            string jsonFileNameUsersJson = "users.json";
            string jsonFileNameProductsJson = "products.json";
            string jsonFileNameCategoriesJson = "categories.json";
            string jsonFileNameCategoriesProductsJson = "categories-products.json";

            string jsonFileDirPath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");

            string inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameUsersJson);
            string result = ImportUsers(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameProductsJson);
            result = ImportProducts(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameCategoriesJson);
            result = ImportCategories(context, inputJson);
            Console.WriteLine(result);

            inputJson = File.ReadAllText(jsonFileDirPath + jsonFileNameCategoriesProductsJson);
            result = ImportCategoryProducts(context, inputJson);
            Console.WriteLine(result);
        }

        static void JsonCreator()
        {
            string temp = "{\"usersCount\":54,\"users\":[{\"lastName\":\"Stewart\",\"age\":39,\"soldProducts\":{\"count\":9,\"products\":[{\"name\":\"Finasteride\",\"price\":1374.01},{\"name\":\"Glyburide\",\"price\":95.1},{\"name\":\"GOONG SECRET CALMING BATH\",\"price\":742.47},{\"name\":\"EMEND\",\"price\":1365.51},{\"name\":\"Allergena\",\"price\":109.32},{\"name\":\"IOPE RETIGEN MOISTURE TWIN CAKE NO.21\",\"price\":1257.71},{\"name\":\"Fair Foundation SPF 15\",\"price\":1394.24},{\"name\":\"ESIKA\",\"price\":879.37},{\"name\":\"allergy eye\",\"price\":426.91}]}},{\"lastName\":\"Peterson\",\"age\":72,\"soldProducts\":{\"count\":7,\"products\":[{\"name\":\"Topical 60 Sec Sodium Fluoride\",\"price\":1228.84},{\"name\":\"Growing Pains\",\"price\":1077.37},{\"name\":\"Glycopyrrolate\",\"price\":1471.43},{\"name\":\"Baza Antifungal\",\"price\":1162.34},{\"name\":\"Foaming Hand Sanitizer\",\"price\":624.72},{\"name\":\"Amitriptyline Hydrochloride\",\"price\":1453.96},{\"name\":\"TYLENOL COLD MULTI-SYMPTOM DAYTIME\",\"price\":1010.81}]}},{\"firstName\":\"Gary\",\"lastName\":\"Stevens\",\"soldProducts\":{\"count\":6,\"products\":[{\"name\":\"smart sense nighttime cold and flu relief\",\"price\":1101.77},{\"name\":\"cough and sore throat\",\"price\":1482.68},{\"name\":\"PRIMAXIN\",\"price\":686.66},{\"name\":\"Pollens - Trees, Birch Mix\",\"price\":1153.54},{\"name\":\"PREMIER VALUE ALLERGY\",\"price\":1127.61},{\"name\":\"Prostate\",\"price\":716.05}]}},{\"lastName\":\"Harrison\",\"age\":18,\"soldProducts\":{\"count\":6,\"products\":[{\"name\":\"Agaricus Equisetum Special Order\",\"price\":585.93},{\"name\":\"Flumazenil\",\"price\":1151.37},{\"name\":\"Ringers\",\"price\":1054.37},{\"name\":\"pain relief\",\"price\":938.23},{\"name\":\"Ketorolac Tromethamine\",\"price\":608.18},{\"name\":\"Yellow Jacket hymenoptera venom Venomil Diagnostic\",\"price\":23.58}]}},{\"firstName\":\"Emily\",\"lastName\":\"Parker\",\"age\":41,\"soldProducts\":{\"count\":6,\"products\":[{\"name\":\"kirkland signature minoxidil\",\"price\":49.17},{\"name\":\"NEO-POLY-BAC HYDRO\",\"price\":967.32},{\"name\":\"Labetalol hydrochloride\",\"price\":436.38},{\"name\":\"Nevirapine\",\"price\":1374.72},{\"name\":\"Homeopathic Rheumatism\",\"price\":967.08},{\"name\":\"ziprasidone hydrochloride\",\"price\":628.66}]}},{\"lastName\":\"Fox\",\"age\":68,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"Wintergreen Isopropyl Alcohol\",\"price\":1397.57},{\"name\":\"Aspen\",\"price\":1046.46},{\"name\":\"Ondansetron\",\"price\":1249.76},{\"name\":\"VITALUMIERE AQUA\",\"price\":1293.09},{\"name\":\"Etodolac\",\"price\":1443.13}]}},{\"firstName\":\"Benjamin\",\"lastName\":\"Henry\",\"age\":63,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"SNORING HP\",\"price\":53.59},{\"name\":\"Phenylephrine HCl\",\"price\":459.89},{\"name\":\"Warfarin Sodium\",\"price\":770.05},{\"name\":\"AVANDAMET\",\"price\":632.08},{\"name\":\"DIPYRIDAMOLE\",\"price\":1150.67}]}},{\"firstName\":\"Nicole\",\"lastName\":\"Martinez\",\"age\":28,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"Care One Hemorrhoidal\",\"price\":932.18},{\"name\":\"Isosorbide Mononitrate\",\"price\":789.91},{\"name\":\"PANTOPRAZOLE SODIUM\",\"price\":293.89},{\"name\":\"SUMATRIPTAN SUCCINATE\",\"price\":1265.94},{\"name\":\"Acid Reducer\",\"price\":1443.51}]}},{\"firstName\":\"Joshua\",\"lastName\":\"Murray\",\"age\":41,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"Metformin Hydrochloride\",\"price\":953.99},{\"name\":\"ENBREL\",\"price\":673.97},{\"name\":\"ropinirole hydrochloride\",\"price\":103.58},{\"name\":\"Buprenorphine hydrochloride\",\"price\":391.05},{\"name\":\"Laser Block 100\",\"price\":1135.43}]}},{\"firstName\":\"Paula\",\"lastName\":\"Hill\",\"age\":74,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"Lamotrigine Extended Release\",\"price\":245.63},{\"name\":\"CLARINS Ever Matte SPF 15 - 105 Nude\",\"price\":696.06},{\"name\":\"Alcohol Free Antiseptic\",\"price\":1486.07},{\"name\":\"Warfarin Sodium\",\"price\":1379.79},{\"name\":\"Topiramate\",\"price\":578.77}]}},{\"firstName\":\"Christine\",\"lastName\":\"Gomez\",\"age\":28,\"soldProducts\":{\"count\":5,\"products\":[{\"name\":\"ORCHID SECRET PACT\",\"price\":59.53},{\"name\":\"Fexofenadine HCl and Pseudoephedrine HCI\",\"price\":73.07},{\"name\":\"Effervescent Cold Relief\",\"price\":1436.07},{\"name\":\"Gemcitabine\",\"price\":594.79},{\"name\":\"Gehwol med Lipidro\",\"price\":421.24}]}},{\"firstName\":\"Eugene\",\"lastName\":\"Stewart\",\"age\":65,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Topex\",\"price\":1258.49},{\"name\":\"Meloxicam\",\"price\":809.18},{\"name\":\"Aspirin\",\"price\":925.45},{\"name\":\"Retin-A MICRO\",\"price\":995.98}]}},{\"firstName\":\"Anna\",\"lastName\":\"Clark\",\"age\":41,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"CHAMOMILLA\",\"price\":37.97},{\"name\":\"No7 Protect and Perfect Foundation Sunscreen Broad Spectrum SPF 15 Cool Ivory\",\"price\":616.19},{\"name\":\"Benazepril Hydrochloride and Hydrochlorothiazide\",\"price\":1187.27},{\"name\":\"Ibuprofen\",\"price\":1305.96}]}},{\"firstName\":\"Carl\",\"lastName\":\"Daniels\",\"age\":59,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"SEPHORA Acne-Fighting Mattifying Moisturizer\",\"price\":1019.28},{\"name\":\"Etomidate\",\"price\":393.94},{\"name\":\"Metaxalone\",\"price\":79.94},{\"name\":\"Imipramine Hydrochloride\",\"price\":648.69}]}},{\"firstName\":\"Carl\",\"lastName\":\"Lawson\",\"age\":19,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Pleo Lat\",\"price\":720.08},{\"name\":\"LBEL Couleur Luxe Rouge Amplifier XP amplifying SPF 15\",\"price\":1069.43},{\"name\":\"DIVALPROEX SODIUM\",\"price\":1287.03},{\"name\":\"Naproxen\",\"price\":807.22}]}},{\"firstName\":\"Brenda\",\"lastName\":\"Howell\",\"age\":75,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"TERSI\",\"price\":554.91},{\"name\":\"Archangelica Eucalyptus\",\"price\":1334.91},{\"name\":\"Parsley\",\"price\":519.06},{\"name\":\"XtraCare Foam Antibacterial Hand Wash\",\"price\":1251.97}]}},{\"lastName\":\"Moreno\",\"age\":37,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Childrens Allegra Allergy\",\"price\":650.97},{\"name\":\"Amlodipine Besylate\",\"price\":122.57},{\"name\":\"Gilotrif\",\"price\":1454.77},{\"name\":\"BareMinerals Golden Tan matte\",\"price\":110.93}]}},{\"firstName\":\"Patricia\",\"lastName\":\"Cooper\",\"age\":72,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Peter Island Continous sunscreen kids\",\"price\":471.3},{\"name\":\"CARBIDOPA AND LEVODOPA\",\"price\":441.64},{\"name\":\"Fluoxetine\",\"price\":385.37},{\"name\":\"Extra Strength Pain Reliever PM\",\"price\":542.72}]}},{\"firstName\":\"Jacqueline\",\"lastName\":\"Perez\",\"age\":25,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"ROPINIROLE HYDROCHLORIDE\",\"price\":266.44},{\"name\":\"Almond\",\"price\":367.32},{\"name\":\"Allopurinol\",\"price\":518.5},{\"name\":\"Carbon Dioxide Oxygen Mixture\",\"price\":95.49}]}},{\"firstName\":\"Jeremy\",\"lastName\":\"Woods\",\"age\":20,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Smooth texture Orange flavor\",\"price\":976.65},{\"name\":\"Etoposide\",\"price\":1483.96},{\"name\":\"Allopurinol\",\"price\":336.81},{\"name\":\"ISOPROPYL ALCOHOL\",\"price\":339.48}]}},{\"firstName\":\"Fred\",\"lastName\":\"Barnes\",\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Buprenorphine hydrochloride and naloxone hydrochloride dihydrate\",\"price\":293.33},{\"name\":\"Protonix\",\"price\":466.7},{\"name\":\"Ranitidine\",\"price\":926.64},{\"name\":\"Air\",\"price\":331.53}]}},{\"firstName\":\"Chris\",\"lastName\":\"Mitchell\",\"age\":59,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Glipizide and Metformin Hydrochloride\",\"price\":953.6},{\"name\":\"Megestrol Acetate\",\"price\":976.15},{\"name\":\"Aquafresh\",\"price\":849.93},{\"name\":\"Warfarin Sodium\",\"price\":138.83}]}},{\"firstName\":\"Thomas\",\"lastName\":\"Snyder\",\"age\":40,\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"Enalapril Maleate\",\"price\":72.71},{\"name\":\"Leflunomide\",\"price\":312.85},{\"name\":\"MEDI-FIRST Non-Aspirin\",\"price\":1301.28},{\"name\":\"Echinacea Quartz Gum Support\",\"price\":570.08}]}},{\"firstName\":\"Marie\",\"lastName\":\"Williamson\",\"soldProducts\":{\"count\":4,\"products\":[{\"name\":\"XANTHIUM STRUMARIUM VAR CANADENSE POLLEN\",\"price\":1091.38},{\"name\":\"H-Rosacea Formula\",\"price\":99.74},{\"name\":\"Trihexyphenidyl Hydrochloride\",\"price\":64.88},{\"name\":\"Enchanted Moments Mistletoe Kisses Hand Sanitizer\",\"price\":384.99}]}},{\"lastName\":\"Schmidt\",\"age\":70,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Oxygen\",\"price\":1242.92},{\"name\":\"Head and Shoulders Conditioner\",\"price\":1099.59},{\"name\":\"up and up temporary minor arthritis pain relief\",\"price\":1085.78}]}},{\"firstName\":\"Brandon\",\"lastName\":\"Fuller\",\"age\":30,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Labetalol Hydrochloride\",\"price\":1345.11},{\"name\":\"Americaine\",\"price\":1165.75},{\"name\":\"CALMING DIAPER RASH\",\"price\":700.92}]}},{\"firstName\":\"Rachel\",\"lastName\":\"Johnson\",\"age\":24,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Pollens - Weeds and Garden Plants, Nettle Urtica dioica\",\"price\":782.77},{\"name\":\"Perrigo Benzoyl Peroxide\",\"price\":873.24},{\"name\":\"Amitiza\",\"price\":666.58}]}},{\"lastName\":\"Baker\",\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Prednisone\",\"price\":550.72},{\"name\":\"equaline\",\"price\":520.45},{\"name\":\"Acetic Acid\",\"price\":1060.43}]}},{\"lastName\":\"Thompson\",\"age\":46,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Clarins Paris Skin Illusion - 114 cappuccino\",\"price\":811.42},{\"name\":\"AMARANTHUS PALMERI POLLEN\",\"price\":623.16},{\"name\":\"Irbesartan and Hydrochlorothiazide\",\"price\":308.3}]}},{\"firstName\":\"Ann\",\"lastName\":\"Stevens\",\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"MEDICATED DANDRUFF\",\"price\":1351.02},{\"name\":\"Shopko Lip Treatment\",\"price\":861.42},{\"name\":\"Nighttime Sleep Aid\",\"price\":1217.11}]}},{\"firstName\":\"Christina\",\"lastName\":\"Patterson\",\"age\":63,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Myristica Argentum Sinus Relief\",\"price\":904.52},{\"name\":\"MOIST MOISTURE SKIN TONER\",\"price\":152.43},{\"name\":\"smart sense nicotine\",\"price\":1444.12}]}},{\"firstName\":\"Jonathan\",\"lastName\":\"Rodriguez\",\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"LANEIGE MYSTIC VEIL FOUNDATION\",\"price\":20.86},{\"name\":\"Pollens - Weeds and Garden Plants, Scotch Broom Cytisus scoparius\",\"price\":135.82},{\"name\":\"Butalbital, Aspirin and Caffeine\",\"price\":1010.98}]}},{\"firstName\":\"Anna\",\"lastName\":\"Parker\",\"age\":56,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"ESIKA 3-IN-1 PRO MAKE UP FOUNDATION SPF 20 BASE DE MAQUILLAJE PARA ROSTRO 3-EN-1 PRO FPS 20\",\"price\":1097.6},{\"name\":\"Leg Cramp Relief\",\"price\":1345.69},{\"name\":\"leader pain reliever\",\"price\":1179.79}]}},{\"firstName\":\"Betty\",\"lastName\":\"Ward\",\"age\":70,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Albuterol\",\"price\":108.95},{\"name\":\"Lorazepam\",\"price\":1134.96},{\"name\":\"PLANTAGO LANCEOLATA POLLEN\",\"price\":561.68}]}},{\"firstName\":\"Patricia\",\"lastName\":\"Fuller\",\"age\":36,\"soldProducts\":{\"count\":3,\"products\":[{\"name\":\"Levothyroxine Sodium\",\"price\":885.86},{\"name\":\"LV-FX\",\"price\":820.87},{\"name\":\"Budpak Hemorrhoid Anesthetic\",\"price\":1499.29}]}},{\"firstName\":\"Fred\",\"lastName\":\"Allen\",\"age\":57,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"IOPE SUPER VITAL\",\"price\":824.68},{\"name\":\"Triamterene and Hydrochlorothiazide\",\"price\":1416.59}]}},{\"firstName\":\"Clarence\",\"lastName\":\"Fowler\",\"age\":50,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Eszopiclone\",\"price\":405.03},{\"name\":\"Allopurinol\",\"price\":48.8}]}},{\"firstName\":\"Betty\",\"lastName\":\"Lawson\",\"age\":38,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Glipizide\",\"price\":621.78},{\"name\":\"Cold and Cough\",\"price\":218.14}]}},{\"lastName\":\"Bennett\",\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Clearskin\",\"price\":968.59},{\"name\":\"Pleo Ginkgo\",\"price\":613.65}]}},{\"firstName\":\"Sandra\",\"lastName\":\"Riley\",\"age\":74,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"U-max Multi BB\",\"price\":137.16},{\"name\":\"Stila Hydrating Primer Oil-Free SPF 30\",\"price\":179.28}]}},{\"firstName\":\"Nicole\",\"lastName\":\"Harris\",\"age\":43,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Azithromycin\",\"price\":813.87},{\"name\":\"Pioglitazone\",\"price\":306.56}]}},{\"firstName\":\"Amanda\",\"lastName\":\"Frazier\",\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"EPZICOM\",\"price\":895.65},{\"name\":\"Prednisone\",\"price\":1285.99}]}},{\"firstName\":\"Diana\",\"lastName\":\"Harvey\",\"age\":46,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Fosphenytoin Sodium\",\"price\":1334.06},{\"name\":\"Cefadroxil\",\"price\":1302.2}]}},{\"firstName\":\"Bonnie\",\"lastName\":\"Fox\",\"age\":18,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Strattera\",\"price\":658.54},{\"name\":\"Aspergillus repens\",\"price\":1231.42}]}},{\"lastName\":\"Cunningham\",\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"ENALAPRIL MALEATE\",\"price\":210.42},{\"name\":\"Acnezzol Base\",\"price\":710.6}]}},{\"firstName\":\"Arthur\",\"lastName\":\"Reynolds\",\"age\":32,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Alternaria alternata\",\"price\":61.24},{\"name\":\"Treatment Set TS336667\",\"price\":1466.47}]}},{\"firstName\":\"Doris\",\"lastName\":\"Cook\",\"age\":61,\"soldProducts\":{\"count\":2,\"products\":[{\"name\":\"Dawn Ultra Antibacterial Hand\",\"price\":969.86},{\"name\":\"ANXIETY/STRESS RELIEF\",\"price\":324.66}]}},{\"firstName\":\"Gloria\",\"lastName\":\"Alexander\",\"age\":61,\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"Metoprolol Tartrate\",\"price\":1405.74}]}},{\"firstName\":\"Sarah\",\"lastName\":\"Day\",\"age\":33,\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"PredniSONE\",\"price\":286.43}]}},{\"firstName\":\"Jennifer\",\"lastName\":\"Riley\",\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"Diastat\",\"price\":614.14}]}},{\"firstName\":\"Jean\",\"lastName\":\"Henry\",\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"GEMCITABINE\",\"price\":1468.11}]}},{\"firstName\":\"Billy\",\"lastName\":\"Parker\",\"age\":68,\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"CD CAPTURE TOTALE Triple Correcting Serum Foundation Wrinkles-Dark Spots-Radiance with sunscreen Broad Spectrum SPF 25 010\",\"price\":77.23}]}},{\"firstName\":\"Kathy\",\"lastName\":\"Gilbert\",\"age\":51,\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"AIR\",\"price\":581.69}]}},{\"firstName\":\"Wanda\",\"lastName\":\"Harris\",\"age\":26,\"soldProducts\":{\"count\":1,\"products\":[{\"name\":\"DAYWEAR PLUS MULTI PROTECTION TINTED MOISTURIZER\",\"price\":555.12}]}}]}";

            ;
            var parsedTemp = JsonConvert.DeserializeObject(temp);
            string prettyTemp = JsonConvert.SerializeObject(parsedTemp, Formatting.Indented);
            Console.WriteLine(prettyTemp);
            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string jsonFileSaveName = "formatted-test-results-problem-8.json";
            File.WriteAllText(jsonFileSavePath + jsonFileSaveName, prettyTemp);
        }

        static void JsonTester()
        {
            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string jsonFileSaveName = "formatted-test-results.json";
            string input = File.ReadAllText(jsonFileSavePath + jsonFileSaveName);

            Console.WriteLine($"Test results - {input.Length}");
        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ICollection<User> usersToImport = new List<User>();

            IEnumerable<ImportUsersDto> usersDtos = JsonConvert
                .DeserializeObject<ImportUsersDto[]>(inputJson)!;

            if (usersDtos != null)
            {
                foreach (var usersDto in usersDtos)
                {
                    if (!IsValid(usersDto))
                        continue;

                    bool isLastNameValid = !string.IsNullOrEmpty(usersDto.LastName);

                    if (!isLastNameValid)
                        continue;

                    User user = new User()
                    {
                        FirstName = usersDto.FirstName,
                        LastName = usersDto.LastName,
                        Age = usersDto.Age
                    };

                    usersToImport.Add(user);
                    //Console.WriteLine(user.LastName);
                }

                context.Users.AddRange(usersToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {usersToImport.Count}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ICollection<Product> productsToImport = new List<Product>();

            IEnumerable<int> existingUserIds = context
                .Users
                .AsNoTracking()
                .Select(u => u.Id)
                .ToArray();

            IEnumerable<ImportProductsDto> productsDtos = JsonConvert
                .DeserializeObject<ImportProductsDto[]>(inputJson)!;

            if (productsDtos != null)
            {
                foreach (var productsDto in productsDtos)
                {
                    if (!IsValid(productsDto))
                        continue;

                    bool isNameValid = !string.IsNullOrEmpty(productsDto.Name);
                    bool isPriceValid = decimal.TryParse(productsDto.Price, out decimal price);
                    bool isSellerIdValid = int.TryParse(productsDto.SellerId, out int sellerId);
                    bool isBuyerIdValid = int.TryParse(productsDto.BuyerId, out int buyerId);


                    if (!isNameValid)
                        continue;
                    if (!isPriceValid)
                        continue;
                    if (!isSellerIdValid && existingUserIds.Contains(sellerId))
                        continue;
                    if (!isBuyerIdValid && (existingUserIds.Contains(buyerId) && productsDto.BuyerId != null))
                        continue;


                    Product newProduct = new Product()
                    {
                        Name = productsDto.Name,
                        Price = price,
                        SellerId = sellerId,
                        BuyerId = productsDto.BuyerId != null ? buyerId : (int?)null
                    };

                    productsToImport.Add(newProduct);
                }

                context.Products.AddRange(productsToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {productsToImport.Count}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            ICollection<Category> categoriesToImport = new List<Category>();

            IEnumerable<ImportCategoriesDto> categoriesDtos = JsonConvert
                .DeserializeObject<ImportCategoriesDto[]>(inputJson)!;

            if (categoriesDtos != null)
            {
                foreach (var categoriesDto in categoriesDtos)
                {
                    if (!IsValid(categoriesDto))
                        continue;

                    bool isNameValid = !string.IsNullOrEmpty(categoriesDto.Name);

                    if (!isNameValid)
                        continue;

                    Category category = new Category()
                    {
                        Name = categoriesDto.Name
                    };

                    categoriesToImport.Add(category);
                }

                context.Categories.AddRange(categoriesToImport);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesToImport.Count}";
        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            ICollection<CategoryProduct> categoriesProductsToImport = new List<CategoryProduct>();

            IEnumerable<int> existingCategoryIds = context
                .Categories
                .AsNoTracking()
                .Select(c => c.Id)
                .ToArray();

            IEnumerable<int> existingProductIds = context
                .Products
                .AsNoTracking()
                .Select(p => p.Id)
                .ToArray();

            IEnumerable<ImportCategoryProductsDto> categoryProductsDtos = JsonConvert
                .DeserializeObject<ImportCategoryProductsDto[]>(inputJson)!;

            if (categoryProductsDtos != null)
            {
                foreach (var categoryProductsDto in categoryProductsDtos)
                {
                    if (!IsValid(categoryProductsDto))
                        continue;

                    bool isCategoryIdValid = int
                        .TryParse(categoryProductsDto.CategoryId, out int categoryId);
                    bool isProductIdValid = int
                        .TryParse(categoryProductsDto.ProductId, out int productId);

                    if (!isCategoryIdValid /*|| !existingCategoryIds.Contains(categoryId)*/)
                        continue;
                    if (!isProductIdValid /*|| !existingProductIds.Contains(productId)*/)
                        continue;

                    CategoryProduct categoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryId,
                        ProductId = productId
                    };

                    categoriesProductsToImport.Add(categoryProduct);
                }

                context.CategoriesProducts.AddRange(categoriesProductsToImport);
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
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .ToArray();

            var productsInRangeDtoArr = productsInRange
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = p.Seller
                })
                .ToArray();

            string result = JsonConvert.SerializeObject(productsInRangeDtoArr, Formatting.Indented);

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
                            ProductPrice = p.Price,
                            BuyerFirstName = p.Buyer!.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        //.OrderBy(p => p.BuyerLastName)
                        //.ThenBy(p => p.BuyerFirstName)
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToArray();

            var usersWithSoldProductsDtoArr = usersWithSoldProducts
                .Select(u => new ExportSoldProductsDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.SoldProducts
                        .Select(p => new SoldProductsDto()
                        {
                            Name = p.ProductName,
                            Price = p.ProductPrice,
                            BuyerFirstName = p.BuyerFirstName,
                            BuyerLastName = p.BuyerLastName
                        })
                        .ToList()
                }).ToArray();

            //Console.WriteLine(usersWithSoldProductsDtoArr.Length);

            string result = JsonConvert.SerializeObject(usersWithSoldProductsDtoArr, Formatting.Indented);
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
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(c => c.Product.Price),
                    TotalRevenue = c.CategoriesProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(c => c.ProductsCount)
                .ToArray();


            var categoriesDtoArr = categories
                .Select(e => new ExportCategoriesByProductsCountDto()
                {
                    Category = e.Category,
                    ProductsCount = e.ProductsCount,
                    AveragePrice = $"{e.AveragePrice:F2}",
                    TotalRevenue = $"{e.TotalRevenue:F2}"
                })
                .ToArray();

            string result = JsonConvert.SerializeObject(categoriesDtoArr, Formatting.Indented);
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
                            .ToList(),

                    }
                })
                .ToArray()
                .OrderByDescending(u => u.users.SoldProducts.Count)
                .ToArray();


            var usersWithProductsArr = new
            {
                usersCount = usersWithProducts.Length,
                users = usersWithProducts
                    .Select(u => new
                    {
                        firstName = u.users.FirstName,
                        lastName = u.users.LastName,
                        age = u.users.Age,
                        soldProducts = new
                        {
                            count = u.users.SoldProducts.Count,
                            products = u.users.SoldProducts
                                .Select(p => new
                                {
                                    name = p.ProductName,
                                    price = p.ProductPrice
                                })
                                .ToList()
                        }
                    })
                    .ToList()
            };

            var options = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            string result = JsonConvert.SerializeObject(usersWithProductsArr, options);

            return result;
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