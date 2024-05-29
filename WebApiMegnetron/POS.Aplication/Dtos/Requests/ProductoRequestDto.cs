using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Dtos.Requests
{
    public class ProductoRequestDto
    {
        public string pord_desc { get; set; }
        public decimal prop_precio { get; set; }
        public decimal prod_costo { get; set; }
        public string prod_um { get; set; }
    }
}
