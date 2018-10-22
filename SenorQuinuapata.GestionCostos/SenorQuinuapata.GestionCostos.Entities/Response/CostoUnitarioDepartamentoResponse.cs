using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class CostoUnitarioDepartamentoResponse
    {
        public int id { get; set; }

        //LACTANCIA
        public decimal? consumo_inicial_md_lactancia { get; set; }
        public decimal? consumo_inicial_mod_lactancia { get; set; }
        public decimal? consumo_inicial_mi_lactancia { get; set; }
        public decimal? consumo_inicial_moi_lactancia { get; set; }

        public decimal? costo_agregado_md_lactancia { get; set; }
        public decimal? costo_agregado_mod_lactancia { get; set; }
        public decimal? costo_agregado_mi_lactancia { get; set; }
        public decimal? costo_agregado_moi_lactancia { get; set; }

        //RECRIA
        public decimal? consumo_inicial_md_recria { get; set; }
        public decimal? consumo_inicial_mod_recria { get; set; }
        public decimal? consumo_inicial_mi_recria { get; set; }
        public decimal? consumo_inicial_moi_recria { get; set; }

        public decimal? costo_agregado_md_recria { get; set; }
        public decimal? costo_agregado_mod_recria { get; set; }
        public decimal? costo_agregado_mi_recria { get; set; }
        public decimal? costo_agregado_moi_recria { get; set; }

        //ENGORDE
        public decimal? consumo_inicial_md_engorde { get; set; }
        public decimal? consumo_inicial_mod_engorde { get; set; }
        public decimal? consumo_inicial_mi_engorde { get; set; }
        public decimal? consumo_inicial_moi_engorde { get; set; }

        public decimal? costo_agregado_md_engorde { get; set; }
        public decimal? costo_agregado_mod_engorde { get; set; }
        public decimal? costo_agregado_mi_engorde { get; set; }
        public decimal? costo_agregado_moi_engorde { get; set; }

        //UNIDADES RECIBIDAS Y TRANSFERIDAS
        public int? unidades_transferidas_recria { get; set; }
        public int? unidades_transferidas_mortalidad { get; set; }
        public int? unidades_transferidas_ventas { get; set; }
        public int? unidades_transferidas_engorde { get; set; }
        public int? unidades_transferidas_descarte { get; set; }
        public int? unidades_transferidas_activo { get; set; }
        public int? unidades_recibidas_lactancia { get; set; }
        public int? unidades_recibidas_recria { get; set; }
        public int? unidades_recibidas_activo { get; set; }


        //DATOS GENERALES
        public int? unidades_finales_proceso { get; set; }
        public int? total_flujo_lactancia { get; set; }
        public int? total_flujo_recria { get; set; }
        public int? total_flujo_engorde { get; set; }
        public int? total_flujo_descarte { get; set; }
        public int? q_equivalente { get; set; }

        //DATOS ENVIADOS
        public int? q_equivalente_lactancia { get; set; }
        public int? q_equivalente_recria { get; set; }
        public int? q_equivalente_engorde { get; set; }

        public int? unidades_transferidas_mortalidad_lactancia { get; set; }
        public int? unidades_transferidas_mortalidad_recria { get; set; }
        public int? unidades_transferidas_mortalidad_engorde { get; set; }
        
        public int? unidades_transferidas_ventas_recria { get; set; }
        public int? unidades_transferidasventas_engorde { get; set; }

        public int? unidades_finales_proceso_lactancia { get; set; }
        public int? unidades_finales_proceso_recria { get; set; }
        public int? unidades_finales_proceso_engorde { get; set; }
    }
}
