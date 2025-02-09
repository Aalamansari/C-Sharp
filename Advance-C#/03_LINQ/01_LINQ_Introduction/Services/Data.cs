using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Janes",
                AnnualSalary = 4000.12m,
                IsManager = true,   
                DepartmentId = 1,   
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Jana",
                LastName = "Fox",
                AnnualSalary = 2220.12m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Yogesh",
                LastName = "Mittal",
                AnnualSalary = 223.34m,
                IsManager = false,
                DepartmentId = 2,
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Smith",
                AnnualSalary = 40492.4m,
                IsManager = true,
                DepartmentId = 2,
            };
            employees.Add(employee);

            return employees;   
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();
            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);

            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);

            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }
    }
}
