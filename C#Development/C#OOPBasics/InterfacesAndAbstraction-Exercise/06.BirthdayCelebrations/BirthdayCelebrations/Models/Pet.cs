namespace BirthdayCelebrations.Models
{
    using Contracts;

    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }

        public string Name { get; }

        public string Birthdate { get; }
    }
}