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
       
        public int? unidades_iniciales_proceso_lactancia { get; set; }
        public int? unidades_iniciales_proceso_recria { get; set; }
        public int? unidades_iniciales_proceso_engorde { get; set; }
        public int? unidades_iniciales_proceso_descarte { get; set; }

        public int? unidades_agregados_nacidos_lactancia { get; set; }
        public int? unidades_recibidas_lactancia { get; set; }
        public int? unidades_recibidas_recria { get; set; }
        public int? unidades_recibidas_engorde { get; set; }
        public int? unidades_recibidas_activo { get; set; }


        public int? unidades_transferidas_recria { get; set; }
        public int? unidades_transferidas_engorde { get; set; }
        public int? unidades_transferidas_descarte { get; set; }
        public int? unidades_transferidas_activo { get; set; }

        public int? unidades_transferidas_mortalidad_lactancia { get; set; }
        public int? unidades_transferidas_mortalidad_recria { get; set; }
        public int? unidades_transferidas_mortalidad_engorde { get; set; }
        public int? unidades_transferidas_mortalidad_descarte { get; set; }


        public int? unidades_transferidas_ventas_recria { get; set; }
        public int? unidades_transferidas_ventas_engorde { get; set; }
        public int? unidades_transferidas_ventas_descarte { get; set; }


        public int? unidades_finales_proceso_lactancia { get; set; }
        public int? unidades_finales_proceso_recria { get; set; }
        public int? unidades_finales_proceso_engorde { get; set; }
        public int? unidades_finales_proceso_descarte { get; set; }

        public int? q_equivalente_lactancia { get; set; }
        public int? q_equivalente_recria { get; set; }
        public int? q_equivalente_engorde { get; set; }
        public int? q_equivalente_descarte { get; set; }

        public DateTime? fecha_inicial { get; set; }
        public DateTime? fecha_final { get; set; }
    }
}
