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
    public class SalesOrderDetailRepository : GenericRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(LogistikContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<SalesOrderDetail>> GetAllDataAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SalesOrderDetail> GetByIdAsync(Guid id)
        {
            return await GetAsync(data => data.Id == id);
        }

        public async Task<IEnumerable<SalesOrderDetail>> FindDataAsync(Expression<Func<SalesOrderDetail, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(SalesOrderDetail data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(SalesOrderDetail data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(Guid id)
        {
            await DeleteAsync(data => data.Id == id);
        }
        public async Task AddDataRangeAsync(List<SalesOrderDetail> dataList)
        {
            await AddRangeAsync(dataList);
        }
    }
}
