using System;
using System.Collections.Generic;
using System.IO;

namespace _05._Extract_Special_Bytes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destinationDirectory = ""; // Add saving path
            string sourceFile = ""; // Add file path
            int parts = 4;
            List<string> files = new List<string> { "Part-1.txt", "Part-2.txt ", "Part-3.txt ", "Part-4.txt" };
            using (var streamReadFile = new FileStream(sourceFile, FileMode.Open))
            {
                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    // Continues to next slide
                    using (var streamCreateFile = new FileStream(files[i], FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                while ((streamReadFile.Read(buffer, 0, buffer.Length)) == buffer.Length)
                {
                    currentPieceSize += buffer.Length; streamCreateFile.Write(buffer, 0, buffer.Length);
                    if (currentPieceSize >= pieceSize) { break; }
                }
            }

                }
            }

        }
    }
}
