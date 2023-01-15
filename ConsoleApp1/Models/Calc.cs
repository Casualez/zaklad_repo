using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Calc
    {
        internal decimal init(Worker worker, int hoursWorked, decimal bonus)
        {
            if (worker.WorkType.Equals("urzędnik"))
            {
                return Salary(worker, hoursWorked) + bonus;
            }
            else
            {
                return PerHour(worker, hoursWorked) + bonus;
            }
        }

        decimal Salary(Worker worker, int hoursWorked)
        {
            if (hoursWorked == 20)
            {
                return worker.Salary;
            }
            else
            {
                return worker.Salary * 0.8m;
            }
        }

        decimal PerHour(Worker worker, int hoursWorked)
        {
            return worker.PerHour * hoursWorked;
        }
    }
}
