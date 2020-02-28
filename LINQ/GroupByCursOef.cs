using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    class GroupByCursOef
    {
        public static void group1(IList<Student> studentList) 
        {
            Console.WriteLine("------group 1--------");
            var groupedResult = studentList.GroupBy(s => s.Age);
            Console.WriteLine(groupedResult.GetType());
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine("Age Group: {0}" , ageGroup.Key);//each group has a key
                foreach (Student student in ageGroup)//each group has an inner collection
                {
                    Console.WriteLine($"Student Name: {student.StudentName}");
                }
            }
            Console.WriteLine("----------------------");
        }
        public static void group2(IList<Student> studentList)
        {
            Console.WriteLine("------group 2--------");
            var groupedResult = studentList.ToLookup(s => s.Age);
            Console.WriteLine(groupedResult.GetType());
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine($"Age Group: {ageGroup.Key}"); //each group has a key
                foreach (Student student in ageGroup)//each group has an inner collection
                {
                    Console.WriteLine($"Student name: {student.StudentName}");
                }
                Console.WriteLine("--------------------");
            }
        }
        public static void group3(IList<Student> studentList)
        {
            Console.WriteLine("------group 3--------");
            var groupedResult = studentList.GroupBy(s => new { s.Age, s.StudentName });
            Console.WriteLine(groupedResult.GetType());
            foreach (var ageGroup in groupedResult)
            {
                Console.WriteLine($"Age group: {ageGroup.Key}");//Each group has a key
                foreach (Student student in ageGroup)
                {
                    Console.WriteLine($"Student Name: {student.StudentName}");
                }
            }
            Console.WriteLine("----------------");
        }

    }
}
