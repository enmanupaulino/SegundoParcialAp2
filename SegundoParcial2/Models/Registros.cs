using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial2.Models
{
    public class Registros
    {
        [Key]
        public int RegistroId { get; set; }
        [Required(ErrorMessage ="Debe hacer alguna Descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe hacer alguna Problema")]
        public string Problema { get; set; }
        [Required(ErrorMessage = "Debe hacer alguna Solucion")]
        public string Solucion { get; set; }
        
        [ForeignKey("RegistroId")]
        public virtual List<RegistroDetalle> Detalle { get; set; }
        public Registros()
        {
            RegistroId = 0;
            Descripcion = string.Empty;
            Problema = string.Empty;
            Solucion = string.Empty;
            Detalle = new List<RegistroDetalle>();
        }
    }
}
