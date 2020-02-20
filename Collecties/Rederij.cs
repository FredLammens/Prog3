using System;
using System.Collections.Generic;

namespace OefCollecties
{
    class Rederij
    {
        public string Naam { get; private set; }
        private SortedSet<Vloot> Haven = new SortedSet<Vloot>(new VlootComparer());
        public Rederij(string naam)
        {
            Naam = naam;
        }
        public void ToonVloten()
        {
            foreach (Vloot vloot in Haven)
            {
                vloot.GeefSchepen();
            }
        }
        public void PrintTotaalCargoWaarde()
        {
            float totaalCargoWaarde = 0;
            foreach (Vloot vloot in Haven)
            {
                foreach (Ship ship in vloot.schippings)
                {
                    if (ship is ContainerShip)
                    {
                        totaalCargoWaarde += ((ContainerShip)ship).CargoWaarde; // casten naar containership
                    }
                }
            }
            Console.WriteLine(totaalCargoWaarde);
        }
        public void GeefHavenAlfabetisch()
        {
            foreach (Vloot vloot in Haven)
            {
                Console.WriteLine(vloot.naam);
            }
        }
        public void VoegVlootToe(Vloot vloot)
        {
            if (Haven.Contains(vloot) != true)
                Haven.Add(vloot);
            else
                Console.WriteLine("vloot zit al in de haven");
        }
        public void VoegHavenToe(Ship ship)
        {
            if (ship.vloot != null)
                VoegVlootToe(ship.vloot);
            else
                Console.WriteLine("ship is geen deel van een haven");
        }
        public void VeranderSchipVanVloot(string naamShip, string naamVloot)
        {
            //hulpObjecten
            Vloot hulpVloot = null;//pointer naar gevonden vloot.
            Ship hulpShip = null;//pointer naar gevonden ship.
            //controleren of vloot bestaat en waar het naartoe moet
            foreach (Vloot vloot in Haven)
            {
                if (vloot.naam == naamVloot)
                    hulpVloot = vloot;
            }
            //controleren of ship bestaat en kijken door alle vloten in de haven of de ship erin zit
            foreach (Vloot vloot in Haven)
            {
                foreach (Ship ship in vloot.schippings)
                {
                    if (ship.naam == naamShip)
                        hulpShip = ship;
                }
            }
            //verwijderen uit ene vloot en toevoegen aan andere
            //verwijderen
            hulpShip.vloot.VerwijderSchip(hulpShip);
            //toevoegen
            hulpVloot.VoegSchipToe(hulpShip);
            //geef haven van schip terug
            Console.WriteLine(hulpShip.vloot.naam);
        }
    }
}
