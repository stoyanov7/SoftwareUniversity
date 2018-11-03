namespace MishMash.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<UserChannel> FollowedChannels { get; set; } = new List<UserChannel>();

        public RoleType Role { get; set; }
    }
}