using System;
using WiredBrainCoffee.Storage.Repositories;
using WiredBrainCoffee.Storage.Entities;
using WiredBrainCoffee.Storage.Data;

namespace WiredBrainCoffee.Storage
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);
            
            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {

            managerRepository.Add(new Manager { FirstName = "Sara" });
            managerRepository.Add(new Manager { FirstName = "Lee" });

            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();  

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var id = 2;
            var employee = employeeRepository.GetById(id);
            Console.WriteLine($"Employee with Id {id} is {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Lee" });
            employeeRepository.Add(new Employee { FirstName = "Vincent" });
            employeeRepository.Add(new Employee { FirstName = "Klopfers" });

            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "CoffeeCarma" });
            organizationRepository.Add(new Organization { Name = "L4 Webdesign" });

            organizationRepository.Save();
        }
    }
}
