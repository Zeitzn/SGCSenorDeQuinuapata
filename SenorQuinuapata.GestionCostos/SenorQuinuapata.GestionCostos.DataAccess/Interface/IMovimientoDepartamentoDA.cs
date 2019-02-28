using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Interface
{
    public interface IMovimientoDepartamentoDA
    {
        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id);

        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id);

        void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request);

        void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida);

        MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento,string genero);

        void UpdateSalidaSaldo(int origen, int? salida, int? saldo);
        
        string CodeActivoBiologico();

        void RegisterActivoBiologico(ActivoBiologicoRequest activo, string codigo);

        void UpdateDescarte(int id_movimiento,int cantidad);

        IEnumerable<ActivoBiologicoResponse> ListActivoBiologico();

        void UpdateFecha(DateTime fecha, string campo,int id);

        void UpdateParto(int cantidad, int id);

        void DisableActivo(int id);

        void DeleteActivo(int id);

        string GenerateCostos(DateTime fecha);



    }
}
