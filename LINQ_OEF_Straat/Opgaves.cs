using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ_OEF_Straat
{
    class Opgaves
    {
        public void provincieAlf(List<StraatInfo> adresInfoLine) 
        {
            Console.WriteLine("Provincies alfabetisch gesorteerd.");
                var provincieAlf = adresInfoLine.GroupBy(s => s.provincie).Select(x => x.First()).OrderBy(y => y.provincie);
                foreach (var x in provincieAlf)
                {
                    Console.WriteLine(x.provincie);
                }
                Console.WriteLine("-----------------------");
        }
        public void straatVoGem(List<StraatInfo> adresInfoLine , string gemeente) 
        {
            Console.WriteLine("lijst straatnamen opgegeven gemeente");
            var straatvogem = adresInfoLine.Where(g => g.gemeente == gemeente);
            foreach (var straat in straatvogem)
            {
                Console.WriteLine(straat.straat);
            }
        }
        public void meestvorStraat(List<StraatInfo> adresInfoLine) 
        {
            Console.WriteLine("straatnaam die het meest voorkomt en druk info af gesorteerd op basis van provincie en gemeente");
            var straatNamen = adresInfoLine
                .GroupBy(g => g.straat)
                .OrderByDescending(p => p.Count())
                .First()
                .OrderBy(p => p.provincie)
                .ThenBy(g => g.gemeente);
            foreach (var straatnaam in straatNamen)
            {
                Console.WriteLine(straatnaam);
            }
        }
        public void geefaantStraat(List<StraatInfo> adresInfoLine, float aantal) 
        {
            Console.WriteLine("straatnaam die het meest voorkomt en druk info af gesorteerd op basis van provincie en gemeente");
            var straatNamen = adresInfoLine
                .GroupBy(g => g.straat)
                .Where(p => p.Count() == aantal)
                .Select(s => s.First())
                .OrderBy(p => p.straat)
                .ThenBy(g => g.gemeente);
            foreach (var straatnaam in straatNamen)
            {
                Console.WriteLine(straatnaam.straat);
            }
        }
        public void gemStraatnam(List<StraatInfo> adresInfoLine , string gemeente1 , string gemeente2) 
        {
            Console.WriteLine("gemeenschappelijke lijst van straatnamen");
            var gemeente1Namen = adresInfoLine.Where(g => g.gemeente == gemeente1);
            var gemeente2Namen = adresInfoLine.Where(g => g.gemeente == gemeente2);
            var gemeenschappelijke = gemeente1Namen.Intersect(gemeente2Namen,new StraatInfocomparer());
            foreach (var straatnaam in gemeenschappelijke)
            {
                Console.WriteLine(straatnaam.straat);
            }
        }
        public void verschStraatnam(List<StraatInfo> adresInfoLine, string gemeente) 
        {
            Console.WriteLine("straatnamen enkel voorkomend in 1e gemeente maar niet in ");
            var gemeente1Namen = adresInfoLine.Where(g => g.gemeente == gemeente);
            var gemeente2Namen = adresInfoLine.Where(g => g.gemeente != gemeente);
            var verschillende = gemeente1Namen.Except(gemeente2Namen, new StraatInfocomparer());
            foreach (var straatnaam in verschillende)
            {
                Console.WriteLine(straatnaam.straat);
            }
        }
        public void hoogsteAantalStraatNamen(List<StraatInfo> adresInfoLine) 
        {
        }
    }
}
