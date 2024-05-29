using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Facturaencabezado
    {
        public int id { get; set; }
        public int fenc_numero { get; set; }
        public DateTime fenc_fecha { get; set; }
        public string fenc_per_identificacion { get; set; }
    }
}
