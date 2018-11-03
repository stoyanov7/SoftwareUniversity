namespace MishMash.Models
{
    public class ChannelTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}