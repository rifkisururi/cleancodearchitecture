using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.ViewModel.General
{
    public class PayloadDTO
    {
        public string SalesOrderNo { get; set; }
        public string CustId { get; set; }
        public List<ProdukRingkasDTO> OrderDetail { get; set; }
    }
}
