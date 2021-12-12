using System;
using WiredBrainCoffee.Storage.Repositories;
using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new EmployeeRepository();
            employeeRepository.Add(new Employee { FirstName = "Lee" });
            employeeRepository.Add(new Employee { FirstName = "Vincent" });
            employeeRepository.Add(new Employee { FirstName = "Klopfers" });

            employeeRepository.Save();

            Console.ReadLine();
        }
    }
}
