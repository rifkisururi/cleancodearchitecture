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
    public interface ISalesOrderInterfaceRepository : IGenericRepository<SalesOrderInterface>
    {
        Task<IEnumerable<SalesOrderInterface>> GetAllDataAsync();
        Task<SalesOrderInterface> GetByIdAsync(string salesOrderNo);
        Task<IEnumerable<SalesOrderInterface>> FindDataAsync(Expression<Func<SalesOrderInterface, bool>> predicate);
        Task AddDataAsync(SalesOrderInterface data);
        Task UpdateDataAsync(SalesOrderInterface data);
        Task DeleteDataAsync(string salesOrderNo);
    }
}
