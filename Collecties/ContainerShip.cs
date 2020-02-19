using System;
using System.Collections.Generic;
using System.Text;

namespace OefCollecties
{
    class ContainerShip : Vrachtship
    {
        public float Capaciteit { get; private set; }
        public ContainerShip(float capaciteit, float cargoWaarde,float lengte,float breedte,string naam) : base(cargoWaarde,lengte,breedte,naam)
        {
            Capaciteit = capaciteit;
        }
        public override string ToString()
        {
            return base.ToString() + $"Deze cargowaarde heeft een capaciteit van : {Capaciteit} \n";
        }
    }
}
