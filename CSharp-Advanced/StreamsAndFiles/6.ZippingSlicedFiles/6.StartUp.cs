using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.ZippingSlicedFiles
{
    class Program
    {
        static void Main()
        {
            string resDir = "../../../resources";
            Slice(Path.Combine(resDir, "sliceMe.mp4"), resDir, 5);
            Assemble(new List<string> { "Part-0.mp4.gz", "Part-1.mp4.gz", "Part-2.mp4.gz", "Part-3.mp4.gz", "Part-4.mp4.gz" }, resDir);
            Console.WriteLine("OK!");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var source = new FileStream(sourceFile, FileMode.Open))
            {
                string extension = sourceFile.Substring(sourceFile.LastIndexOf(".") + 1);
                if (destinationDirectory == string.Empty)
                {
                    destinationDirectory = "./";
                }
                long pieceSize = (long)Math.Ceiling((double)source.Length / parts);
                for (int i = 0; i < parts; i++)
                {
                    long currentPieceSize = 0;
                    
                    using (var destination = new GZipStream(new FileStream(Path.Combine(destinationDirectory, $"Part-{i}.{extension}.gz"), FileMode.Create),
                        CompressionLevel.Optimal))
                    {
                        var buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            currentPieceSize += readBytes;
                            if (readBytes == 0)
                                break;

                            destination.Write(buffer, 0, readBytes);
                            if (currentPieceSize >= pieceSize)
                                break;
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            string extension = files[0].Split(new string[] { "."}, StringSplitOptions.None)[1];
            using (var destination = new FileStream(Path.Combine(destinationDirectory, "assembledMe." + extension), FileMode.Create))
            {
                var buffer = new byte[4096];
                foreach (var file in files)
                {                    
                    using (var source = new GZipStream(new FileStream(Path.Combine(destinationDirectory, file), FileMode.Open), CompressionMode.Decompress))
                    {
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                                break;

                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
            }
        }
    }
}
