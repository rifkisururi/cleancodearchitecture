using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiraCiptaLogistik.Core.DatabaseContexts;
using TiraCiptaLogistik.Core.Repository;
using TiraCiptaLogistik.DataAccess.Interface;
using TiraCiptaLogistik.Domain.Entities;

namespace TiraCiptaLogistik.DataAccess.Repository
{

    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LogistikContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllDataAsync()
        {
            var data = await GetAllAsync();
            return data;
        }

        public async Task<Customer> GetByIdAsync(string customerId)
        {
            return await GetAsync(customer => customer.CustId == customerId);
        }

        public async Task<IEnumerable<Customer>> FindDataAsync(Expression<Func<Customer, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(Customer data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(Customer data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(string customerId)
        {
            await DeleteAsync(customer => customer.CustId == customerId);
        }
    }

}
