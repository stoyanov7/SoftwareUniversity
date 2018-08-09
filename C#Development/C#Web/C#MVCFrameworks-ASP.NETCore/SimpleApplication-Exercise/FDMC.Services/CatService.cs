namespace FDMC.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class CatService : ICatService
    {
        private readonly FdmcContext context;

        public CatService(FdmcContext context)
        {
            this.context = context;
        }

        public Cat FindCatById(int id) => this.context.Cats.Find(id);

        public List<Cat> GetCatList() =>  this.context.Cats.ToList();

        public void AddCat(Cat newCat)
        {
            this.context.Cats.Add(newCat);
            this.context.SaveChanges();
        }
    }
}
