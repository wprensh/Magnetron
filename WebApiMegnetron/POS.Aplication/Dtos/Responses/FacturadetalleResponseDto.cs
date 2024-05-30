using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Dtos.Responses
{
    public class FacturadetalleResponseDto
    {
        public int fdet_id { get; set; }
        public int fdet_linea { get; set; }
        public int fdet_cantidad { get; set; }
        public int ProductoId { get; set; }
        public int fdet_fenc_id { get; set; }
        public decimal fdet_prod_precio { get; set; }
        public decimal fdet_prod_utilidad { get; set; }
    }
}
