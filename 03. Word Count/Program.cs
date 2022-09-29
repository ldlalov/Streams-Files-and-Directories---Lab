using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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
                Regex regex = new Regex("[A-Za-z]*");
                using (StreamReader reader1 = new StreamReader("../../../input.txt"))
                {
                    string text1 = reader1.ReadToEnd();

                    //string[] text = reader1.ReadToEnd().Split(' ', '\r', '\n', '-', ',', '.');//Will be better with Regex
                    MatchCollection match = regex.Matches(text1);
                    foreach (var item in words)
                    {
                        if (!frequencies.ContainsKey(item.ToLower()))
                        {
                            frequencies.Add(item.ToLower(), 0);
                        }

                        foreach (var word in match)
                        {
                            if (word.ToString().ToLower() == item)
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
