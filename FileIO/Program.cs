using System;
using System.IO;
namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Fun with Directory(info) ****\n");
            ShowWindowsDirectoryInfo();
            Console.ReadLine();
        }

        private static void ShowWindowsDirectoryInfo()
        {
            //Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"C:\"); // the @ is to escape the slashes
            DirectoryInfo[] downloadsFolder = dir.GetDirectories("*downloads*"); // zelf testen
            Console.WriteLine("**** Directory Info ****");
            Console.WriteLine("Fullname: {0}",dir.FullName);
            Console.WriteLine("Name: {0}",dir.Name);
            Console.WriteLine("Parent: {0}",dir.Parent);
            Console.WriteLine("Creation: {0}",dir.CreationTime);
            Console.WriteLine("Attributes : {0}",dir.Attributes);
            Console.WriteLine("Root: {0}",dir.Root);
            Console.WriteLine("************************");
        }
    }
}
