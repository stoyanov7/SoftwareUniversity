namespace PhotoShare.Services.Contracts
{
    using Models;

    public interface IPictureService
    {
        TModel ById<TModel>(int id);

        TModel ByTitle<TModel>(string pictureTitle);

        bool Exists(int id);

        bool Exists(string name);

        Picture Create(int albumId, string pictureTitle, string pictureFilePath);
    }
}
