using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Domain.Entities
{
    public class Persona
    {
        [Key]
        public int PersonaId { get; set; }
        public string per_nombre { get; set; }
        public string per_apellidos { get; set; }
        public int per_tipodoc { get; set; }
        public string per_identificacion { get; set; }

    }
}
