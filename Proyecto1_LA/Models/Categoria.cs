using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [DisplayName("Categoria")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }

    }
}