﻿namespace P03_FootballBetting.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User() => this.Bets = new List<Bet>();

        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}