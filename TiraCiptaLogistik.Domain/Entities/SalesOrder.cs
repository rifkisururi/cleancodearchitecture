using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    public class SalesOrder
    {
        
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string? SalesOrderNo { get; set; }
        public string CustCode { get; set; }
    }
}
