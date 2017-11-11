using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto1_LA.Models;
using PagedList;
namespace Proyecto1_LA.Controllers
{
    public class ComprarController : Controller
    {
        private Model1 db = new Model1();
     
        // GET: Comprar
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Productoes.ToList().OrderBy(x=>x.Nombre));

        }

        //public ActionResult Busq_product_nombre(string nombre_producto)
        //{
        //    var nombrep = from s in db.Productoes select s;
        //    if (!string.IsNullOrEmpty(nombre_producto))
        //    {
        //        nombrep = nombrep.Where(j => j.Nombre.Contains(nombre_producto));
               
        //    }
        //    return View(db.Productoes);
        //}

        [HttpPost]
        public ActionResult Index(string inpBuscar, string idCategoria, double precio=0, double precio2=0)
        {
            
            if (inpBuscar.Length > 0)
            {
                var RegFiltrado = (from f in db.Productoes
                                   where f.Nombre.StartsWith(inpBuscar) orderby f.Nombre descending
                                   select f).Take(15);
            

                return View(RegFiltrado.ToList());
            }
            if (idCategoria.Length>0)
            {
                var RegFiltrado = (from f in db.Productoes
                                   where f.Categorias.Nombre.StartsWith(idCategoria)
                                   orderby f.Nombre descending
                                   select f).Take(15);


                return View(RegFiltrado.ToList());
            }

//            SELECT idProducto, Nombre, Descripcion, PrecioUnitario, Cantidad, idCategoria, idSubCategoria, FechaCreado
//FROM dbo.Productoes
//WHERE(PrecioUnitario > @precio2) AND(PrecioUnitario < @precio3)
                if (precio>0 && precio2>0)
            {
                var RegFiltrado = (from f in db.Productoes
                                   where(f.PrecioUnitario > @precio) where(f.PrecioUnitario< @precio2)
             
                                   orderby f.Nombre descending
                                   select f).Take(15);


                return View(RegFiltrado.ToList());
            }
            else
            {
                return View(db.Productoes.OrderByDescending(f =>
                f.Nombre).Take(20).ToList());
            }

        }

    }
}