using System;
using WiredBrainCoffee.Storage.Repositories;
using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();
            employeeRepository.Add(new Employee { FirstName = "Lee" });
            employeeRepository.Add(new Employee { FirstName = "Vincent" });
            employeeRepository.Add(new Employee { FirstName = "Klopfers" });

            employeeRepository.Save();

            var organizationRepository = new GenericRepository<Organization>();

            organizationRepository.Add(new Organization { Name = "CoffeeCarma" });
            organizationRepository.Add(new Organization { Name = "L4 Webdesign" });

            organizationRepository.Save();

            Console.ReadLine();
        }
    }
}
