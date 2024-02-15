using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.ViewModel.Respond
{
    public class SalesOrderDTO
    {
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string SalesOrderNo { get; set; }
        public string CustCode { get; set; }
    }
}
