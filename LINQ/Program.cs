using System;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Studenten aanmaken.\n");
            IList<Student> studentList = new List<Student>() //ILISt wordt normaal gebruikt voor als je een subclasse wilt maken dat list implementeert
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18 },
                new Student() { StudentID = 2, StudentName = "Steve", Age = 15 },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25 },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 19 }
            };
            WhereCursOef.ShowFilter1(studentList);
            WhereCursOef.ShowFilter2(studentList);
            OrderingCursOef.Order1(studentList);
            OrderingCursOef.Order2(studentList);
            OrderingCursOef.Order3(studentList);
            OrderingCursOef.Order4(studentList);


        }
        public class Student
        {
            public int StudentID { get; set; }
            public int Age { get; set; }
            public string StudentName { get; set; }
            public override string ToString()
            {
                return $" {StudentID} | {Age} | {StudentName}";
            }
        }
    }
}
