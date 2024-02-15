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
    
    public interface IPriceRepository : IGenericRepository<Price>
    {
        Task<IEnumerable<Price>> GetAllDataAsync();
        Task<Price> GetByIdAsync(string productCode);
        Task<IEnumerable<Price>> FindDataAsync(Expression<Func<Price, bool>> predicate);
        Task AddDataAsync(Price data);
        Task UpdateDataAsync(Price data);
        Task DeleteDataAsync(string Id);
    }
}
