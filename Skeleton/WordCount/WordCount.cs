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
            Dictionary<string, int> frequencies = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string[] words = reader.ReadToEnd().Split();
                using (StreamReader reader1 = new StreamReader("../../../input.txt"))
                {
                    string[] text = reader1.ReadToEnd().Split(' ', '\r', '\n', '-', ',', '.');//Will be better with Regex
                    foreach (var item in words)
                    {
                        if (!frequencies.ContainsKey(item.ToLower()))
                        {
                            frequencies.Add(item.ToLower(), 0);
                        }

                        foreach (var word in text)
                        {
                            if (word.ToLower() == item)
                            {
                                frequencies[item]++;
                            }
                        }
                    }
                }
                foreach (var item in frequencies.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

        }
    }
}
