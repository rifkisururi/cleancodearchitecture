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
    public interface ISalesOrderDetailRepository : IGenericRepository<SalesOrderDetail>
    {
        Task<IEnumerable<SalesOrderDetail>> GetAllDataAsync();
        Task<SalesOrderDetail> GetByIdAsync(Guid id);
        Task<IEnumerable<SalesOrderDetail>> FindDataAsync(Expression<Func<SalesOrderDetail, bool>> predicate);
        Task AddDataAsync(SalesOrderDetail data);
        Task UpdateDataAsync(SalesOrderDetail data);
        Task DeleteDataAsync(Guid id);
        Task AddDataRangeAsync(List<SalesOrderDetail> dataList);
        
    }
}
