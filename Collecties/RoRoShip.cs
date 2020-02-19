using System;
using System.Collections.Generic;
using System.Text;

namespace OefCollecties
{
    class RoRoShip : Vrachtship
    {
        public int NrAutos { get; private set;}
        public int NrTrucks { get; private set;}
        public RoRoShip(int nrAutos,int nrTrucks,float cargoWaarde,float lengte,float breedte, string naam) : base(cargoWaarde,lengte,breedte,naam)
        {
            NrAutos = nrAutos;
            NrTrucks = nrTrucks;
        }
        public override string ToString()
        {
            return base.ToString() + $"Deze cargowaarde bestaat uit : {NrAutos} auto's en {NrTrucks} trucks.\n";
        }

    }
}
