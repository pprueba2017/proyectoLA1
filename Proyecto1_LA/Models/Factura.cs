using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class Factura
    {
        [Key]
        public int idFactura { get; set; }


        [DisplayName("Nombre Usuario")]
        public string Nombre_Usuario { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DisplayName("Total Venta")]
        public Double Total_Venta { get; set; }
        
        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreado { get; set; }
               
    }
}