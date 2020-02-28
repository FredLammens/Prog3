using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    class WhereCursOef
    {
        public static void ShowFilter1(IList<Program.Student> studentList) 
        {
            Console.WriteLine("Filter1");
            var filteredResult = studentList.Where(s => s.Age > 18 && s.StudentName.Length > 3);
            foreach(var std in filteredResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("--------------------------------");
        }
        public static void ShowFilter2(IList<Program.Student> studentList) 
        {
            Console.WriteLine("Filter2");
            var filteredResult = studentList.Where((s, i) =>
            {
                if (i % 2 == 0)//if it is even element
                    return true;
                return false;
            });

            foreach (var std in filteredResult)
                Console.WriteLine(std.StudentName);

            Console.WriteLine("--------------------------------");
        }
    }
}
