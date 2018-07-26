namespace PhotoShare.Services.Contracts
{
    using Models;

    public interface IAlbumTagService
    {
        AlbumTag AddTagTo(int albumId, int tagId);
    }
}
