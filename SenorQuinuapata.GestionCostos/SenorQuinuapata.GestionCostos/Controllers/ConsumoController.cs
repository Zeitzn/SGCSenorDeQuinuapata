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
            //try
            //{
                _ConsumoBL.RegisterConsumo(consumo);

                return RedirectToAction("Create");
            //}
            //catch
            //{
            //    return View();
            //}
        }

        
    }
}
