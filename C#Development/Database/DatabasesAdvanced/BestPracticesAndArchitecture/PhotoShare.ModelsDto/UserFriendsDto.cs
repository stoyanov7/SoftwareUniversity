namespace PhotoShare.ModelsDto
{
    using System.Collections.Generic;

    public class UserFriendsDto
    {
        public string Username { get; set; }

        public ICollection<FriendDto> Friends { get; set; }
    }
}
