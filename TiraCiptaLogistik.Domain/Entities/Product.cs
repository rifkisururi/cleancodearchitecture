using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    public class Product
    {
        [Key]
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
