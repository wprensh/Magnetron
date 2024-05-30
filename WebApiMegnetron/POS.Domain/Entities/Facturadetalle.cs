using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Facturadetalle
    {
        [Key]
        public int id { get; set; }
        public int fdet_linea { get; set; }
        public int fdet_cantidad { get; set; }
        public int ProductoId { get; set; }
        public int fdet_fenc_id { get; set; }
        public decimal fdet_prod_precio { get; set; }
        public decimal fdet_prod_utilidad { get; set; }
        public virtual Producto? Producto { get; set; } = null!;
        public virtual Facturaencabezado? Facturaencabezado { get; set; } = null!;


    }
}
