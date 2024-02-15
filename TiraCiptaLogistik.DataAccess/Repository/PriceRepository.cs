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
    public class PriceRepository : GenericRepository<Price>, IPriceRepository
    {
        public PriceRepository(LogistikContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Price>> GetAllDataAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Price> GetByIdAsync(string code)
        {
            return await GetAsync(data => data.ProductCode == code);
        }

        public async Task<IEnumerable<Price>> FindDataAsync(Expression<Func<Price, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(Price data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(Price data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(string code)
        {
            await DeleteAsync(data => data.ProductCode == code);
        }
    }
}
