using System;
using System.IO;

namespace FileIO
{
    class StreamWriterTest
    {
        static void StreamWriterTesteken()
        {
            Console.WriteLine("****Fun with streamWriter / StreamReader ****\n");
            //get a streamwriter and write string data.
            using (StreamWriter writer = File.CreateText("reminders.txt"))
            {
                writer.WriteLine("1)Vuilligheid");
                writer.WriteLine("2)Tralalal");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + "");
                }
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("Created file and wrote some thoughts...");
            Console.ReadLine();
        }
    }
}
