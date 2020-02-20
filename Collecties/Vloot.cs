using System;
using System.Collections.Generic;

namespace OefCollecties
{
    class Vloot
    {
        public string naam { get; private set; }
        public HashSet<Ship> schippings { get; private set; } = new HashSet<Ship>(); // volgens prof beter dictionary
        public Rederij rederij { get; set; }
        public Vloot(string naam)
        {
            this.naam = naam;
        }
        public void VoegSchipToe(Ship schippeken)
        {
            if (schippings.Count < 2)
            {
                schippeken.vloot = this;
                schippings.Add(schippeken);
            }
            else
                Console.WriteLine("Er zitten al 2 schepen in deze vloot.");
        }
        public void VerwijderSchip(Ship schippeken)
        {
            if (schippings.Contains(schippeken))
            {
                schippeken.vloot = null;
                schippings.Remove(schippeken);
            }
            else
                Console.WriteLine("Schippeken zit niet in de vloot.");
        }
        public Ship ZoekSchip(string naam)
        {
            foreach (Ship ship in schippings)
            {
                if (ship.naam == naam)
                    return ship;
            }
            return null;
        }
        public void GeefSchepen()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Schepen van {this.naam}");
            foreach (Ship ship in schippings)
            {
                Console.WriteLine(ship.ToString());
            }
            Console.WriteLine("---------------------------");
        }

    }
}
