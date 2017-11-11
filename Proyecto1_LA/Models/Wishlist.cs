using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto1_LA.Models
{
    public class Wishlist
    {
        [Key]
        public int idWishlist { get; set; }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        [DisplayName("Nombre Usuario")]
        public string Nombre_Usuario { get; set; }


    }
}