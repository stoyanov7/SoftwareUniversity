namespace InfernoInfinity.Factories
{
    using System;
    using System.Linq;
    using Contracts;
    using Enums;
    using Models.Gems;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string args)
        {
            var splittedArgs = args.Split().ToList();
            var clarity = (Clarity)Enum.Parse(typeof(Clarity), splittedArgs[0]);
            var type = splittedArgs[1];

            IGem gem = null;

            switch (type)
            {
                case "Ruby":
                    gem = new Ruby();
                    break;
                case "Emerald":
                    gem = new Emerald();
                    break;
                case "Amethyst":
                    gem = new Amethyst();
                    break;
            }

            var increaseStatsBy = 0;

            switch (clarity)
            {
                case Clarity.Chipped:
                    increaseStatsBy = 1;
                    break;
                case Clarity.Regular:
                    increaseStatsBy = 2;
                    break;
                case Clarity.Perfect:
                    increaseStatsBy = 5;
                    break;
                case Clarity.Flawless:
                    increaseStatsBy = 10;
                    break;
            }

            gem.Agility += increaseStatsBy;
            gem.Strenght += increaseStatsBy;
            gem.Vitality += increaseStatsBy;

            return gem;
        }
    }
}