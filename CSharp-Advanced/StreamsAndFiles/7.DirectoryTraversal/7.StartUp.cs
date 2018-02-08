using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.DirectoryTraversal
{
    class Program
    {
        static void Main()
        {
            string path = Console.ReadLine();
            DirectoryReport(path);
            Console.WriteLine("OK!");
        }

        static void DirectoryReport(string path)
        {
            var files = Directory.GetFiles(path + "\\");
            //var dirs = Directory.GetDirectories(path);
            var extensionses = new Dictionary<string, Extensions>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                if (extensionses.ContainsKey(fileInfo.Extension))
                {
                    extensionses[fileInfo.Extension].Files.Add(fileInfo);
                }
                else
                {
                    extensionses[fileInfo.Extension] = new Extensions(){ Files = new List<FileInfo>() , Name = fileInfo.Extension};
                    extensionses[fileInfo.Extension].Files.Add(fileInfo);
                }
            }

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter writeFile = new StreamWriter(Path.Combine(desktop, "report.txt")))
            {
                foreach (var extensionse in extensionses.OrderByDescending(x => x.Value.Files.Count).ThenBy(x => x.Key))
                {
                    writeFile.WriteLine(extensionse.Key);
                    foreach (var fileInfo in extensionse.Value.Files.OrderBy(x => x.Length))
                    {
                        writeFile.WriteLine($"--{fileInfo.Name} - {(double)fileInfo.Length / 1024:F3}kb");
                    }
                }
            }
        }
    }

    class Extensions
    {
        public string Name { get; set; }
        public List<FileInfo> Files { get; set; }
    }
}
