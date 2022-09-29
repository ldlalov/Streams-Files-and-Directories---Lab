using System;
using System.IO;
using System.Linq;

namespace _06._Split__Merge_Binary_Files
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            //MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
           using(FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open))
            {
                long sourceFileLenght = sourceStream.Length;
                long partOneLenght = 0;
                long partTwoLenght = 0;
                if (sourceFileLenght % 2 !=0)
                {
                     partOneLenght = sourceFileLenght / 2 + 1;
                     partTwoLenght = sourceFileLenght - partOneLenght;
                }
                else
                {
                    partOneLenght = sourceFileLenght / 2;
                    partTwoLenght = sourceFileLenght / 2;
                }
                var buffer = new byte[sourceFileLenght];
                sourceStream.Read(buffer, 0, buffer.Length);
                using (FileStream splited1 = new FileStream(partOneFilePath, FileMode.CreateNew))
                {
                    splited1.Write(buffer, 0, (int)partOneLenght);
                }
                using (FileStream splited2 = new FileStream(partTwoFilePath, FileMode.CreateNew))
                {
                    splited2.Write(buffer, (int)partOneLenght, (int)partTwoLenght);
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            var text1 = File.ReadAllBytes(partOneFilePath);
            var text = File.ReadAllBytes(partTwoFilePath);
            File.WriteAllBytes(joinedFilePath,text1);
            File.WriteAllBytes(joinedFilePath,text);
        }
    }
}
