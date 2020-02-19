using System;
using System.Collections.Generic;
using System.Text;

namespace OefCollecties
{
    class Ship
    {
        public float lengte { get; private set; }
        public float breedte { get;private set; }
        public string naam { get; private set; }
        public Vloot vloot { get; set; }
        public Ship(float lengte,float breedte,string naam)
        {
            this.lengte = lengte;
            this.breedte = breedte;
            this.naam = naam;
        }

        public override bool Equals(object obj)
        {
            return obj is Ship ship &&
                   naam == ship.naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(naam);
        }

        public override string ToString()
        {
            string shipinfo = $" Schip {naam} heeft een breedte van : {breedte} en een lengte van {lengte}. ";
            return shipinfo ;
        }
    }
}
