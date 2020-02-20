using System;
using System.IO;
namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("**** Fun with Directory(info) ****\n");
            //DirectoryInfo dir = new DirectoryInfo(@"C:\"); // the @ is to escape the slashes
            //ShowWindowsDirectoryInfo(dir);
            //Console.ReadLine();
            //DImageFiles.DisplayImageFiles();
            //Console.ReadLine();
            //FIleLookup.BiggestFile(dir);
            //BinaryWriterTest.binaryWriterTestke();
            //BinaryWriterTest.BinaryReadertestk();
            OpdrachtVerwijderFilesRecursief.VerwijderFilesRecursief(@"C:\Users\Biebem\Downloads\TeDeleten");
        }

        public static void ShowWindowsDirectoryInfo(DirectoryInfo dir)
        {
            //Dump directory information.
            Console.WriteLine("**** Directory Info ****");
            Console.WriteLine("Fullname: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes : {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("************************");
        }
    }
}
