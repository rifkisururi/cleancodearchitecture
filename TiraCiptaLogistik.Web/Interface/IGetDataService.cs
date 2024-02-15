using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Web.Interface
{
    public interface IGetDataService
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<List<ProdukPriceDTO>> GetAllProductPriceAsync();
    }
}
