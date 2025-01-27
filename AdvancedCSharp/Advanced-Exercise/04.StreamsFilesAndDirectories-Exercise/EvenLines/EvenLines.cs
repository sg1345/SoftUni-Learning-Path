namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader inputStreamReader = new StreamReader(inputFilePath))
            {
                string result = string.Empty;
                int count = 0;
                string line = string.Empty;
                while ((line = inputStreamReader.ReadLine()) != null)
                {
                    char[] puntuations = { '-', ',', '.', '!', '?' };

                    for (int i = 0; i < line.Length; i++)
                    {
                        char character = line[i];
                        foreach (char puntuation in puntuations)
                        {
                            if (character == puntuation)
                            {
                                line = line.Remove(i, 1);
                                line = line.Insert(i, "@");
                            }
                        }
                    }

                    string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    words = words.Reverse().ToArray();


                    if (count % 2 == 0)
                    {
                        result += string.Join(' ', words) + "\n";

                    }

                    count++;
                }

                return result;
            }
        }
    }
}
