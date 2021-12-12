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
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);
            
            var organizationRepository = new GenericRepository<Organization>();
            AddOrganizations(organizationRepository);

            Console.ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> employeeRepository)
        {
            var id = 2;
            var employee = employeeRepository.GetById(id);
            Console.WriteLine($"Employee with Id {id} is {employee.FirstName}");
        }

        private static void AddEmployees(GenericRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Lee" });
            employeeRepository.Add(new Employee { FirstName = "Vincent" });
            employeeRepository.Add(new Employee { FirstName = "Klopfers" });

            employeeRepository.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "CoffeeCarma" });
            organizationRepository.Add(new Organization { Name = "L4 Webdesign" });

            organizationRepository.Save();
        }
    }
}
