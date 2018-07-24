namespace PhotoShare.Models
{
    using System.Collections.Generic;
    using Enums;

    public class Album
    {
        public Album()
        {
            this.AlbumRoles = new HashSet<AlbumRole>();
            this.Pictures = new HashSet<Picture>();
            this.AlbumTags = new HashSet<AlbumTag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public Color? BackgroundColor { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<AlbumRole> AlbumRoles { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<AlbumTag> AlbumTags { get; set; }
    }
}
