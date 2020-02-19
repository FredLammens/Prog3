using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace FileIO
{
    class CreateDir
    {
        static void ModifyAppDirectory() 
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            //create \MyFolder off initial directory.
            dir.CreateSubdirectory("MyFolder");
            //capture returned DirectoryInfo object.
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder2\Data");
            //prints path to ..\MyFolder2\Data.
            Console.WriteLine("New Folder is {0}",myDataFolder);
        }
    }
}
