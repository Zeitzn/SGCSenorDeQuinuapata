using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly ProductoBL _ProductoBL = new ProductoBL();
        // GET: Producto
        public ActionResult Index()
        {
            ProductoViewModel productos = new ProductoViewModel()
            {
                ListIProducto=_ProductoBL.List()
            };
            return View(productos);
        }

        public JsonResult List()
        {
            ProductoViewModel productos = new ProductoViewModel()
            {
                ListIProducto = _ProductoBL.List()
            };
            return Json(productos, JsonRequestBehavior.AllowGet);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {

            ViewBag.Codigo = "INS-000001";
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(ProductoRequest request)
        {
            try
            {
                _ProductoBL.RegisterProducto(request);

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Producto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
