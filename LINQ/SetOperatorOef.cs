using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    class SetOperatorOef
    {
        IList<string> StringList1 = new List<string>() { "One", "Two", "Three", "Four", "Five" };
        IList<string> StringList2 = new List<string>() { "Four", "Five", "Six", "Seven", "Eight" };
        public void intersect() 
        {
            var result = StringList1.Intersect(StringList2);
            Console.WriteLine("-----Intersect-------------");
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
        public void union() 
        {
            var result = StringList1.Union(StringList2);
            Console.WriteLine("-------Union---------");
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }
        }
        public void except() 
        {
            var result = StringList1.Except(StringList2);
            Console.WriteLine("---------Except-----------");
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
        }
    }
}
