using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _04._Merge_Text_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text1 = File.ReadAllText("../../../input1.txt");
            string text = File.ReadAllText("../../../input2.txt");
                File.AppendAllText("../../../output.txt",text1 + text);
        }
    }
}
