using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ChangeFileName
{
    class Program
    {
        static void Main(string[] args)
        {
            const string renameFolder = "rename";//folder
            try
            {
                if (!Directory.Exists(renameFolder))
                    Directory.CreateDirectory(renameFolder);
                else
                {
                    var renameFiles = Directory.GetFiles(renameFolder);
                    foreach (var renameFile in renameFiles)
                        File.Delete(renameFile);
                }
                var filesInFolder = Directory.GetFiles(Directory.GetCurrentDirectory());
                foreach (var file in filesInFolder)
                {
                    var regex = new Regex(".png|.jpg", RegexOptions.IgnoreCase);
                    if (!regex.IsMatch(Path.GetExtension(file))) continue;
                    File.WriteAllBytes("rename/" + Path.GetFileName(file).Replace('–', '_').Replace('-', '_'),File.ReadAllBytes(file));
                    Console.WriteLine($"{Path.GetFileName(file)} successfully renamed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }
    }
}
