using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial2.Models
{
    public class RegistroDetalle
    {
        [Key]
        public int Id { get; set; }
        public int RegistroId { get; set; }
        public string Problema { get; set; }
        public string Solucion { get; set; }

        public RegistroDetalle()
        {
            Id = 0;
            RegistroId = 0;
            Problema = string.Empty;
            Solucion = string.Empty;
        }
    }
}
