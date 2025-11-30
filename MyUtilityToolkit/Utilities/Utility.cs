using System.Collections;
using System.Reflection;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Invoices.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    public static class Utility
    {
        public static class UtilityHelper
        {
            //public static bool IsValid(object obj)
            //{
            //    ValidationContext validationContext = new ValidationContext(obj);
            //    ICollection<ValidationResult> validationResults
            //        = new List<ValidationResult>();

            //    return Validator
            //        .TryValidateObject(obj, validationContext, validationResults);
            //}

            // ---------------------------------------
            // ENUM PARSING & VALIDATION
            // ---------------------------------------
            /// <summary>
            /// Tries to parse a string into a specified enum type.
            /// Example: "Monday" -> DayOfWeek.Monday.
            /// </summary>
            public static bool TryParseEnum<TEnum>(string input, out TEnum result) where TEnum : struct, Enum
            {
                if (Enum.TryParse(input, out TEnum parsed) && Enum.IsDefined(typeof(TEnum), parsed))
                {
                    result = parsed;
                    return true;
                }

                result = default;
                return false;
            }

            /// <summary>
            /// Checks if a string represents a valid enum value.
            /// Example: "Monday" is valid for DayOfWeek.
            /// </summary>
            public static bool IsValidEnum<TEnum>(string input) where TEnum : struct, Enum
            {
                return Enum.TryParse(input, out TEnum parsed) && Enum.IsDefined(typeof(TEnum), parsed);
            }

            /// <summary>
            /// Checks if an integer represents a valid enum value.
            /// Example: 1 is valid if the enum has a member with value 1.
            /// </summary>
            public static bool IsValidEnum<TEnum>(int value) where TEnum : struct, Enum
            {
                return Enum.IsDefined(typeof(TEnum), value);
            }

            // ---------------------------------------
            // DUPLICATE CHECKING
            // ---------------------------------------
            /// <summary>
            /// Checks if a collection contains duplicate items.
            /// Example: [1,2,2,3] -> true.
            /// </summary>
            public static bool HasDuplicates<T>(IEnumerable<T> items)
            {
                var seen = new HashSet<T>();

                foreach (var item in items)
                {
                    if (!seen.Add(item))
                    {
                        return true;
                    }
                }

                return false;
            }

            /// <summary>
            /// Counts how many times each item occurs in a collection and returns the overall duplicates count.
            /// Example: [1,2,2,3] -> 1 || [1,2,2,3,3] -> 2 || [1,2,2,2,3] -> 2
            /// </summary>
            public static int CountOccurrences(int[] items)
            {
                var seen = new Dictionary<int, int>();

                int countDuplicates = 0;

                foreach (var item in items)
                {
                    if (!seen.TryAdd(item, 1))
                    {
                        seen[item]++;
                        countDuplicates++;
                    }
                }

                return countDuplicates;
            }

            // ---------------------------------------
            // PARSING
            // ---------------------------------------
            /// <summary>
            /// Tries to parse a string into a nullable integer.
            /// Example: "123" -> 123, null -> null, "abc" -> fails.
            /// </summary>
            public static bool TryParseNullableInt(string? input, out int? val)
            {
                int? outValue = null;
                if (input != null)
                {
                    bool isInputValid = int.TryParse(input, out int parsed);
                    if (!isInputValid)
                    {
                        val = outValue;
                        return false;
                    }

                    outValue = parsed;
                }

                val = outValue;
                return true;
            }

            /// <summary>
            /// Tries to parse a string into a boolean value.
            /// Example: "true" -> true, "false" -> false.
            /// </summary>
            public static bool TryParseBool(string input, out bool result)
            {
                return bool.TryParse(input, out result);
            }

            /// <summary>
            /// Tries to parse a string into a DateTime using a single format.
            /// Example: "2025-11-29" with format "yyyy-MM-dd".
            /// </summary>
            public static bool TryParseExactDate(string input, string format, out DateTime date)
            {
                return DateTime.TryParseExact(
                    input,
                    format,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date);
            }

        }

        public static class UtilityToolkit
        {
            /// <summary>
            /// Deletes and recreates the database using the provided DbContext.
            /// Example: CreatingDatabase(context);
            /// </summary>
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

            /// <summary>
            /// Adds data to the database by invoking methods dynamically using method names and dataset files.
            /// Example: AddDataToDatabase(context, new Dictionary<string,string>{{"SeedMethod","dataset.xml"}});
            /// </summary>
            public static void AddDataToDatabase(DbContext context, IDictionary<string, string> methodNameAndFile)
            {
                foreach (var (methodName, fileName) in methodNameAndFile)
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

            /// <summary>
            /// Reads the contents of a dataset file from the Datasets directory.
            /// Example: string xml = ReadDatasetFileContents("data.xml");
            /// </summary>
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

            /// <summary>
            /// Prints the length of a file for testing purposes.
            /// Example: FileLengthTester("data.json", "../../../Results/");
            /// </summary>
            public static void FileLengthTester(string fileName, string directory)
            {
                string jsonFileSavePath = Path.Combine(Directory.GetCurrentDirectory(), directory); //"../../../Results/"
                string input = File.ReadAllText(jsonFileSavePath + fileName);

                Console.WriteLine($"Test results - {input.Length}");
            }

            /// <summary>
            /// Creates a formatted JSON file from a raw JSON string and saves it.
            /// Example: JsonCreatorFromJudge(rawJson, "pretty.json");
            /// </summary>
            public static void JsonCreatorFromJudge(string inputJson, string jsonName)
            {
                var parsedTemp = JsonConvert.DeserializeObject(inputJson);
                string prettyJson = JsonConvert.SerializeObject(parsedTemp, Formatting.Indented);
                Console.WriteLine(prettyJson);

                FileCreator(prettyJson, jsonName);
            }

            /// <summary>
            /// Creates a formatted XML file from a raw XML string and saves it.
            /// Example: XmlCreatorFromJudge(rawXml, "pretty.xml");
            /// </summary>
            public static void XmlCreatorFromJudge(string inputXml, string xmlName)
            {
                var xmlDoc = XDocument.Parse(inputXml);
                string prettyXml = xmlDoc.ToString();

                Console.WriteLine(prettyXml);

                FileCreator(prettyXml, xmlName);
            }
        }
    }
}
