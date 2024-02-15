using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    public class SalesOrderInterface
    {
        [Key]
        public string SalesOrderNo { get; set; }
        public string Payload { get; set; }
    }
}
