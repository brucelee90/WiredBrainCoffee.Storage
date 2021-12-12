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
            var itemAdded = new ItemAdded(EmployeeAdded);
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext(), itemAdded);
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);
            
            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeAdded(object item)
        {
            var employee = (Employee)item;
            Console.WriteLine($"Employee added {employee.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {

            var saraManager = new Manager { FirstName = "Sara" };
            var saraManagerCopy = saraManager.Copy();
            managerRepository.Add(saraManager);

            if (saraManagerCopy != null)
            {
                saraManagerCopy.FirstName += "_Copy";
                managerRepository.Add(saraManagerCopy);
            }

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
            var employees = new[]
            {
                new Employee { FirstName = "Lee" },
                new Employee { FirstName = "Vincent" },
            };

            employeeRepository.AddBatch(employees);

        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {

            var organizations = new[]
            {
                new Organization { Name = "L4 Webdesign" },
                new Organization { Name = "L4 Webdesign" }
            };

            organizationRepository.AddBatch(organizations);
            organizationRepository.Save();
        }
    }
}
