namespace PhotoShare.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Models;
    using Contracts;

    public class PictureService : IPictureService
    {
        private readonly PhotoShareContext context;

        public PictureService(PhotoShareContext context) => this.context = context;

        public TModel ById<TModel>(int id)
        {
            return this.By<TModel>(a => a.Id == id)
                       .SingleOrDefault();
        }

        public TModel ByTitle<TModel>(string name)
        {
            return this.By<TModel>(a => a.Title == name)
                       .SingleOrDefault();
        }

        public bool Exists(int id) => this.ById<Picture>(id) != null;

        public bool Exists(string name) => this.ByTitle<Picture>(name) != null;

        public Picture Create(int albumId, string pictureTitle, string pictureFilePath)
        {
            var picture = new Picture
            {
                Title = pictureTitle,
                Path = pictureFilePath,
                AlbumId = albumId
            };

            this.context.Pictures.Add(picture);
            this.context.SaveChanges();

            return picture;
        }

        private IEnumerable<TModel> By<TModel>(Func<Picture, bool> predicate)
        {
            return this.context
                .Pictures
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
        }
    }
}
