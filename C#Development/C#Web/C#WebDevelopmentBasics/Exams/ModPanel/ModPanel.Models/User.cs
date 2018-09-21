namespace ModPanel.Models
{
    using System.Collections.Generic;
    using Enums;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public PositionType Position { get; set; }

        public bool IsApproved { get; set; }

        public bool IsAdmin { get; set; }

        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
    }
}
