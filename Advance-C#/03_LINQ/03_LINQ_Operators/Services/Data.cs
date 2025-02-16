using Repositories.Entities;
using System;
using System.Collections;
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
                DepartmentId = 3,   
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 2,
                FirstName = "Jana",
                LastName = "Fox",
                AnnualSalary = 2220.12m,
                IsManager = false,
                DepartmentId = 1,
            };
            employees.Add(employee);

            employee = new Employee
            {
                Id = 3,
                FirstName = "Yogesh",
                LastName = "Mittal",
                AnnualSalary = 223.34m,
                IsManager = false,
                DepartmentId = 3,
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

        public static ArrayList GetHetreogenousDataCollection()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(100);
            arrayList.Add("Bob James");
            arrayList.Add(1000);
            arrayList.Add(2000);
            arrayList.Add(new Employee { Id = 6, FirstName = "Jackie", LastName = "Chan", AnnualSalary = 13032, IsManager = false, DepartmentId = 1 });
            arrayList.Add(new Employee { Id = 6, FirstName = "Naruto", LastName = "Uzumaki", AnnualSalary = 65743, IsManager = true, DepartmentId = 2 });
            arrayList.Add(new Department { Id = 4, ShortName = "LO", LongName = "Logistics" });
            arrayList.Add(new Department { Id = 5, ShortName = "BA", LongName = "Banking" });

            return arrayList;
        }

    }
}
