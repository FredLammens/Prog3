using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class FiLaTaSkEl
    {
        public static void ElementAt(IList<Student> studentList)
        {
            Console.WriteLine(studentList.ElementAt(1));
            Console.WriteLine(studentList.ElementAt(4));
            Console.WriteLine(studentList.ElementAtOrDefault(1));
            Console.WriteLine(studentList.ElementAtOrDefault(7));
            //Console.WriteLine(studentList.ElementAt(7)) ;
        }
        public static void FirstLast(IList<Student> studentList)
        {
            Console.WriteLine(studentList.First());
            Console.WriteLine(studentList.First(x => x.Age > 20));
            Console.WriteLine(studentList.Last());
            Console.WriteLine(studentList.Last(x => x.Age > 19));

        }
        public static void Take(IList<Student> studentList)
        {
            foreach (var x in studentList.Take(2))
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("---------------------");
            foreach (var x in studentList.TakeWhile(s => s.StudentName.Length > 3))
            {
                Console.WriteLine(x);
            }
        }
        public static void Skip(IList<Student> studentList)
        {
            foreach (var x in studentList.Skip(1))
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("-----------------");
            foreach (var x in studentList.SkipWhile(s => s.Age < 20))
            {
                Console.WriteLine(x);
            }
        }

    }
}
