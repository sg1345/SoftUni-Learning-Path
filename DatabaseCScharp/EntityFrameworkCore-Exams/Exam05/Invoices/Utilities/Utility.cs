namespace Invoices.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public static class Utility
    {
        public static class UtilityHelper
        {

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
    }
}
