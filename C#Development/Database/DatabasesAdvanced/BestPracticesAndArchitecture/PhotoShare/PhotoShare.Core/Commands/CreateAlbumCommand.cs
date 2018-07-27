namespace PhotoShare.Core.Commands
{
    using System;
    using System.Linq;
    using Client.Utilities;
    using Contracts;
    using Models.Enums;
    using ModelsDto;
    using Services.Contracts;
    using Utilities.Constants;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            var username = data[0];
            var albumTitle = data[1];
            var bgColor = data[2];
            var tags = data.Skip(3).ToArray();

            var usernameExist = this.userService.Exists(username);
            if (!usernameExist)
            {
                throw new ArgumentException(string.Format(Message.NotFound, "User", username));
            }

            var albumExist = this.albumService.Exists(albumTitle);
            if (!albumExist)
            {
                throw new ArgumentException(string.Format(Message.NotFound, "Album", albumTitle));
            }

            var isValidColor = Enum.TryParse(bgColor, out Color color);
            if (!isValidColor)
            {
                throw new ArgumentException(string.Format(Message.NotFound, "Color", color));
            }

            for (var i = 0; i < tags.Length; i++)
            {
                tags[i] = tags[i].ValidateOrTransform();
                var currentTag = this.tagService.Exists(tags[i]);

                if (!currentTag)
                {
                    throw new ArgumentException("Invalid Tag!");
                }
            }

            var userId = this.userService.ByUsername<UserDto>(username).Id;
            this.albumService.Create(userId, albumTitle, bgColor, tags);

            return string.Format(Message.SuccessfullyAdded, "Album", albumTitle);
        }
    }
}
