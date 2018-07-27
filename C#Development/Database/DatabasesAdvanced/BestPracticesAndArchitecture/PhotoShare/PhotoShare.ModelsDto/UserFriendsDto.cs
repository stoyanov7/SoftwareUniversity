namespace PhotoShare.ModelsDto
{
    using System.Collections.Generic;

    public class UserFriendsDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public ICollection<FriendDto> Friends { get; set; }
    }
}
