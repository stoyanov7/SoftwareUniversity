namespace _05.PizzaCalories
{
    using System;
    using System.Linq;

    public class Dough
    {
        #region Modifiers
        private const double White = 1.5;
        private const double Wholegrain = 1;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1;

        private const int MinWeight = 1;
        private const int MaxWeight = 200;
        #endregion 

        private readonly string[] doughTypes = { "white", "wholegrain" };
        private readonly string[] bakingTypes = { "crispy", "chewy", "homemade" };

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough()
        {
        }

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => this.flourType;

            private set
            {
                if (!this.doughTypes.Contains(value.ToLower()) || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get => this.bakingTechnique;

            private set
            {
                if (!this.bakingTypes.Contains(value.ToLower()) || string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        public double Weight
        {
            get => this.weight;

            private set
            {
                if (value < MinWeight || value > MaxWeight)
                {
                    throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
                }

                this.weight = value;
            }
        }

        public double GetCalculateCalories() => this.CalculateCalories();

        private double CalculateCalories()
        {
            var bakingTechValue = 0.0;
            var typeValue = 0.0;

            switch (this.flourType.ToLower())
            {
                case "white":
                    typeValue = White;
                    break;
                case "wholegrain":
                    typeValue = Wholegrain;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
            }

            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechValue = Crispy;
                    break;
                case "chewy":
                    bakingTechValue = Chewy;
                    break;
                case "homemade":
                    bakingTechValue = Homemade;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
            }

            return (2 * this.Weight) * typeValue * bakingTechValue;
        }
    }
}