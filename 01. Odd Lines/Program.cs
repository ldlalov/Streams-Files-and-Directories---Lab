using System;
using System.IO;

namespace _01._Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
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
