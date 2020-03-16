using System;
using System.Collections.Generic;
using System.Text;

namespace DBOEf
{
    class Gemeente
    {
        public Gemeente(int NIScode , string gemeentenaam )
        {
            this.NIScode = NIScode;
            this.gemeentenaam = gemeentenaam;
        }
        public override string ToString()
        {
            return $"naam = {gemeentenaam}, code = {NIScode}\n";
        }

        public int NIScode { get; private set; }
        public string gemeentenaam { get; private set; }
    }
}
