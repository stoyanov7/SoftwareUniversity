namespace PhotoShare.Services
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data;
    using Models;

    public class TagService : ITownService
    {
       public TModel ById<TModel>(int id)
        {
            throw new System.NotImplementedException();
        }

        public TModel ByName<TModel>(string name)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string name)
        {
            throw new System.NotImplementedException();
        }

        public Town Add(string townName, string countryName)
        {
            throw new System.NotImplementedException();
        }
    }
}
