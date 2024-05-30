using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Facturaencabezado
    {
        [Key]
        public int fenc_id { get; set; }
        public int fenc_numero { get; set; }
        public DateTime fenc_fecha { get; set; }
        public int PersonaId { get; set; }

        public virtual Persona Persona { get; set; } = null!;
        public virtual ICollection<Facturadetalle> Facturadetalles { get; set; } = null!;
    }
}
