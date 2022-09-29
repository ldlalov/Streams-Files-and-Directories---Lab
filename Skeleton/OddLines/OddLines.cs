namespace OddLines
{
using System;
    using System.IO;

    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader reader = new StreamReader("../../../input.txt");
            using (reader)
            {
                string line = reader.ReadLine();
                int row = 0;
                while (line != null)
                {
                    if (row % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    row++;
                    line = reader.ReadLine();
                }

            }
        }
    }
}
