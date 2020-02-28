using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class SelectCursOef
    {
        public static void Select1(IList<Student> studentList)
        {
            Console.WriteLine("---------Select 1 ---------");
            var sel = studentList.Select(s => s.StudentName);
            foreach (var x in sel) Console.WriteLine(x);
            Console.WriteLine("---------------");
        }
        public static void Select2(IList<Student> studentList)
        {
            Console.WriteLine("----------Select 2 ------------");
            var sel = studentList.Select(s => new { naam = s.StudentName, aantalCursussen = s.cursussen.Count() });
            foreach (var x in sel) Console.WriteLine(x);
            Console.WriteLine("------------------");
        }
        public static void Select3(IList<Student> studentList)
        {
            Console.WriteLine("-----------Select 3 -------------");
            var sel = studentList.SelectMany(s => s.cursussen);
            foreach (var x in sel) Console.WriteLine(x);
            Console.WriteLine("----------------");
        }
        public static void Select4(IList<Student> studentList)
        {
            Console.WriteLine("--------------Select 4 -------------");
            var sel = studentList.SelectMany(s => s.cursussen).Distinct();
            foreach (var x in sel) Console.WriteLine(x);
            Console.WriteLine("------------------");
        }
        public static void Select5(IList<Student> studentList)
        {
            Console.WriteLine("--------------Select 5--------------");
            var sel = studentList.SelectMany(s => s.cursussen,
                (student, program) => new
                {
                    studentName = student.StudentName,
                    cursusName = program
                });
            foreach (var x in sel) Console.WriteLine(x);
            Console.WriteLine("--------------------");
        }
    }
}
