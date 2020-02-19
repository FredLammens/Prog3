using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    //biggest files vinden en printen
    class FIleLookup
    {
        public static void BiggestFile(DirectoryInfo dir) { // 2 zelfde groottes tonen 
            //lijst maken van alle files in dir
            FileInfo[] lijstFiles = dir.GetFiles();
            //lijst van gesorteerde items
            SortedList<long, FileInfo> gesorteerdeFiles = new SortedList<long, FileInfo>();

            Console.WriteLine("**** Biggest Files in dir ****");
            foreach (FileInfo file in lijstFiles)
            {
                gesorteerdeFiles.Add(file.Length, file);
            }
                Console.WriteLine(gesorteerdeFiles.Values);
            Console.WriteLine("*******************************");
        }
    }
}
