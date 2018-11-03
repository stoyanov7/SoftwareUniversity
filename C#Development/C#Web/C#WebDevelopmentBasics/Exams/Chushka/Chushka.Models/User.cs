namespace Chushka.Models
{
    using Enums;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public RoleType Role { get; set; }
    }
}
