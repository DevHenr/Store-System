using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Employees
{
    public class Analyst : Employee
    {
        public Analyst() : base(3000.00)
        {
        }

        public override void IncreaseSalary() => Salary *= 3;

    }
}
