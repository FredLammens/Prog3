using System;
using System.Collections.Generic;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cursussen aanmeken.\n");
            IList<Cursus> c = new List<Cursus>()
            {
                new Cursus("Programmeren 1",6),
                new Cursus("Web1",3),
                new Cursus("Databanken",4),
                new Cursus("Labo",3)
            };
            Console.WriteLine("Studenten aanmaken.\n");
            IList<Student> studentList = new List<Student>() //ILISt wordt normaal gebruikt voor als je een subclasse wilt maken dat list implementeert
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18,cursussen={c[0]} },
                new Student() { StudentID = 2, StudentName = "Steve", Age = 15,cursussen ={c[1],c[2] } },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25,cursussen ={c[0],c[3],c[1] } },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 , cursussen ={c[0],c[1] } },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 19}
            };
            WhereCursOef.ShowFilter1(studentList);
            WhereCursOef.ShowFilter2(studentList);
            OrderingCursOef.Order1(studentList);
            OrderingCursOef.Order2(studentList);
            OrderingCursOef.Order3(studentList);
            OrderingCursOef.Order4(studentList);
            SelectCursOef.Select1(studentList);
            SelectCursOef.Select2(studentList);
            SelectCursOef.Select3(studentList);
            SelectCursOef.Select4(studentList);
            SelectCursOef.Select5(studentList);


        }
        public class Student
        {
            public int StudentID { get; set; }
            public int Age { get; set; }
            public string StudentName { get; set; }
            public List<Cursus> cursussen { get; set; }
            public Student()
            {
                cursussen = new List<Cursus>();
            }
            public override string ToString()
            {
                return $" {StudentID} | {Age} | {StudentName}";
            }
        }
        public class Cursus 
        {
            public string Naam { get; set; }
            public int StudiePunten { get; set; }
            public Cursus(string naam, int studiePunten) 
            {
                Naam = naam;
                StudiePunten = studiePunten;
            }
            public override string ToString()
            {
                return $" {this.Naam} | {this.StudiePunten}";
            }
        }
    }
}
