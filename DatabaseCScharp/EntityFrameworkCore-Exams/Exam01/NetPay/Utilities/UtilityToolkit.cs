using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace NetPay.Utilities
{
    public static class UtilityToolkit
    {
        public static void CreatingDatabase(DbContext context)
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

        public static void AddDataToDatabase(DbContext context, IDictionary<string,string> methodNameAndFile)
        {
            foreach(var (methodName, fileName) in methodNameAndFile) 
            {
                string inputXml = ReadDatasetFileContents(fileName);
                var method = typeof(StartUp).GetMethod(methodName,
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

                if (method == null)
                {
                    Console.WriteLine($"Method '{methodName}' not found.");
                    return;
                }

                string result = (string)method.Invoke(null, new object[] { context, inputXml })!;
                Console.WriteLine(result);
            }
        }

        //public static bool IsValid(object obj)
        //{
        //    ValidationContext validationContext = new ValidationContext(obj);
        //    ICollection<ValidationResult> validationResults
        //        = new List<ValidationResult>();

        //    return Validator
        //        .TryValidateObject(obj, validationContext, validationResults);
        //}

        public static bool TryParseNullableInt(string? input, out int? val)
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

        public static string ReadDatasetFileContents(string fileName)
        {
            string fileDirPath = Path
                .Combine(Directory.GetCurrentDirectory(), "../../../Datasets/");
            string xmlFileText = File
                .ReadAllText(fileDirPath + fileName);

            return xmlFileText;
        }

        /// <summary>
        /// The FileCreator can Create XML or JSON files from the given input string
        /// </summary>
        /// <param name="inputFile">
        /// The input data as a string. Must be JSON or XML.  
        /// </param>
        /// <param name="fileName">
        /// should include ".json" or ".xml" in the end of its name. 
        /// **Example** "format-jsonFile.json"/"format-xmlFile.xml"
        /// </param>
        public static void FileCreator(string inputFile, string fileName)
        {
            string fileSavePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/");
            string fileSaveName = fileName;
            File.WriteAllText(fileSavePath + fileSaveName, inputFile);
        }
        
        public static void FileLengthTester(string fileName, string directory)
        {
            string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), directory); //"../../../Results/"
            string input = File.ReadAllText(jsonFileSavePath + fileName);

            Console.WriteLine($"Test results - {input.Length}");
        }

        public static void JsonCreatorFromJudge(string inputJson, string jsonName)
        {
            var parsedTemp = JsonConvert.DeserializeObject(inputJson);
            string prettyJson = JsonConvert.SerializeObject(parsedTemp, Formatting.Indented);
            Console.WriteLine(prettyJson);
            
            FileCreator(prettyJson, jsonName);
        }

        public static void XmlCreatorFromJudge(string inputXml, string xmlName)
        {
            var xmlDoc = XDocument.Parse(inputXml);
            string prettyXml = xmlDoc.ToString();

            Console.WriteLine(prettyXml);
            
            FileCreator(prettyXml, xmlName);
        }
    }
}
