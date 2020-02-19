using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FileIO
{
    class DImageFiles
    {
        public static void DisplayImageFiles() 
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");// the @ is to escape the slashes
            //Get all files with a *.jpg extension
            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n",imageFiles.Length);
            //now print out info for each file.
            foreach (FileInfo f in imageFiles) 
            {
                Program.ShowWindowsDirectoryInfo(dir);   
            }
        }
    }
}
