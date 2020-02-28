using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    class CursusLijst 
    {
        public static IList<Cursus> c = new List<Cursus>()
            {
                new Cursus("Programmeren 1",6),
                new Cursus("Web1",3),
                new Cursus("Databanken",4),
                new Cursus("Labo",3)
            };
    }
}
