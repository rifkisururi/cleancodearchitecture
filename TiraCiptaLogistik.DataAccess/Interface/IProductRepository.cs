using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TiraCiptaLogistik.Core.Interface;
using TiraCiptaLogistik.Domain.Entities;

namespace TiraCiptaLogistik.DataAccess.Interface
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllDataAsync();
        Task<Product> GetByIdAsync(string productCode);
        Task<IEnumerable<Product>> FindDataAsync(Expression<Func<Product, bool>> predicate);
        Task AddDataAsync(Product data);
        Task UpdateDataAsync(Product data);
        Task DeleteDataAsync(string Id);
    }
}
