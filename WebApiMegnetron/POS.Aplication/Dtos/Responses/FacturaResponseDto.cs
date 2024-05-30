using POS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Dtos.Responses
{
    public class FacturaResponseDto
    {
        public int fenc_id { get; set; }
        public int fenc_numero { get; set; }
        public DateTime fenc_fecha { get; set; }
        public int PersonaId { get; set; }
        public virtual PersonaResponseDto PersonaResponseDto { get; set; } = null!;
        public virtual ICollection<FacturadetalleResponseDto> FacturadetalleResponseDto { get; set; } = null!;

    }
}
