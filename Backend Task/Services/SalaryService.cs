using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class SalaryService : ISalaryService
    {
        private const double INCOME_TAX = 10;
        private const double SOCIAL_CONTRIB = 15;
        private const double TAX_FREE_SALARY = 1000;
        private const double MAXIMUM_TAXABLE_INCOME = 3000;
        public double CalculateSalary(double grossSalary)
        {
            if (grossSalary <= 1000)
            {
                return grossSalary;
            }
            else
            {
                var salaryToTax = grossSalary - TAX_FREE_SALARY;
                var incomeTax = salaryToTax * INCOME_TAX / 100;
                var socialContrib = (MAXIMUM_TAXABLE_INCOME - TAX_FREE_SALARY) * (SOCIAL_CONTRIB / 100);

                var netSalary = grossSalary - (incomeTax + socialContrib);
                return netSalary;
            }
        }
    }
}
