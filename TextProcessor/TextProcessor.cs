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

        long sum = 0;
        int count = 0;

        for (int i = 10; i <= 29; i++)
        {
            string fileName = Path.Combine(basePath, i + ".txt");

            try
            {
                using StreamReader reader = new StreamReader(fileName);

                string line1 = reader.ReadLine();
                string line2 = reader.ReadLine();

                int a = int.Parse(line1);
                int b = int.Parse(line2);

                int product;

                try
                {
                    product = checked(a * b);
                }
                catch (OverflowException)
                {
                    File.AppendAllText(
                        Path.Combine(basePath, "overflow.txt"),
                        i + ".txt" + Environment.NewLine
                    );
                    continue;
                }

                sum += product;
                count++;
            }
            catch (FileNotFoundException)
            {
                File.AppendAllText(
                    Path.Combine(basePath, "no_file.txt"),
                    i + ".txt" + Environment.NewLine
                );
            }
            catch (FormatException)
            {
                File.AppendAllText(
                    Path.Combine(basePath, "bad_data.txt"),
                    i + ".txt" + Environment.NewLine
                );
            }
            catch (OverflowException)
            {
                File.AppendAllText(
                    Path.Combine(basePath, "bad_data.txt"),
                    i + ".txt" + Environment.NewLine
                );
            }
        }

        if (count > 0)
            Console.WriteLine("Середнє арифметичне: " + (sum / (double)count));
        else
            Console.WriteLine("Немає коректних добутків.");

        Console.ReadLine();
    }
}
