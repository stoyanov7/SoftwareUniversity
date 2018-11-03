namespace MishMash.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<ChannelTag> ChannelTags { get; set; } = new List<ChannelTag>();
    }
}