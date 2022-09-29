namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            float size = 0;
            string[] dirs = Directory.GetDirectories(folderPath);

            foreach (var dir in dirs)
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (var file in files)
                {
                    FileInfo fileinfo = new FileInfo(file);
                    size += fileinfo.Length;
                }
            }
            Console.WriteLine(size/1024);

        }
    }
}
