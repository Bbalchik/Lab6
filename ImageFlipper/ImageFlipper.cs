using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab6
{
    class Program
    {
        static void Main()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            Regex imageExt = new Regex("^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            foreach (string file in files)
            {
                string ext = Path.GetExtension(file).TrimStart('.');

                if (!imageExt.IsMatch(ext))
                {
                    Console.WriteLine($"[SKIP] {file} — не картинка");
                    continue;
                }

                Console.WriteLine($"[OK]   {file} — КАРТИНКА");
            }

            Console.ReadLine();
        }
    }
}
