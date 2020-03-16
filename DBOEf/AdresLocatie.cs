using System;
using System.Collections.Generic;
using System.Text;

namespace DBOEf
{
    class AdresLocatie
    {
        public AdresLocatie(int ID, double x, double y)
        {
            this.ID = ID;
            this.x = x;
            this.y = y;
        }
        public AdresLocatie(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public int ID { get; private set; }
        public double x { get; private set; }
        public double y { get; private set; }
    }
}
