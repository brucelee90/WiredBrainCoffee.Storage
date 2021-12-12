using System;
namespace WiredBrainCoffee.Storage.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {this.Id}, FirstName: {FirstName}";
    }

}
