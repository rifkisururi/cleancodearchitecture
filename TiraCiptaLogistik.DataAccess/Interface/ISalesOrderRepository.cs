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
    public interface ISalesOrderRepository : IGenericRepository<SalesOrder>
    {
        Task<IEnumerable<SalesOrder>> GetAllDataAsync();
        Task<SalesOrder> GetByIdAsync(string salesOrderNo);
        Task<IEnumerable<SalesOrder>> FindDataAsync(Expression<Func<SalesOrder, bool>> predicate);
        Task AddDataAsync(SalesOrder data);
        Task UpdateDataAsync(SalesOrder data);
        Task DeleteDataAsync(string salesOrderNo);
    }
}
