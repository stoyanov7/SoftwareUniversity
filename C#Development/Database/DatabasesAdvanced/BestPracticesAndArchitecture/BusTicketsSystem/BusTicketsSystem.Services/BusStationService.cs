namespace BusTicketsSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;

    public class BusStationService : IBusStationService
    {
        private readonly BusTicketsSystemContext context;

        public BusStationService(BusTicketsSystemContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
        {
            return this.By<TModel>(x => x.Id == id)
                .SingleOrDefault();
        }

        private IEnumerable<TModel> By<TModel>(Func<BusStation, bool> predicate)
        {
            return this.context
                .BusStations
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
        }
    }
}