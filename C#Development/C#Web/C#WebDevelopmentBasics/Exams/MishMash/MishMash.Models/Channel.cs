namespace MishMash.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Enums;

    public class Channel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public ChannelType ChannelType { get; set; }

        public IEnumerable<ChannelTag> Tags { get; set; } = new List<ChannelTag>();

        public IEnumerable<UserChannel> Followers { get; set; } = new List<UserChannel>();
    }
}
