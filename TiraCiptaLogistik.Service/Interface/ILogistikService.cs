using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Service.Interface
{
    public interface ILogistikService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<IEnumerable<Price>> GetAllPriceAsync();
        Task<SalesOrderDTO> SaveOrderAsync(RequestInputOrderDTO data);
        Task<IEnumerable<ProdukPriceDTO>> GetAllProdukPriceAsync();

    }
}
