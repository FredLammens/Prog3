using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace FileIO
{
    class DriveInfos
    {
        public static void PrintDriveInfo() 
        {
            //get info regarding all drives
            DriveInfo[] myDrives = DriveInfo.GetDrives();
            //now print drive stats.
            foreach (DriveInfo drive in myDrives)
            {
                Console.WriteLine("Name: {0}",drive.Name);
                Console.WriteLine("Type: {0}",drive.DriveType);
                Console.WriteLine("FreeSpace: {0}",drive.TotalFreeSpace);
                //check to see wheter the drive is mounted 
                if (drive.IsReady) {
                    Console.WriteLine("Free space: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", drive.DriveFormat);
                    Console.WriteLine("Label: {0}",drive.VolumeLabel);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
