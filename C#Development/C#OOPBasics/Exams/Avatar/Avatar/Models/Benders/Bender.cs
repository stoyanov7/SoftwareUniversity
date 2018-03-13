namespace Avatar.Models.Benders
{
    public abstract class Bender
    {
        protected Bender(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public abstract double GetBenderPower();

        public override string ToString()
        {
            var name = this.GetType().Name;
            var index = name.IndexOf("Bender");
            name = name.Insert(index, " ");

            return $"###{name}: {this.Name}, Power: {this.Power},";
        }
    }
}