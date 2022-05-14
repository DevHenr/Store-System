using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Employees
{
    public class Developer : Employee
    {
        public Developer() : base(3500.00)
        {
        }

        public override void IncreaseSalary() => Salary *= 5;

    }
}
