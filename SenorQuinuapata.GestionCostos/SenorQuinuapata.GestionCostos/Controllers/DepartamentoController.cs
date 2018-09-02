using Ninject;
//using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly DepartamentoBL _DepartamentoBL=new DepartamentoBL();
        private readonly MovimientoDepartamentoBL _MovimientoDepartamentoBL = new MovimientoDepartamentoBL();

        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        // GET: Registro
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(MovimientoDepartamentoRequest request,string movimiento)
        {

            DateTime fecha_actual = DateTime.Now;

            
            request.fecha = fecha_actual;
            request.avance = 0;
            request.costo_total = 0;
            request.cu_cif = 0;
            request.cu_md = 0;
            request.cu_mod = 0;
            request.cu_total = 0;
            request.edad = 0;
            request.q_equivalente = 0;            
            request.salida = 0;
            request.saldo = request.ingreso-request.salida;

            //if (ModelState.IsValid)
            //{
                _MovimientoDepartamentoBL.RegisterMovimientoDepartento(request);

                return RedirectToAction("Index");

            //}

            //return View("Index", request);
        }


        public ActionResult Movimientos(int id)
        {
            DepartamentoViewModel movimientos = new DepartamentoViewModel()
            {
                ListMovimientoDepartamento = _MovimientoDepartamentoBL.ListMovimientoDepartamento(id)
            };

            return View(movimientos);
        }



        //PRUEBAAAA
        public ActionResult Lista()
        {

            var departamentos = new DepartamentoViewModel()
            {
                ListDepartamento = _DepartamentoBL.List()
            };

            return View(/*db.Departamento.ToList()*/departamentos);
        }
    }
}