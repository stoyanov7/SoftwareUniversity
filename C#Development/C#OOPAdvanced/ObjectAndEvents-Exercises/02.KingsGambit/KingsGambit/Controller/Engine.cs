namespace KingsGambit.Controller
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Models.Contracts;

    public class Engine
    {
        private bool isRunning;
        private IAttackable king;
        private readonly IList<ISoldier> army;

        public Engine()
        {
            this.isRunning = true;
            this.army = new List<ISoldier>();
        }

        public void Run()
        {
            this.king = new King(Console.ReadLine());
            var royalGuards = Console.ReadLine().Split();

            foreach (var royalGuard in royalGuards)
            {
                var guard = new RoyalGuard(royalGuard);
                this.army.Add(guard);
                this.king.UnderAttack += guard.KingUnderAttack;
            }

            var footmans = Console.ReadLine().Split();
            foreach (var footman in footmans)
            {
                var foot = new Footman(footman);
                this.army.Add(foot);
                this.king.UnderAttack += foot.KingUnderAttack;
            }

            var command = Console.ReadLine().Split();

            while (this.isRunning)
            {
                switch (command[0])
                {
                    case "Kill":
                        var soldier = this.army.FirstOrDefault(s => s.Name == command[1]);
                        this.king.UnderAttack -= soldier.KingUnderAttack;
                        this.army.Remove(soldier);
                        break;
                    case "Attack":
                        this.king.OnUnderAttack();
                        break;
                    case "End":
                        this.isRunning = false;
                        break;
                }

                command = Console.ReadLine().Split();
            }
        }
    }
}