namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;
    using Models.Enums;
    using ModelsDto;
    using Services.Contracts;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly IAlbumRoleService albumRoleService;

        public ShareAlbumCommand(IAlbumService albumService, IUserService userService, IAlbumRoleService albumRoleService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.albumRoleService = albumRoleService;
        }
        
        public string Execute(string[] data)
        {
            var albumId = int.Parse(data[0]);
            var username = data[1];
            var permission = data[2];
            var isValidRole = Enum.TryParse(permission, out Role role);
            
            if (!this.albumService.Exists(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            if (!this.userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (!isValidRole)
            {
                throw new AggregateException($"Permission must be either \"Owner\" or \"Viewer\"!");
            }

            var userDto = this.userService.ByUsername<UserDto>(username);
            var albumDto = this.albumService.ById<AlbumDto>(albumId);

            this.albumRoleService.PublishAlbumRole(albumId, userDto.Id, permission);

            return $"Username {username} added to album {albumDto.Name} ({permission})";
        }
    }
}
