using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TiraCiptaLogistik.Core.Interface;
using TiraCiptaLogistik.Domain.Entities;

namespace TiraCiptaLogistik.DataAccess.Interface
{

    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllDataAsync();
        Task<Customer> GetByIdAsync(string Id);
        Task<IEnumerable<Customer>> FindDataAsync(Expression<Func<Customer, bool>> predicate);
        Task AddDataAsync(Customer data);
        Task UpdateDataAsync(Customer data);
        Task DeleteDataAsync(string Id);
    }
}
