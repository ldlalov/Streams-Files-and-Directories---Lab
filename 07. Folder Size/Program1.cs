using System;
using System.IO;

namespace _07._Folder_Size
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    RecurseDirectory("../../../");
        //}
        private static void RecurseDirectory(string path)
        {
            long size = 0;
            Console.WriteLine(path);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                //Console.WriteLine(file);
                FileInfo fileinfo = new FileInfo(file);
                size += fileinfo.Length;

            }
            string[] dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                RecurseDirectory(dir);
            }
        }
    }
}
