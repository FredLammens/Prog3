using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    class StudentenLijst
    {
        public static IList<Student> L = new List<Student>() //ILISt wordt normaal gebruikt voor als je een subclasse wilt maken dat list implementeert
            {
                new Student() { StudentID = 1, StudentName = "John", Age = 18,cursussen={CursusLijst.c[0]} },
                new Student() { StudentID = 2, StudentName = "Steve", Age = 15,cursussen ={ CursusLijst.c[1], CursusLijst.c[2] } },
                new Student() { StudentID = 3, StudentName = "Bill", Age = 25,cursussen ={ CursusLijst.c[0], CursusLijst.c[3], CursusLijst.c[1] } },
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 , cursussen ={ CursusLijst.c[0], CursusLijst.c[1] } },
                new Student() { StudentID = 5, StudentName = "Ron", Age = 19}
            };
    }
}
