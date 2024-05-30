using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Dtos.Requests
{
    public class FacturaRequestDto
    {
        public int fenc_numero { get; set; }
        public DateTime fenc_fecha { get; set; }
        public int PersonaId { get; set; }
        public ICollection<FacturadetalleRequestDto> facturadetalleRequestDtos { get; set; }    
    }
}
