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
    public class SalesOrderRepository : GenericRepository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(LogistikContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<SalesOrder>> GetAllDataAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SalesOrder> GetByIdAsync(string salesOrderNo)
        {
            return await GetAsync(data => data.SalesOrderNo == salesOrderNo);
        }

        public async Task<IEnumerable<SalesOrder>> FindDataAsync(Expression<Func<SalesOrder, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(SalesOrder data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(SalesOrder data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(string salesOrderNo)
        {
            await DeleteAsync(data => data.SalesOrderNo == salesOrderNo);
        }
    }
}
