using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
namespace FileIO
{
    class BinaryWriterTest
    {
        public static void binaryWriterTestke()
        {
            Console.WriteLine("**** Fun with Binary writers ****\n");
            //Open a binary writer for a file.
            FileInfo f = new FileInfo(@"C:\Users\Biebem\Downloads\trala.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                //print out the type of BaseStream.
                //System.IO.FileStream in this case
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);
                //Create some data to save in the file.
                double aDouble = 420.69;
                int anInt = 323;
                string aString = "D,E,F";
                //write the data
                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
        public static void BinaryReadertestk()
        {
            FileInfo f = new FileInfo(@"C:\Users\Biebem\Downloads\trala.dat");
            //read binary data from stream
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.ReadLine();
        }
        public static void CreateZipFile(string fileName, IEnumerable<string> files)
        {
            //create and open a new Zip file
            var zip = ZipFile.Open(fileName, ZipArchiveMode.Create);
            foreach (var file in files)
            {
                zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
            }
            //Dispose of the object when we are done
            zip.Dispose();
        }
    }
}
