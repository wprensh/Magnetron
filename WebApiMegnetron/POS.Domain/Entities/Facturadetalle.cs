using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Facturadetalle
    {
        public int id { get; set; }
        public string fdet_linea { get; set; }
        public int fdet_cantidad { get; set; }
        public int fdet_prod_id { get; set; }
        public int fdet_fenc_id { get; set; }
        public decimal fdet_prod_precio { get; set; }
    }
}
