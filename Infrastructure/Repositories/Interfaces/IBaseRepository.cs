using SupplyRequester.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupplyRequester.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
    }
}
