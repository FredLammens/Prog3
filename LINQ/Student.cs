using System.Collections.Generic;

namespace LINQ
{
    public class Student
    {
        public int StudentID { get; set; }
        public int Age { get; set; }
        public string StudentName { get; set; }
        public List<Cursus> cursussen { get; set; } = new List<Cursus>();
        public override string ToString()
        {
            return $" {StudentID} | {Age} | {StudentName}";
        }
    }
}
