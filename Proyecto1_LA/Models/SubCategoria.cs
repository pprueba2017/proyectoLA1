using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class SubCategoria
    {
        [Key]
        public int idSubCategoria { get; set; }
        [DisplayName("SubCategoria")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        
        public ICollection<Producto> Productos { get; set; }
    }
}