namespace MishMash.Models
{
    public class UserChannel
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
    }
}