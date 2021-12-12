using System;
namespace WiredBrainCoffee.Storage.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString() => $"Id: {this.Id}, FirstName: {FirstName}";
    }
}
