using SenorQuinuapata.GestioCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Implementation
{
    public class DepartamentoBL : IDepartamentoBL
    {
        private readonly DepartamentoDA _DepartamentoDA=new DepartamentoDA();

        

        public IEnumerable<DepartamentoResponse> List()
        {
            return _DepartamentoDA.List();
        }

        public IEnumerable<FlujoUnidadesDepartamentoResponse> ListReportFlujoUnidades(int id_departamento,string fecha_inicial,string fecha_final)
        {
            return _DepartamentoDA.ListReportFlujoUnidades(id_departamento,fecha_inicial,fecha_final);
        }
        public IEnumerable<CostoUnitarioDepartamentoResponse> ListReportInformeConsumo(string fecha_inicial, string fecha_final)
        {
            return _DepartamentoDA.ListReportInformeConsumo(fecha_inicial, fecha_final);
        }

        public IEnumerable<CostoUnitarioDepartamentoResponse> ListReportCostoUnitarioDepartamento(int id_departamento, string fecha_inicial, string fecha_final)
        {
            return _DepartamentoDA.ListReportCostoUnitarioDepartamento(id_departamento, fecha_inicial, fecha_final);
        }
    }
}
