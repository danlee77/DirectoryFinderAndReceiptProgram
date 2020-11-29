using System;
using System.IO;

namespace DirectoriesAndFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string repeatDirectory = "Y";

            do
            {
                Console.Write("Enter a directory path: ");
                string directoryPath = Console.ReadLine();

                Console.Write("\n");

                if (Directory.Exists(directoryPath))
                {
                    DirectoryInfo direct = new DirectoryInfo(directoryPath);
                    foreach (var file in direct.GetFiles())
                    {
                        Console.WriteLine(file.Name);
                    }
                }
                else
                {
                    Console.WriteLine("This is not a valid directory path!");
                }

                Console.Write("\nAnother directory search (Y/N)?: ");
                repeatDirectory = Console.ReadLine().ToUpper();
                Console.Write("\n");

            } while (repeatDirectory == "Y");

            Console.WriteLine("Thank you!");

            Console.ReadKey();
        }
    }
}
