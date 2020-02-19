using System;
using System.Collections.Generic;
using System.Text;

namespace OefCollecties
{
     class Vrachtship : Ship
    {
       public float CargoWaarde { get; private set; }
        public Vrachtship(float cargoWaarde ,float lengte,float breedte,string naam) : base(lengte,breedte,naam)
        {
            CargoWaarde = cargoWaarde;
        }
        public override string ToString()
        {
            return base.ToString() + $"Het heeft ook een cargowaarde van {CargoWaarde}.";
        }
    }
}
