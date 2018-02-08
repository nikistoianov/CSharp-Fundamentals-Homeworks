using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.CopyBinaryFile
{
    class Program
    {
        static void Main()
        {
            try
            {
                string resDir = "../../../resources";
                using (var source = new FileStream(Path.Combine(resDir, "copyMe.png"), FileMode.Open))
                {
                    using (var destination = new FileStream(Path.Combine(resDir, "newMe.png"), FileMode.Create))
                    {
                        var buffer = new byte[4096];
                        while (true)
                        {
                            int readBytes = source.Read(buffer, 0, buffer.Length);
                            if (readBytes == 0)
                                break;

                            destination.Write(buffer, 0, readBytes);
                        }
                    }
                }
                Console.WriteLine("File created!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
        }
    }
}
