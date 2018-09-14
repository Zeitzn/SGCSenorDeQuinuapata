using Ninject;
using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
//using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using SenorQuinuapata.GestionCostos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        private readonly DepartamentoBL _DepartamentoBL = new DepartamentoBL();
        private readonly MovimientoDepartamentoBL _MovimientoDepartamentoBL = new MovimientoDepartamentoBL();
        private readonly IngresoBL _IngresoBL = new IngresoBL();
        private readonly FlujoUnidadesDepartamentoBL _FlujoUnidadesDepartamentoBL = new FlujoUnidadesDepartamentoBL();


        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        // GET: Registro
        //public ActionResult Operacion(int id)
        //{
        //    ViewBag.ListProductos = _ProductoBL.List();
        //    if (id==1)
        //    {
        //        return View("RegistroIngreso");
        //    }            

        //    return View("RegistroConsumo");
        //}



        public ActionResult RegisterIngreso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(MovimientoDepartamentoRequest request/*,string movimiento*/, string origen/*, string destino*/)
        {
            request.fecha = DateTime.Now;

            string fecha_actual = DateTime.Now.ToShortDateString();

            DepartamentoViewModel departamentoViewModel = new DepartamentoViewModel();            

            IngresoViewModel _ingreso = new IngresoViewModel();
            //if (movimiento == "ingreso")
            //{
            if (origen == "Nace")
            {
                request.costo_total = 0;
                request.cu_cif = 0;
                request.cu_md = 0;
                request.cu_mod = 0;
                request.cu_total = 0;
                request.edad = 0;
                request.q_equivalente = 0;
                request.salida = 0;
                request.saldo = request.ingreso - request.salida;
                request.genero = "Gazapo";

                _ingreso.Ingreso = new IngresoRequest()
                {
                    codigo_destino = "LA001",
                    codigo_origen = "LA001",
                    lactancia = request.ingreso,
                    fecha = request.fecha,
                    genero = request.genero,

                };

                MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                if (mov.id == 0)
                {
                    _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                    _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);
                }
                else
                {
                    request.salida = mov.salida;
                    _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                    _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso, request.salida);
                }

                //departamentoViewModel.flujoUnidadesDepartamento = new FlujoUnidadesDepartamentoRequest()
                //{
                //    fecha=request.fecha,
                //    unidades_iniciales_proceso=request.ingreso,
                //    unidades_

                //};

                //_FlujoUnidadesDepartamentoBL.RegisterFlujo(departamentoViewModel.flujoUnidadesDepartamento);

            }

            if (origen == "1")
            {
                if (request.id_departamento == 2 || request.id_departamento == 3 || request.id_departamento == 4 || request.id_departamento == 5)
                {
                    int _origen = Convert.ToInt32(origen);
                    int? salida = request.ingreso;
                    int? saldo, _salida, _saldo = 0;



                    foreach (var item in _MovimientoDepartamentoBL.ListMovimientoDepartamentoReverse(_origen))
                    {

                        if (item.ingreso > 0)
                        {
                            if (item.saldo >= salida)
                            {

                                saldo = item.saldo - salida;

                                salida += item.salida;

                                _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, salida, saldo);

                                //ENVIO DE DATOS AL DEPARTAMENTO 2

                                _ingreso.Ingreso = new IngresoRequest()
                                {
                                    //codigo_destino = "RE001",
                                    codigo_origen = "LA001",
                                    //recria = request.ingreso,
                                    fecha = request.fecha,
                                    genero = request.genero,

                                };

                                switch (request.id_departamento)
                                {
                                    case 2:
                                        _ingreso.Ingreso.codigo_destino = "RE001";
                                        _ingreso.Ingreso.recria = request.ingreso;
                                        break;
                                    case 3:
                                        _ingreso.Ingreso.codigo_destino = "EN001";
                                        _ingreso.Ingreso.engorde = request.ingreso;
                                        break;
                                    case 4:
                                        _ingreso.Ingreso.codigo_destino = "DE001";
                                        _ingreso.Ingreso.descarte = request.ingreso;
                                        break;
                                    case 5:
                                        _ingreso.Ingreso.codigo_destino = "MO001";
                                        _ingreso.Ingreso.mortalidad = request.ingreso;
                                        break;
                                    default:
                                        break;
                                }

                                MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                                mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                                //En caso de que sea la primera vez que se registra en este dep en el dia

                                if (mov.id == 0)
                                {
                                    request.saldo = salida - item.salida;
                                    request.edad = 0;
                                    request.salida = 0;
                                    request.costo_total = 0;
                                    request.cu_cif = 0;
                                    request.cu_md = 0;
                                    request.cu_mod = 0;
                                    request.cu_total = 0;
                                    request.q_equivalente = 0;

                                    _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);

                                    _IngresoBL.RegisterIngreso(_ingreso.Ingreso);

                                }
                                else
                                {
                                    request.salida = mov.salida;
                                    _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                                    _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso, request.salida);


                                }



                                // FIN ENVIO DE DATOS AL DEPARTAMENTO 2
                                break;
                            }
                            else
                            {
                                salida -= item.saldo;

                                _salida = item.salida + item.saldo;

                                _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, _salida, _saldo);
                            }
                        }
                    }

                }
            }

            if (origen == "2")
            {
                if (request.id_departamento == 3 || request.id_departamento == 4 || request.id_departamento == 5 || request.id_departamento == 6)
                {
                    int _origen = Convert.ToInt32(origen);
                    int? salida = request.ingreso;
                    int? saldo, _salida, _saldo = 0;



                    foreach (var item in _MovimientoDepartamentoBL.ListMovimientoDepartamentoReverse(_origen))
                    {

                        if (item.ingreso > 0)
                        {
                            if (item.genero == request.genero)
                            {
                                if (item.saldo >= salida)
                                {

                                    saldo = item.saldo - salida;

                                    salida += item.salida;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, salida, saldo);

                                    //ENVIO DE DATOS AL DEPARTAMENTO 3

                                    _ingreso.Ingreso = new IngresoRequest()
                                    {
                                        //codigo_destino = "RE001",
                                        codigo_origen = "RE001",
                                        //recria = request.ingreso,
                                        fecha = request.fecha,
                                        genero = request.genero,

                                    };

                                    switch (request.id_departamento)
                                    {

                                        case 3:
                                            _ingreso.Ingreso.codigo_destino = "EN001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        case 4:
                                            _ingreso.Ingreso.codigo_destino = "DE001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        case 5:
                                            _ingreso.Ingreso.codigo_destino = "MO001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        case 6:
                                            _ingreso.Ingreso.codigo_destino = "VE001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        default:
                                            break;
                                    }

                                    MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                                    mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                                    //En caso de que sea la primera vez que se registra en este dep en el dia

                                    if (mov.id == 0)
                                    {
                                        request.saldo = salida - item.salida;
                                        request.edad = 0;
                                        request.salida = 0;
                                        request.costo_total = 0;
                                        request.cu_cif = 0;
                                        request.cu_md = 0;
                                        request.cu_mod = 0;
                                        request.cu_total = 0;
                                        request.q_equivalente = 0;

                                        _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);

                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);

                                    }
                                    else
                                    {
                                        request.salida = mov.salida;
                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                                        _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso, request.salida);


                                    }



                                    // FIN ENVIO DE DATOS AL DEPARTAMENTO 3
                                    break;
                                }
                                else
                                {
                                    salida -= item.saldo;

                                    _salida = item.salida + item.saldo;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, _salida, _saldo);
                                }
                            }

                        }
                    }

                }
            }

            if (origen == "3")
            {
                if (request.id_departamento == 4 || request.id_departamento == 5 || request.id_departamento == 6)
                {
                    int _origen = Convert.ToInt32(origen);
                    int? salida = request.ingreso;
                    int? saldo, _salida, _saldo = 0;



                    foreach (var item in _MovimientoDepartamentoBL.ListMovimientoDepartamentoReverse(_origen))
                    {

                        if (item.ingreso > 0)
                        {
                            if (item.genero == request.genero)
                            {
                                if (item.saldo >= salida)
                                {

                                    saldo = item.saldo - salida;

                                    salida += item.salida;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, salida, saldo);

                                    //ENVIO DE DATOS AL DEPARTAMENTO 4

                                    _ingreso.Ingreso = new IngresoRequest()
                                    {
                                        //codigo_destino = "RE001",
                                        codigo_origen = "EN001",
                                        //recria = request.ingreso,
                                        fecha = request.fecha,
                                        genero = request.genero,

                                    };

                                    switch (request.id_departamento)
                                    {
                                        case 4:
                                            _ingreso.Ingreso.codigo_destino = "DE001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        case 5:
                                            _ingreso.Ingreso.codigo_destino = "MO001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        case 6:
                                            _ingreso.Ingreso.codigo_destino = "VE001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        default:
                                            break;
                                    }

                                    MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                                    mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                                    //En caso de que sea la primera vez que se registra en este dep en el dia

                                    if (mov.id == 0)
                                    {
                                        request.saldo = salida - item.salida;
                                        request.edad = 0;
                                        request.salida = 0;
                                        request.costo_total = 0;
                                        request.cu_cif = 0;
                                        request.cu_md = 0;
                                        request.cu_mod = 0;
                                        request.cu_total = 0;
                                        request.q_equivalente = 0;

                                        _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);

                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);

                                    }
                                    else
                                    {
                                        request.salida = mov.salida;
                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                                        _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso, request.salida);


                                    }



                                    // FIN ENVIO DE DATOS AL DEPARTAMENTO 4
                                    break;
                                }
                                else
                                {
                                    salida -= item.saldo;

                                    _salida = item.salida + item.saldo;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, _salida, _saldo);
                                }
                            }

                        }
                    }

                }
            }

            if (origen == "4")
            {
                if (request.id_departamento == 5)
                {
                    int _origen = Convert.ToInt32(origen);
                    int? salida = request.ingreso;
                    int? saldo, _salida, _saldo = 0;



                    foreach (var item in _MovimientoDepartamentoBL.ListMovimientoDepartamentoReverse(_origen))
                    {

                        if (item.ingreso > 0)
                        {
                            if (item.genero == request.genero)
                            {
                                if (item.saldo >= salida)
                                {

                                    saldo = item.saldo - salida;

                                    salida += item.salida;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, salida, saldo);

                                    //ENVIO DE DATOS AL DEPARTAMENTO 4

                                    _ingreso.Ingreso = new IngresoRequest()
                                    {
                                        //codigo_destino = "RE001",
                                        codigo_origen = "DE001",
                                        //recria = request.ingreso,
                                        fecha = request.fecha,
                                        genero = request.genero,

                                    };

                                    switch (request.id_departamento)
                                    {
                                        case 5:
                                            _ingreso.Ingreso.codigo_destino = "MO001";
                                            _ingreso.Ingreso.engorde = request.ingreso;
                                            break;
                                        default:
                                            break;
                                    }

                                    MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                                    mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                                    //En caso de que sea la primera vez que se registra en este dep en el dia

                                    if (mov.id == 0)
                                    {
                                        request.saldo = salida - item.salida;
                                        request.edad = 0;
                                        request.salida = 0;
                                        request.costo_total = 0;
                                        request.cu_cif = 0;
                                        request.cu_md = 0;
                                        request.cu_mod = 0;
                                        request.cu_total = 0;
                                        request.q_equivalente = 0;

                                        _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);

                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);

                                    }
                                    else
                                    {
                                        request.salida = mov.salida;
                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                                        _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso, request.salida);


                                    }



                                    // FIN ENVIO DE DATOS AL DEPARTAMENTO 4
                                    break;
                                }
                                else
                                {
                                    salida -= item.saldo;

                                    _salida = item.salida + item.saldo;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id, _salida, _saldo);
                                }
                            }

                        }
                    }

                }
            }

            //}


            return RedirectToAction("RegisterIngreso");

        }


        public ActionResult Movimientos(int id)
        {
            DepartamentoViewModel movimientos = new DepartamentoViewModel()
            {
                ListMovimientoDepartamento = _MovimientoDepartamentoBL.ListMovimientoDepartamento(id)
            };

            if (id == 5 || id == 6)
            {
                return View("Mortalidad_ventas", movimientos);
            }

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