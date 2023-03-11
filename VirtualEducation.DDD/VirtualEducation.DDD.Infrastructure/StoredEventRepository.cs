using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Domain.UseCase.Gateways;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Generics;

namespace VirtualEducation.DDD.Infrastructure
{
    public class StoredEventRepository<T> : RepositoryBase<T>, IStoredEventRepository<T> where T : class
    {

        private readonly DataBaseContext dataBaseContext;
        public StoredEventRepository(DataBaseContext dbContext) : base(dbContext)
        {
            dataBaseContext = dbContext;
        }

        public async Task<List<StoredEvent>> GetEventsByAggregateId(string aggregateId)
        {
            return  dataBaseContext.StoredEvents.Where(evento => evento.AggregateId == aggregateId).ToList();

        }
    }
}
