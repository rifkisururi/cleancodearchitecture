using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    public class Customer
    {
        [Key]
        public string CustId { get; set; }
        public string CustName { get; set; }
    }
}
