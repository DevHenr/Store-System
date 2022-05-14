using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Employees
{
    public abstract class Employee 
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public int Id { get; private set; }
       
        private static int ID = 1;

        public Employee(double salary)
        {
            this.Id = GenerateId();
            this.Salary = salary;
        }

        private static int GenerateId() => ID++;

        public abstract void IncreaseSalary();

    }
}
