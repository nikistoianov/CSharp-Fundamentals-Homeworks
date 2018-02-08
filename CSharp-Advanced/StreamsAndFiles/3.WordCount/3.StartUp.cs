using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.WordCount
{
    class Program
    {
        static void Main()
        {
            try
            {
                string resDir = "../../../resources";
                using (StreamWriter writeFile = new StreamWriter(Path.Combine(resDir, "result.txt")))
                {
                    var allWords = new Dictionary<string, int>();
                    string allText = "";

                    using (StreamReader readFile = new StreamReader(Path.Combine(resDir, "words.txt")))
                    {
                        var arr = readFile.ReadToEnd().Split(new string[] { Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var line in arr)
                        {
                            allWords[line] = 0;
                        }
                    }
                    using (StreamReader readFile = new StreamReader(Path.Combine(resDir, "text.txt")))
                    {
                        allText = readFile.ReadToEnd().ToLower();
                        string[] words = Regex.Split(allText, @"\W+");
                        foreach (var word in words)
                        {
                            if (allWords.ContainsKey(word))
                            {
                                allWords[word]++;
                            }
                        }
                    }

                    foreach (var word in allWords.OrderByDescending(x => x.Value))
                    {
                        writeFile.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
                Console.WriteLine("OK!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
