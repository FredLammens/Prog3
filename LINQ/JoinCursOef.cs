using System.Linq;

namespace LINQ
{
    class JoinCursOef
    {
        public void Join()
        {
            System.Console.WriteLine("-------------------------");
            var JoinUsingMS = EmployeeList.GetAllEmployees()//Outer Data Source
                .Join(
                AddressList.GetAllAddresses(), //Inner Data Source
                employee => employee.AddressID, //Inner Key Selector
                address => address.ID, //Outer Key Selector
                (employee, address) => new //Projecting data into result
                {
                    EmployeeName = employee.Name,
                    address.AddressLine
                }
                ).ToList();
            foreach (var employee in JoinUsingMS)
            {
                System.Console.WriteLine($"Name: {employee.EmployeeName}, Address :{employee.AddressLine}");
            }
            System.Console.WriteLine("------------------------------------");
        }
        public void groupJoin()
        {
            System.Console.WriteLine("------------------------------------");
            var GroupJoinMs = Department.GetAllDepartments().GroupJoin(
                EmployeeList.GetAllEmployees(),
                dept => dept.ID,
                emp => emp.DepartmentID,
                (dept, emp) => new { dept, emp });
            //print result set
            //outer foreach is for all department
            foreach (var item in GroupJoinMs)
            {
                System.Console.WriteLine("Department :" + item.dept.Name);
                //Inner foreach loop for each employee of a department
                foreach (var employee in item.emp)
                {
                    System.Console.WriteLine($"EmployeeId : {employee.ID}, Name : {employee.Name}");
                }
            }
        }
    }
}
