using System;
using System.IO;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string resDir = "../../../resources";
                using (StreamWriter writeFile = new StreamWriter(Path.Combine(resDir, "output.txt")))
                {
                    using (StreamReader readFile = new StreamReader(Path.Combine(resDir, "text.txt")))
                    {
                        int counter = 0;
                        string line = readFile.ReadLine();
                        while (line != null)
                        {
                            counter++;
                            writeFile.WriteLine($"Line {counter}: {line}");
                            line = readFile.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }                  
        }
    }
}
