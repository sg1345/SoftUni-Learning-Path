namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (var words = new StreamReader(wordsFilePath))
            {
                Dictionary<string, int> wordsPath = words.ReadToEnd()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToDictionary(x => x, x => 0);

                using (var reader = new StreamReader(textFilePath))
                {
                    string line = reader.ReadLine();

                    using (var writer = new StreamWriter(outputFilePath))
                    {

                        while (line != null)
                        {
                            char[] punktuations = { ',', '.', '!', '?', '-', ':', ';' };

                            for (int i = 0; i < line.Length; i++)
                            {
                                char character = line[i];
                                foreach (char punktuation in punktuations)
                                {
                                    if (character == punktuation)
                                    {
                                        line = line.Remove(i, 1);
                                        line = line.Insert(i, " ");
                                    }
                                }
                            }

                            string[] wordsInLine = line.ToLower()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(x => x.Trim())
                                .ToArray();
                            
                            foreach (string word in wordsInLine)
                            {
                                foreach (var (wordToMatch, count) in wordsPath)
                                {
                                    if (wordToMatch == word)
                                    {
                                        wordsPath[word]++;
                                    }
                                }
                            }


                            line = reader.ReadLine();
                        }

                        foreach (var (word, count) in wordsPath)
                        {
                            writer.WriteLine($"{word} - {count}");
                        }
                    }
                }
            }
        }
    }
}
