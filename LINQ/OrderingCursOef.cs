using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    class OrderingCursOef
    {
        public static void Order1(IList<Student> studentList)
        {
            Console.WriteLine("Order 1");
            var studentsInAscOrder = studentList.OrderBy(s => s.StudentName);
            foreach (var x in studentsInAscOrder)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("--------------------------------");
        }
        public static void Order2(IList<Student> studentList) 
        {
            Console.WriteLine("Order 2");
            var studentsInOrder = studentList.OrderByDescending(s => s.StudentName);
            foreach (var x in studentsInOrder)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("--------------------------------");
        }
        public static void Order3(IList<Student> studentList) 
        {
            Console.WriteLine("Order 3");
            var studentsInOrder = studentList.OrderBy(s => s.Age).ThenBy(s => s.StudentName);
            foreach (var x in studentsInOrder)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("--------------------------------");
        }
        public static void Order4(IList<Student> studentList) 
        {
            Console.WriteLine("Order 4");
            var studentsInOrder = studentList.OrderBy(s => s.Age).ThenBy(s => s.StudentName).Reverse();
            foreach (var student in studentsInOrder) 
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
