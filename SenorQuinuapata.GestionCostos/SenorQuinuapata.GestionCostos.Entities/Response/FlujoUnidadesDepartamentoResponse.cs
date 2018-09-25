using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class FlujoUnidadesDepartamentoResponse
    {
        public int id { get; set; }
        public int id_departamento { get; set; }
        public DateTime? fecha { get; set; }
        public int? unidades_iniciales_proceso { get; set; }
        public int? unidades_agregados_nacidos { get; set; }
        public int? unidades_transferidas_recria { get; set; }
        public int? unidades_finales_proceso { get; set; }
        public int? unidades_transferidas_mortalidad { get; set; }
        public int? unidades_recibidas_lactancia { get; set; }
        public int? unidades_transferidas_ventas { get; set; }
        public int? unidades_transferidas_engorde { get; set; }
        public int? unidades_recibidas_recria { get; set; }
        public int? unidades_transferidas_descarte { get; set; }
        public int? unidades_transferidas_activo { get; set; }
        public int? unidades_recibidas_engorde { get; set; }
        public int? unidades_recibidas_activo { get; set; }
        public int? q_equivalente { get; set; }
    }
}
