using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    [Authorize]
    public class IngresoController : Controller
    {
        private readonly IngresoBL _IngresoBL = new IngresoBL();
        // GET: Ingreso
        public ActionResult Index()
        {
            var ingresos = new IngresoViewModel()
            {
                ListIngreso = _IngresoBL.ListIngreso()
            };
            return View(ingresos);
        }
    }
}