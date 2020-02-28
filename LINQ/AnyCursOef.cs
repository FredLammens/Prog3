using System.Linq;

namespace LINQ
{
    class AnyCursOef
    {
        public static void IsAllAny() 
        {
            bool areAllStudentsTeenager = StudentenLijst.L.All(s => s.Age > 12 && s.Age < 20);
            System.Console.WriteLine(areAllStudentsTeenager);
            bool isAnyStudentTeenager = StudentenLijst.L.Any(s => s.Age > 12 && s.Age > 20);
            System.Console.WriteLine(isAnyStudentTeenager);
        }
    }
}
