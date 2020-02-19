using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace FileIO
{
    class StreamReaderTest
    {
        //belangrijkste gaan we meest gebruiken .
        static void streamkentestje() 
        {
            Console.WriteLine("**** Fun with StreamWriter / StreamReader ****\n");
            //Now read data from file.
            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader sr = File.OpenText("reminders.txt")) 
            {
                string input = null;
                while ((input = sr.ReadLine()) != null) 
                {
                    Console.WriteLine(input);
                }
            }
            Console.ReadLine();
        }
    }
}
