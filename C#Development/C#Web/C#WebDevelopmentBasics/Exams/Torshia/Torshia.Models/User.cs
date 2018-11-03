namespace Torshia.Models
{
    using Torshia.Models.Enums;

    public class User : BaseModel<int>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }
    }
}