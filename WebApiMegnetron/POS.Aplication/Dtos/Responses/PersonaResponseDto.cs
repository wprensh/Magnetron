using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Dtos.Responses
{
    public class PersonaResponseDto
    {
        public int id { get; set; }
        public string per_nombre { get; set; }
        public string per_apellidos { get; set; }
        public int per_tipodoc { get; set; }
        public string per_identificacion { get; set; }
    }
}
