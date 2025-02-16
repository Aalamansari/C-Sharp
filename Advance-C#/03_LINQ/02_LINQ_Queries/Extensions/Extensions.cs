using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Extensions
    {
        public static IEnumerable<Employee> GetHigSalariedEmployees(this IEnumerable<Employee> employees)
        {
            foreach(Employee employee in employees)
            {
                Console.WriteLine($"Accessing employees: {employee.FirstName + " " + employee.LastName}");
                if(employee.AnnualSalary >= 20000)
                    yield return employee;
            } 
                
        }
    }
}
