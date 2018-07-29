namespace BusTicketsSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;

    public class BusCompanyService : IBusCompanyService
    {
        private readonly BusTicketsSystemContext context;

        public BusCompanyService(BusTicketsSystemContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
        {
            return this.By<TModel>(x => x.Id == id)
                .SingleOrDefault();

        }

        public TModel ByName<TModel>(string name)
        {
            return this.By<TModel>(x => x.Name == name)
                .SingleOrDefault();
        }

        private IEnumerable<TModel> By<TModel>(Func<BusCompany, bool> predicate)
        {
            return this.context
                .BusCompanies
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
        }
    }
}