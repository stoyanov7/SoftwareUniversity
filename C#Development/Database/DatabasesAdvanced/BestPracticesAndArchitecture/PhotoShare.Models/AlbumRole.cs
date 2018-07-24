namespace PhotoShare.Models
{
    using Enums;

    public class AlbumRole
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public Role Role { get; set; }
    }
}