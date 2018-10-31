using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Interface
{
    public interface IDepartamentoBL
    {
        IEnumerable<DepartamentoResponse> List();
        IEnumerable<FlujoUnidadesDepartamentoResponse> ListReportFlujoUnidades(int id_departamento,string fecha_inicial, string fecha_final);
        IEnumerable<CostoUnitarioDepartamentoResponse> ListReportCostoUnitarioDepartamento(int id_departamento, string fecha_inicial, string fecha_final);
        IEnumerable<CostoUnitarioDepartamentoResponse> ListReportInformeConsumo(string fecha_inicial, string fecha_final);
    }
}
