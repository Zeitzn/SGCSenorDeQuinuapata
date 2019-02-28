using BuenaVista.Caja.Web.Helper;
using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
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
    [Authorize]
    public class PersonaController : Controller
    {
        private readonly PersonaBL _PersonaBL = new PersonaBL();

        private bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        #region transaccional
        public ActionResult Create()
        {

            ViewBag.SuccessRegister = "";
            ViewBag.Cargo = db.Cargo.ToList();
            return View();
        }

        public ActionResult Asistencia()
        {
            PersonaViewModel _persona = new PersonaViewModel()
            {
                ListPersona = _PersonaBL.List()
            };

            return View(_persona);
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(PersonaRequest request)
        {
            try
            {
                _PersonaBL.RegisterPersona(request);


                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.SuccessRegister = "Error en el registro, por favor inténtelo nuevamente";
                return View();
            }
        }

        [HttpGet]
        public JsonResult MarcarAsistencia(int id,string fecha)
        {
            _PersonaBL.MarcarAsistencia(id,fecha);

            string msg = "success";

            //return RedirectToAction("Asistencia");

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        
        public ActionResult ResetAsistencia()
        {
            _PersonaBL.ResetAsistencia();

            return RedirectToAction("Asistencia");
        }

        #endregion

        #region no transaccional
        public ActionResult Index()
        {
            PersonaViewModel _persona = new PersonaViewModel()
            {
                ListPersona = _PersonaBL.List()
            };

            return View(_persona);
        }



        public ActionResult ReportAsistencia(int mes,int anio)
        {

            //string _mes = "";

            //switch (mes)
            //{
            //    case 1:
            //        _mes = "Enero";
            //        break;
            //    case 2:
            //        _mes = "Febrero";
            //        break;
            //    case 3:
            //        _mes = "Marzo";
            //        break;
            //    case 4:
            //        _mes = "Abril";
            //        break;
            //    case 5:
            //        _mes = "Mayo";
            //        break;
            //    case 6:
            //        _mes = "Junio";
            //        break;
            //    case 7:
            //        _mes = "Julio";
            //        break;
            //    case 8:
            //        _mes = "Agosto";
            //        break;
            //    case 9:
            //        _mes = "Setiembre";
            //        break;
            //    case 10:
            //        _mes = "Octubre";
            //        break;
            //    case 11:
            //        _mes = "Noviembre";
            //        break;
            //    case 12:
            //        _mes = "Diciembre";
            //        break;
            //    default:
            //        break;
            //}

            //PersonaViewModel _persona = new PersonaViewModel()
            //{
            //    GetPersona = _PersonaBL.GetPersonaByDni(dni)
            //};

            var oList = _PersonaBL.ReportAsistencia(mes, anio);

            var reportViewModel = new ReportAsistenciaViewModel()
            {
                FileName = "~/Reports/ReportAsistencia.rdlc",
                ReportTitle = "Asistencia",
                Format = ReportAsistenciaViewModel.ReportFormat.Excel,
                ViewAsAttachment = true,
            };


            //reportViewModel.Parameters.Add(new ReportAsistenciaViewModel.Parameter { Name = "mes", Value = _mes });
            //reportViewModel.Parameters.Add(new ReportAsistenciaViewModel.Parameter { Name = "nombres", Value = _persona.GetPersona.nombres });
            reportViewModel.ReportDataSets.Add(new ReportAsistenciaViewModel.ReportDataSet() { DataSetData = oList, DatasetName = "DataSet1" });

            var renderedBytes = reportViewModel.RenderReport();

            if (reportViewModel.ViewAsAttachment)
                Response.AddHeader("content-disposition", reportViewModel.ReporExportFileName);

            return File(renderedBytes, reportViewModel.LastmimeType);
        }
        #endregion




    }
}