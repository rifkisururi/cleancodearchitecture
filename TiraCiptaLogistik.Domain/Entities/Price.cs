using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiraCiptaLogistik.Domain.Entities
{
    
    public class Price
    {
        public string ProductCode { get; set; }
        public decimal PriceValue { get; set; }
        public DateTime PriceValidateFrom { get; set; }
        public DateTime PriceValidateTo { get; set; }
    }
}
