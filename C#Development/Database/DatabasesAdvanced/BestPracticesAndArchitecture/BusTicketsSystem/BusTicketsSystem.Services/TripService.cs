namespace BusTicketsSystem.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data;
    using Models;

    public class TripService : ITripService
    {
        private readonly BusTicketsSystemContext context;

        public TripService(BusTicketsSystemContext context)
        {
            this.context = context;
        }

        public TModel ById<TModel>(int id)
        {
            return this.By<TModel>(x => x.Id == id)
                .SingleOrDefault();
        }

        private IEnumerable<TModel> By<TModel>(Func<Trip, bool> predicate)
        {
            return this.context
                .Trips
                .Where(predicate)
                .AsQueryable()
                .ProjectTo<TModel>();
        }
    }
}