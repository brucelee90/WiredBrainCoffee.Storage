namespace WiredBrainCoffee.Storage.Entities
{
    public class Organization :EntityBase
    {
        public string? Name { get; set; }

        public override string ToString() => $"Id: {this.Id}, Name: {Name}";


    }

}
