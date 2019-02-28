using SenorQuinuapata.GestionCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Implementation
{
    public class MovimientoDepartamentoBL : IMovimientoDepartamentoBL
    {
        private readonly MovimientoDepartamentoDA _MovimientoDepartamentoDA = new MovimientoDepartamentoDA();
        private readonly IngresoDA _IngresoDA = new IngresoDA();



        #region no transaccional
        public MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento, string genero)
        {
            return _MovimientoDepartamentoDA.ExistsMovimientoDepartamento(fecha, id_departamento,genero);
        }
        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamento(id);
        }

        public IEnumerable<ActivoBiologicoResponse> ListActivoBiologico()
        {
            return _MovimientoDepartamentoDA.ListActivoBiologico();
        }

        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamentoReverse(id);
        }

        

        #endregion


        #region transaccional

        public string GenerateCostos(DateTime fecha)
        {
            return _MovimientoDepartamentoDA.GenerateCostos(fecha);
        }

        public void RegisterActivoBiologico(int id_movimiento, string genero, int cantidad,string ubicacion,string raza,DateTime fecha)
        {

            DateTime fecha_actual = DateTime.Now;
            ActivoBiologicoRequest _activo = new ActivoBiologicoRequest()
            {
                ubicacion = "Poza " + ubicacion,
                numero_parto = 0,
                raza = raza,
                valor_inicial = 25,
                tasa_depreciacion = Convert.ToDecimal(0.22),
                depreciacion_diaria = Convert.ToDecimal(0.05),
                depreciacion_acumulada = 0,
                estado = "Activo",
                valor_neto = 25,
                //fecha_ingreso = fecha_actual,
                fecha_ingreso = fecha,
                fecha_salida = fecha_actual,
                //fecha_fin_empadre = fecha_actual,
                //fecha_inicio_empadre = fecha_actual,
                genero = genero,
                observacion = ""
                
            };

            IngresoRequest _ingreso = new IngresoRequest()
            {
                //fecha=fecha_actual,
                fecha=fecha,
                activo = cantidad,
                codigo_destino = "AB001",
                codigo_origen = "EN001",
                descarte = 0,                
                engorde = 0,
                genero = genero,
                lactancia = 0,
                mortalidad = 0,
                recria = 0,
                venta = 0
            };

            _IngresoDA.RegisterIngreso(_ingreso);
            string _codigo;
            

            for (int i = 0; i < cantidad; i++)
            {
                _codigo = _MovimientoDepartamentoDA.CodeActivoBiologico();

                _MovimientoDepartamentoDA.RegisterActivoBiologico(_activo, _codigo);

            }

            _MovimientoDepartamentoDA.UpdateDescarte(id_movimiento, cantidad);


        }

        public bool MakeMovimiento(MovimientoDepartamentoRequest request, IngresoRequest _ingreso, string origen)
        {
            throw new NotImplementedException();
        }

        public void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request)
        {
            _MovimientoDepartamentoDA.RegisterMovimientoDepartamento(request);
        }

       public void UpdateFecha(DateTime fecha, string campo, int id)
        {
            _MovimientoDepartamentoDA.UpdateFecha(fecha,campo, id);
        }

        public void UpdateParto(int cantidad, int id)
        {
            _MovimientoDepartamentoDA.UpdateParto(cantidad, id);
        }

        public void DisableActivo(int id)
        {
            _MovimientoDepartamentoDA.DisableActivo(id);
        }

        public void DeleteActivo(int id)
        {
            _MovimientoDepartamentoDA.DeleteActivo(id);
        }


        public void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida)
        {
            _MovimientoDepartamentoDA.UpdateMovimientoDepartamento(id,cantidad,salida);
        }

        public void UpdateSalidaSaldo(int origen, int? salida, int? saldo)
        {
            _MovimientoDepartamentoDA.UpdateSalidaSaldo(origen,salida,saldo);
        }

       

        #endregion
    }
}
