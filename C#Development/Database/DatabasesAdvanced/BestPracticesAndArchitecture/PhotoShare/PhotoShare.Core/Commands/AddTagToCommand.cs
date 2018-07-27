namespace PhotoShare.Core.Commands
{
    using System;
    using Client.Utilities;
    using Contracts;
    using ModelsDto;
    using Services.Contracts;

    public class AddTagToCommand : ICommand
    {
        private readonly IAlbumTagService albumTagService;
        private readonly IAlbumService albumService;
        private readonly ITagService tagService;

        public AddTagToCommand(IAlbumTagService albumTagService, IAlbumService albumService, ITagService tagService)
        {
            this.albumTagService = albumTagService;
            this.albumService = albumService;
            this.tagService = tagService;
        }

        public string Execute(string[] args)
        {
            var albumName = args[0];
            var tag = args[1].ValidateOrTransform();

            var albumExist = this.albumService.Exists(albumName);
            var tagExist = this.tagService.Exists(tag);

            if (!albumExist || !tagExist)
            {
                throw new ArgumentException("Either tag or album does not exist!");
            }

            var albumId = this.albumService.ByName<AlbumDto>(albumName).Id;
            var tagId = this.tagService.ByName<TagDto>(tag).Id;

            this.albumTagService.AddTagTo(albumId, tagId);

            return $"Tag {tag} added to album {albumName}!";
        }
    }
}
