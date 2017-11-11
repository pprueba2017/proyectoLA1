using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class DetalleFactura
    {
        [Key]
        public int idDetalleFactura { get; set; }

        public int idFactura { get; set; }

        [DisplayName("Nombre Producto")]
        public string Nombre { get; set; }

        [DisplayName("Precio Venta")]
        public double PrecioVenta { get; set; }

        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }

        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreado { get; set; }

        [DisplayName("Nombre Usuario")]
        public string NombreUsuario { get; set; }


    }
}