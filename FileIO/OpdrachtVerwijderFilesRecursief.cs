using System;
using System.IO;
namespace FileIO
{
    class OpdrachtVerwijderFilesRecursief
    {
        public static void VerwijderFilesRecursief(String path)
        {
            //get all files
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);
            DirectoryInfo[] directories = dir.GetDirectories("*", SearchOption.TopDirectoryOnly);
            // get the file attributes for file or directory
            //detect whether its a directory or file
            Console.WriteLine(files.Length);
            if (directories.Length != 0)
            {
                foreach (DirectoryInfo file in directories)
                {
                    VerwijderFilesRecursief(file.FullName);
                }
            }


            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
                Console.WriteLine("File verwijderd");

            }
            Console.WriteLine($"Alle files Verwijderd , {path}");

            Directory.Delete(path);
            Console.WriteLine("Alle directories verwijderd.");

        }
    }
}
