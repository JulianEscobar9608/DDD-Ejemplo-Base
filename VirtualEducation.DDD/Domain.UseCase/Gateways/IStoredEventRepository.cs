using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualEducation.DDD.Domain.Generics;

namespace Domain.UseCase.Gateways
{
    public interface IStoredEventRepository<T> : IRepositoryBase<T> where T : class
    {
        Task<List<StoredEvent>> GetEventsByAggregateId(string aggregateId);
    }
}
