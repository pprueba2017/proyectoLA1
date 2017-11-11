using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto1_LA.Models;

namespace Proyecto1_LA.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private Model1 db = new Model1();

        // GET: DetalleFacturas
        public ActionResult Index()
        {
            return View(db.DetalleFacturas.ToList());
        }

        // GET: DetalleFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleFactura,idFactura,Nombre,PrecioVenta,Cantidad,FechaCreado,NombreUsuario")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFacturas.Add(detalleFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleFactura,idFactura,Nombre,PrecioVenta,Cantidad,FechaCreado,NombreUsuario")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            db.DetalleFacturas.Remove(detalleFactura);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
