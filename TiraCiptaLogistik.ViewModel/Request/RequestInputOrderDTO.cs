using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiraCiptaLogistik.ViewModel.General;

namespace TiraCiptaLogistik.ViewModel.Request
{
    public class RequestInputOrderDTO
    {
        public string CustCode { get; set; }
        public List<ProdukDetailDTO> OrderDetail { get; set; }
    }
    

}
