using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Producto
    {
        public int id { get; set; }
        public string pord_desc { get; set; }
        public decimal prod_precio { get; set; }
        public decimal prod_costo { get; set; }
        public string prod_um { get; set; }

    }
}
