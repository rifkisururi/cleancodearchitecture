using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    public class SalesOrderDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string SalesOrderNo { get; set; }
        public string ProductCode { get; set; }
        public Int32 Qty { get; set; }
        public decimal Price { get; set; }
    }
}
