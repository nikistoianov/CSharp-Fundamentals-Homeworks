using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.OddLines
{
    class Program
    {
        static void Main()
        {
            try
            {
                string resDir = "../../../resources";
                using (StreamReader streamFile = new StreamReader(Path.Combine(resDir, "text.txt")))
                {
                    int counter = 0;
                    string line = streamFile.ReadLine();
                    while (line != null)
                    {
                        counter++;
                        if (counter % 2 == 0)
                        {
                            Console.WriteLine(line);
                        }
                        line = streamFile.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            
        }
    }
}
