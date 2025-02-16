using Extensions;
using Repositories.Entities;
using Services;
using System.ComponentModel.Design;
using System.Net;

namespace LINQ_Queries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            // using select - Method Syntax
            var res1 = employeeList.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.AnnualSalary
            });

            foreach (var item in res1)
            {
                Console.WriteLine(item.FullName);
                Console.WriteLine(item.AnnualSalary);
            }

            Console.WriteLine("====================1====================");

            // using select with where
            var res2 = employeeList.Select(e => new
            {
                FullName = e.FirstName + " " + e.LastName,
                AnnualSalary = e.AnnualSalary
            }).Where(e => e.AnnualSalary > 20000);

            foreach (var item in res2)
            {
                Console.WriteLine(item.FullName);
                Console.WriteLine(item.AnnualSalary);
            }

            Console.WriteLine("====================2====================");

            // using from and where - Query Syntax
            var res3 = from emp in employeeList
                       where emp.AnnualSalary > 2000
                       select new
                       {
                           FullName = emp.FirstName + " " + emp.LastName,
                           AnnualSalary = emp.AnnualSalary
                       };

            foreach (var item in res3)
            {
                Console.WriteLine($"{item.FullName} {item.AnnualSalary}");
            }

            Console.WriteLine("====================3====================");

            // Query syntax get executed once we iterate over the resultant object
            var res4 = from emp in employeeList.GetHigSalariedEmployees()
                       select new
                       {
                           FullName = emp.FirstName + " " + emp.LastName,
                           AnnualSalary = emp.AnnualSalary
                       };

            // we're adding this later still it gets included in the resultant object coz of Query syntax
            employeeList.Add(new Employee
            {
                Id = 5,
                FirstName = "Asad",
                LastName = "Sayyed",
                AnnualSalary = 100000.23m,
                IsManager = true,
                DepartmentId = 2
            });

            foreach (var item in res4)
            {
                Console.WriteLine($"{item.FullName} {item.AnnualSalary}");
            }

            Console.WriteLine("====================4====================");

            // Immediate execution using ToList()
            var res5 = (from emp in employeeList.GetHigSalariedEmployees()
                        select new
                        {
                            FullName = emp.FirstName + " " + emp.LastName,
                            AnnualSalary = emp.AnnualSalary
                        }).ToList();

            // Now this won't be included in the resultant object as we're performing immediate execution
            employeeList.Add(new Employee
            {
                Id = 6,
                FirstName = "Awaiz",
                LastName = "Khan",
                AnnualSalary = 100000.23m,
                IsManager = true,
                DepartmentId = 2
            });

            foreach (var item in res5)
            {
                Console.WriteLine($"{item.FullName} {item.AnnualSalary}");
            }

            Console.WriteLine("====================5====================");

            // Join - Method Syntax
            var joinRes1 = departmentList.Join(employeeList,
                    department => department.Id,
                    employee => employee.DepartmentId,
                    (department, employee) => new
                    {
                        FullName = employee.FirstName + " " + employee.LastName,
                        AnnualSalary = employee.AnnualSalary,
                        DepartmentName = department.LongName
                    }
                );

            foreach (var item in joinRes1)
            {
                Console.WriteLine($"{item.FullName} {item.AnnualSalary} {item.DepartmentName}");
            }

            Console.WriteLine("====================6====================");

            // Join - Query Syntax
            var joinRes2 = from dept in departmentList
                           join emp in employeeList
                           on dept.Id equals emp.DepartmentId
                           select new
                           {
                               FullName = emp.FirstName + " " + emp.LastName,
                               AnnualSalary = emp.AnnualSalary,
                               DepartmentName = dept.LongName
                           };

            foreach (var item in joinRes2)
            {
                Console.WriteLine($"{item.FullName} {item.AnnualSalary} {item.DepartmentName}");
            }

            Console.WriteLine("====================7====================");

            // GroupJoin (Left Join) - Method syntax
            var joinRes3 = departmentList.GroupJoin(employeeList,
                dept => dept.Id,
                emp => emp.DepartmentId,
                (dept, emp) => new          // This tuple can consist of any variables, they are just representation of the resultant object
                {
                    Employees = emp,
                    DepartmentName = dept.LongName
                });
            
            foreach (var item in joinRes3)
            {
                Console.WriteLine($"{item.DepartmentName}");
                foreach (var item2 in item.Employees)
                {
                    Console.WriteLine($"{item2.FirstName} {item2.LastName}");
                }
            }

            Console.WriteLine("====================8====================");

            // GroupJoin (Left Join) - Query syntax
            var joinRes4 = from dept in departmentList
                           join emp in employeeList
                           on dept.Id equals emp.DepartmentId
                           into employeeGroup
                           select new
                           {
                               Employees = employeeGroup,
                               DepartmentName = dept.LongName,
                           };

            foreach (var item in joinRes4)
            {
                Console.WriteLine($"{item.DepartmentName}");
                foreach (var item2 in item.Employees)
                {
                    Console.WriteLine($"{item2.FirstName} {item2.LastName}");
                }
            }
        }
    }
}