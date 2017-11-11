using Proyecto1_LA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto1_LA.Controllers
{
    
    public class CarritoController : Controller
    {
        private Model1 db = new Model1();
        // GET: Carrito
        public ActionResult AgregarCarrito(int id) //PASAMOS EL ID DEL PRODUCTO  Y CREAMOS LA LISTA
        {
            if (Session["carrito"]==null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.Productoes.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)//NO ESTABA EL PRODUCTO
                    compras.Add(new CarritoItem(db.Productoes.Find(id), 1));

                else
                    compras[IndexExistente].Cantidad++;
                   Session["carrito"] = compras;                 
            }

            return View();
        }
        string usuario ="";

        private int getIndex(int id)//BUSCAMOS LA POSICION Q ESTA EL ID DEL PRODUCTO SI EXISTE
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.idProducto == id)
                {
                    return i;
                }
            }
            return -1;


        }

        public ActionResult FinalizarCompra()
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras !=null && compras.Count>0)
            {
                //venta /CREAMOS LA FACTURA
                Factura nuevafactura = new Factura();
                nuevafactura.FechaCreado = DateTime.Now;
                nuevafactura.Total_Venta = compras.Sum(x => x.Producto.PrecioUnitario * x.Cantidad);
                usuario = User.Identity.Name; //UserManager
                nuevafactura.Nombre_Usuario = usuario;

                db.Facturas.Add(nuevafactura);
                db.SaveChanges();
                    //factura creada
                ///GUARDAMOS LOS DETALLES
                DetalleFactura nueva = new DetalleFactura();
            
                foreach (var item in Session["carrito"] as List<Proyecto1_LA.Models.CarritoItem>)
                {
                    
                   nueva.Nombre=   item.Producto.Nombre;
                    nueva.PrecioVenta = item.Producto.PrecioUnitario;
                    nueva.Cantidad = item.Cantidad;
                    nueva.FechaCreado = DateTime.Now;
                    nueva.NombreUsuario = usuario;
                    nueva.idFactura = nuevafactura.idFactura;
                    db.DetalleFacturas.Add(nueva);
                    db.SaveChanges();

                    //AQUI REsTAMO LA CANTIDAD DEL PRODUCTOS
                    Producto nuevopro = new Producto();
               //     nuevopro.Categorias = item.Producto.Categorias;
                 //   nuevopro.SubCategorias = item.Producto.SubCategorias;

                    nuevopro.Nombre = item.Producto.Nombre;
                    nuevopro.FechaCreado = item.Producto.FechaCreado;
                    nuevopro.idCategoria = item.Producto.idCategoria;
                    nuevopro.Descripcion = item.Producto.Descripcion;
                    nuevopro.PrecioUnitario = item.Producto.PrecioUnitario;
                    nuevopro.idProducto = item.Producto.idProducto;
                    nuevopro.idSubCategoria = item.Producto.idSubCategoria;
                    nuevopro.Cantidad = item.Producto.Cantidad - item.Cantidad;
                    db.Entry(nuevopro).State = EntityState.Modified;
                    db.SaveChanges();
                }
              
            }
            return View();

        }
        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }


    }
}