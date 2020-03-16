using System;
using System.Collections.Generic;
using System.Text;

namespace DBOEf
{
    class Straatnaam
    {
        public Straatnaam(int ID,string straatnaam , Gemeente gemeente)
        {
            this.ID = ID;
            this.straatnaam = straatnaam;
            this.gemeente = gemeente;
        }
        public override string ToString()
        {
            return $"naam = {straatnaam}, ID = {ID}\n" + gemeente;
        }
        public int ID { get; private set; }
        public string straatnaam { get; private set; }
        public Gemeente gemeente { get; private set; }
    }
}
