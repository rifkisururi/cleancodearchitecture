using AutoMapper;
using TiraCiptaLogistik.DataAccess.Repository;
using TiraCiptaLogistik.Domain.Entities;
using TiraCiptaLogistik.ViewModel.General;
using TiraCiptaLogistik.ViewModel.Request;
using TiraCiptaLogistik.ViewModel.Respond;

namespace TiraCiptaLogistik.Api
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SalesOrder, SalesOrderDTO>();

            
            CreateMap<RequestInputOrderDTO, SalesOrder>();
            CreateMap<ProdukDetailDTO, SalesOrderDetail>();
            CreateMap<ProdukDetailDTO, ProdukRingkasDTO>();

            
        }
    }
}
