using Extension;
using Repositories.Entities;
using Services;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Linq_Introduction
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = Data.GetEmployees();

            var filteredEmployees = employees.Filter(e => e.IsManager == true);
            foreach(var employee in filteredEmployees)
            {
                Console.WriteLine(employee.FirstName);    
                Console.WriteLine(employee.LastName);    
                Console.WriteLine(employee.AnnualSalary);    
                Console.WriteLine(employee.IsManager);    
            }

            List<Department> departments = Data.GetDepartments();

            // using custom method Filter
            var filteredDepartments = departments.Filter(e => e.ShortName == "HR");
            foreach (var department in filteredDepartments)
            {
                Console.WriteLine(department.ShortName);
                Console.WriteLine(department.LongName);
            }

            //using where
            var dep1 = departments.Where(e => e.LongName == "Finance");

            // using inner join 
            var joinResult = from emp in employees
                             join dept in departments
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = dept.LongName
                             };


            var averageAnnualSalary = joinResult.Average(a => a.AnnualSalary);  
            var highestAnnualSalary = joinResult.Max(a => a.AnnualSalary);
            var lowestAnnualSalary = joinResult.Min(a => a.AnnualSalary);

        }
    }
}