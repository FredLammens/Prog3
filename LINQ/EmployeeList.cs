using System.Collections.Generic;

namespace LINQ
{
    class EmployeeList
    {
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>()
        {
        new Employee { ID = 1, Name = "Jan", AddressID = 1, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Bert", AddressID = 2, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Kaan", AddressID = 3, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Jasper", AddressID = 4, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Artuur", AddressID = 5, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Elien", AddressID = 6, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Lisa", AddressID = 7, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Simon", AddressID = 8, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Fred", AddressID = 9, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Nick", AddressID = 10, DepartmentID = 10 },
        new Employee { ID = 1, Name = "Vinnie", AddressID = 11, DepartmentID = 10 },
        };
        }
    }

}
