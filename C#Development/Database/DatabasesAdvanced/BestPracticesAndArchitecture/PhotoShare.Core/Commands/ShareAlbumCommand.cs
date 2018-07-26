namespace PhotoShare.Core.Commands
{
    using System;
    using Contracts;

    public class ShareAlbumCommand : ICommand
    {
        public ShareAlbumCommand()
        {

        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            throw new NotImplementedException();
        }
    }
}
