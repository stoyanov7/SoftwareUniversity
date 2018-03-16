namespace Minedraft.Models
{
    public abstract class Unit
    {
        protected Unit(string id) => this.Id = id;

        public string Id { get; private set; }

        public abstract string Type { get; }
    }
}