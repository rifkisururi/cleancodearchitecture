using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Web.Interface
{
    public interface ISendDataService
    {
        Task<SalesOrderDTO> SendDataAsync(RequestInputOrderDTO data);
    }
}
