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

    public class SalesOrderInterfaceRepository : GenericRepository<SalesOrderInterface>, ISalesOrderInterfaceRepository
    {
        public SalesOrderInterfaceRepository(LogistikContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<SalesOrderInterface>> GetAllDataAsync()
        {
            return await GetAllAsync();
        }

        public async Task<SalesOrderInterface> GetByIdAsync(string salesOrderNo)
        {
            return await GetAsync(data => data.SalesOrderNo == salesOrderNo);
        }

        public async Task<IEnumerable<SalesOrderInterface>> FindDataAsync(Expression<Func<SalesOrderInterface, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(SalesOrderInterface data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(SalesOrderInterface data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(string salesOrderNo)
        {
            await DeleteAsync(data => data.SalesOrderNo == salesOrderNo);
        }
    }
}
