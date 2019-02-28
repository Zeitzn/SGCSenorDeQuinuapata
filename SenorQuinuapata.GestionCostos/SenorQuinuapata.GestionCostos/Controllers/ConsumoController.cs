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
    public class ConsumoController : Controller
    {
        private readonly ConsumoBL _ConsumoBL = new ConsumoBL();
        private readonly ProductoBL _ProductoBL = new ProductoBL();
        // GET: Consumo
        public ActionResult Index()
        {
            ConsumoViewModel _consumo = new ConsumoViewModel()
            {
                ListConsumo = _ConsumoBL.List()
            };
            return View(_consumo);
        }

   

        // GET: Consumo/Create
        public ActionResult Create()
        {
            ViewBag.ListProductos = _ProductoBL.List();
            return View();
        }

        // POST: Consumo/Create
        [HttpPost]
        public ActionResult Create(ConsumoRequest consumo)
        {
            //var msg = "ff";
            try
            {
                _ConsumoBL.RegisterConsumo(consumo);

                return RedirectToAction("Create");
            }
            catch
            {
                ViewBag.ListProductos = _ProductoBL.List();
                return View();

            }

            //return Json(msg, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetConsumoById(int id)
        {
            ConsumoViewModel data = new ConsumoViewModel()
            {
                Consumo = _ConsumoBL.GetConsumoById(id)
            };

            return Json(data.Consumo, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult UpdateConsumo(decimal costo_total,int id_consumo,string tipo)
        {
            string msg;
            try
            {

                _ConsumoBL.UpdateConsumo(id_consumo, costo_total, tipo);

                msg = "success";
            }
            catch (Exception e)
            {
                msg = "error";
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        
    }
}
