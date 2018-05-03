namespace P02_DatabaseFirst.Data.Models
{
    using System.Collections.Generic;

    public class Town 
    {
        public Town() => this.Addresses = new HashSet<Address>();

        public int TownId { get; private set; }

        public string Name { get; private set; }

        public ICollection<Address> Addresses { get; private set; }
    }
}
