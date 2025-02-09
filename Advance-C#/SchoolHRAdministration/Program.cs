using HRAdminstrationAPI.Generic;
using HRAdminstrationAPI.Implementation;
using HRAdminstrationAPI.Interface;
using System.Linq;
using static SchoolHRAdministration.Program;

namespace SchoolHRAdministration
{
    public class Program
    {
        public enum EmployeeType
        {
            Teacher,
            HeadOfDepartment,
            DeputyHeadMaster,
            HeadMaster
        }

        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();

            SeedData(employees);

            //foreach (IEmployee employee in employees)
            //{
            //    totalSalaries += employee.Salary;
            //}

            //Console.WriteLine($"Total annual salary of all employees with bonuses: {totalSalaries}");

            // using LINQ we can write the above commented code in one line
            Console.WriteLine($"Total annual salary of all employees with bonuses: {employees.Sum(e => e.Salary)}");
            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher", 1000);
            employees.Add(teacher1);

            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "James", "Smith", 2000);
            employees.Add(teacher2);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Ren", "Kawaski", 1500);
            employees.Add(headOfDepartment);

            IEmployee deputyMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Sasuke", "Uchiha", 1500);
            employees.Add(deputyMaster);

            IEmployee headMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 5, "Madara", "Uchiha", 2000);
            employees.Add(headMaster);
        }

        // If I had inherited IEmployee here than compiler will tell me to implement its prop
        // EmployeeBase acting as a middle-man, and we can still use all prop of IEmployee
        public class Teacher : EmployeeBase
        {
            // salary is marked virtual in EmployeeBase hence can be overridden
            public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
        }

        public class HeadOfDepartment : EmployeeBase
        {
            public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
        }

        public class DeputyHeadMaster : EmployeeBase
        {
            public override decimal Salary { get => base.Salary + (base.Salary * 0.04m); }
        }

        public class HeadMaster : EmployeeBase
        {
            public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
        }
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName; 
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new NullReferenceException();
            }

            return employee;
        }
    }

}
