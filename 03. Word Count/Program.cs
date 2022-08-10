using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
                                Dictionary<string, int> frequencies = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
               string[] words = reader.ReadToEnd().Split();
                using (StreamReader reader1 = new StreamReader("../../../input.txt"))
                {
                    string[] text = reader1.ReadToEnd().Split(' ', '\r','\n', '-',',','.');//Will be better with Regex
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
