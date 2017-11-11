using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]

        [DisplayName("Nombre Producto")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DisplayName("Precio Unitario")]
        public double PrecioUnitario { get; set; }

        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DisplayName("Cantidad")]
        public int Cantidad { get; set; }


        
        [DisplayName("Categoria")]
        public int idCategoria { get; set; }
        [ForeignKey("idCategoria")]
        public virtual Categoria Categorias { get; set; }

       
        [DisplayName("SubCategoria")]
        public int idSubCategoria { get; set; }
        [ForeignKey("idSubCategoria")]
        public virtual SubCategoria SubCategorias { get; set; }


        [Display(Name = "Fecha Registro")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreado { get; set; }

       

    }
}