using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Interface
{
    public interface IMovimientoDepartamentoBL
    {
        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id);

        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id);

        void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request);

        void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida);

        MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento,string genero);

        void UpdateSalidaSaldo(int orige, int? salida, int? saldo);       

        bool MakeMovimiento(MovimientoDepartamentoRequest request, IngresoRequest _ingreso, string origen);

        void RegisterActivoBiologico(int id_movimiento, string genero, int cantidad,string ubicacion,string raza,DateTime fecha);

        IEnumerable<ActivoBiologicoResponse> ListActivoBiologico();

        void UpdateFecha(DateTime fecha, string campo, int id);

        void UpdateParto(int cantidad, int id);

        void DisableActivo(int id);

        void DeleteActivo(int id);

        string GenerateCostos(DateTime fecha);

    }
}
