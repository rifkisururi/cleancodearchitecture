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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(LogistikContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetAllDataAsync()
        {
            return await GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(string code)
        {
            return await GetAsync(data => data.ProductCode == code);
        }

        public async Task<IEnumerable<Product>> FindDataAsync(Expression<Func<Product, bool>> predicate)
        {
            return await FindAsync(predicate);
        }

        public async Task AddDataAsync(Product data)
        {
            await AddAsync(data);
        }

        public async Task UpdateDataAsync(Product data)
        {
            await UpdateAsync(data);
        }

        public async Task DeleteDataAsync(string code)
        {
            await DeleteAsync(data => data.ProductCode == code);
        }
    }
}
