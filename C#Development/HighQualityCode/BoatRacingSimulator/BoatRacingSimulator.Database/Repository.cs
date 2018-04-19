namespace BoatRacingSimulator.Database
{
    using System.Collections.Generic;
    using Contracts;
    using Exceptions;
    using Models.Contracts;
    using Utility;

    public class Repository<T> : IRepository<T> where T : IModelable
    {
        public Repository()
        {
            this.ItemsByModel = new Dictionary<string, T>();
        }

        protected IDictionary<string, T> ItemsByModel { get; set; }

        public virtual void Add(T item)
        {
            if (this.ItemsByModel.ContainsKey(item.Model))
            {
                throw new DuplicateModelException(Constants.DuplicateModelMessage);
            }

            this.ItemsByModel.Add(item.Model, item);
        }

        public T GetItem(string model)
        {
            if (!this.ItemsByModel.ContainsKey(model))
            {
                throw new NonExistantModelException(Constants.NonExistantModelMessage);
            }

            return this.ItemsByModel[model];
        }
    }
}