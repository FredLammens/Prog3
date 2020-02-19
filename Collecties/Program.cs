using System;

namespace OefCollecties
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship shipTest = new Ship(3, 2, "shipkak");
            Ship vrachtShipTest = new Vrachtship(3, 2, 4, "vrachtschippis");
            Ship cruiseShipTest = new CruiseShip(2, 5, 77, "cruiseshipKak");
            Ship roroShipTest = new RoRoShip(45, 3, 1, 7, 3, "roroshipScheit");
            Ship ContainerShipTest = new ContainerShip(3, 4, 1, 3, "containerShipPIS");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("SCHEPEN TESTEN");
            Console.WriteLine(shipTest);
            Console.WriteLine(vrachtShipTest);
            Console.WriteLine(cruiseShipTest);
            Console.WriteLine(roroShipTest);
            Console.WriteLine(ContainerShipTest);
            Console.WriteLine("---------------------------------");
            Console.WriteLine("VLOOT TESTEN");
            Vloot vloot = new Vloot("vlootTeFuck");
            vloot.VoegSchipToe(shipTest);
            vloot.VoegSchipToe(cruiseShipTest);
            vloot.VoegSchipToe(roroShipTest);
            vloot.GeefSchepen();
            vloot.VerwijderSchip(shipTest);
            vloot.GeefSchepen();
            vloot.ZoekSchip("cruiseshipKak");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("REDERIJ TESTEN");
            Rederij umama = new Rederij("umama");
            //vloot objecten aanmaken om toe te voegen aan haven 
            Vloot vlootje1 = new Vloot("vlootje1");
            Vloot vlootje2 = new Vloot("vlootje2");
            vlootje1.VoegSchipToe(shipTest);
            Ship kaka = new Ship(2, 4, "kaka");
            Vloot vloottest = new Vloot("kaka");
            vloottest.VoegSchipToe(kaka);
            //vlootje1.VoegSchipToe(kaka);
            vlootje1.VoegSchipToe(new Ship(3, 2, "pipi"));
            vlootje2.VoegSchipToe(new Ship(2, 5, "kaka2"));
            vlootje2.VoegSchipToe(new Ship(3, 6, "botervlootje"));
            vlootje2.GeefSchepen();
            vlootje1.GeefSchepen();
            umama.VoegHavenToe(roroShipTest);
            umama.VoegHavenToe(kaka);
            umama.VoegVlootToe(vloot);
            umama.VoegVlootToe(vlootje1);
            umama.VoegVlootToe(vlootje2);
            Console.WriteLine("-----------------------");
            Console.WriteLine("alfabetisch");
            umama.GeefHavenAlfabetisch();
            umama.ToonVloten();

        }
    }
}
