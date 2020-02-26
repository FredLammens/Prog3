using System;

namespace FILIO_Oef_Straat
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Welkom bij de csv bestanden verwerker-------------");
            Console.WriteLine("Geef het pad op waar het zip bestand zich bevindt :");
            string path = Console.ReadLine();//controle moet hier nog op 
            BackEndClasses.Dataverwerker(path);
        }
    }
}
