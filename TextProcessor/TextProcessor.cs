using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        string basePath = Directory.GetCurrentDirectory();

        try
        {
            File.WriteAllText(Path.Combine(basePath, "no_file.txt"), "");
            File.WriteAllText(Path.Combine(basePath, "bad_data.txt"), "");
            File.WriteAllText(Path.Combine(basePath, "overflow.txt"), "");
        }
        catch
        {
            Console.WriteLine("Не вдалося створити службові файли.");
            Console.ReadLine();
            return;
        }

        Console.ReadLine();
    }
}
