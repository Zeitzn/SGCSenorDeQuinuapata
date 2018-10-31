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


        //DESCARTE
        public decimal? consumo_inicial_md_descarte { get; set; }
        public decimal? consumo_inicial_mod_descarte { get; set; }
        public decimal? consumo_inicial_mi_descarte { get; set; }
        public decimal? consumo_inicial_moi_descarte { get; set; }

        public decimal? costo_agregado_md_descarte { get; set; }
        public decimal? costo_agregado_mod_descarte { get; set; }
        public decimal? costo_agregado_mi_descarte { get; set; }
        public decimal? costo_agregado_moi_descarte { get; set; }
       

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
        public int? unidades_recibidas_engorde { get; set; }
        public int? unidades_agregados_nacidos { get; set; }


        //DATOS GENERALES
        public int? unidades_finales_proceso { get; set; }
        public int? unidades_finales_proceso_lactancia { get; set; }
        public int? unidades_finales_proceso_recria { get; set; }
        public int? unidades_finales_proceso_engorde { get; set; }
        public int? unidades_finales_proceso_descarte { get; set; }
        public int? total_flujo_lactancia { get; set; }
        public int? total_flujo_recria { get; set; }
        public int? total_flujo_engorde { get; set; }
        public int? total_flujo_descarte { get; set; }
        public int? q_equivalente { get; set; }

        //DATOS ENVIADOS
        public int? q_equivalente_lactancia { get; set; }
        public int? q_equivalente_recria { get; set; }
        public int? q_equivalente_engorde { get; set; }
        public int? q_equivalente_descarte { get; set; }

        public int? unidades_transferidas_mortalidad_lactancia { get; set; }
        public int? unidades_transferidas_mortalidad_recria { get; set; }
        public int? unidades_transferidas_mortalidad_engorde { get; set; }
        public int? unidades_transferidas_mortalidad_descarte { get; set; }

        public int? unidades_transferidas_ventas_recria { get; set; }
        public int? unidades_transferidas_ventas_engorde { get; set; }
        public int? unidades_transferidas_ventas_descarte { get; set; }


        public int? unidades_iniciales_proceso_lactancia { get; set; }
        public int? unidades_iniciales_proceso_recria { get; set; }
        public int? unidades_iniciales_proceso_engorde { get; set; }
        public int? unidades_iniciales_proceso_descarte { get; set; }

        //INTERVALO DE FECHAS
        public DateTime? fecha_inicial { get; set; }
        public DateTime? fecha_final { get; set; }

        //INICIALES PP
        public decimal? pp_md_lactancia { get; set; }
        public decimal? pp_mod_lactancia { get; set; }
        public decimal? pp_mi_lactancia { get; set; }
        public decimal? pp_moi_lactancia { get; set; }

        public decimal? pp_final_md_lactancia { get; set; }
        public decimal? pp_final_mod_lactancia { get; set; }
        public decimal? pp_final_mi_lactancia { get; set; }
        public decimal? pp_final_moi_lactancia { get; set; }

        public decimal? pp_md_recria { get; set; }
        public decimal? pp_mod_recria { get; set; }
        public decimal? pp_mi_recria { get; set; }
        public decimal? pp_moi_recria { get; set; }

        public decimal? pp_final_md_recria { get; set; }
        public decimal? pp_final_mod_recria { get; set; }
        public decimal? pp_final_mi_recria { get; set; }
        public decimal? pp_final_moi_recria { get; set; }

        public decimal? pp_md_engorde { get; set; }
        public decimal? pp_mod_engorde { get; set; }
        public decimal? pp_mi_engorde { get; set; }
        public decimal? pp_moi_engorde { get; set; }

        public decimal? pp_final_md_engorde { get; set; }
        public decimal? pp_final_mod_engorde { get; set; }
        public decimal? pp_final_mi_engorde { get; set; }
        public decimal? pp_final_moi_engorde { get; set; }

        public decimal? pp_md_descarte { get; set; }
        public decimal? pp_mod_descarte { get; set; }
        public decimal? pp_mi_descarte { get; set; }
        public decimal? pp_moi_descarte { get; set; }

        public decimal? pp_final_md_descarte { get; set; }
        public decimal? pp_final_mod_descarte { get; set; }
        public decimal? pp_final_mi_descarte { get; set; }
        public decimal? pp_final_moi_descarte { get; set; }
        // COSTOS TOTALES INCURRIDOS

        public decimal? ct_incurrido_md_lactancia { get; set; }
        public decimal? ct_incurrido_mi_lactancia { get; set; }
        public decimal? ct_incurrido_moi_lactancia { get; set; }
        public decimal? ct_incurrido_mod_lactancia { get; set; }

        public decimal? ct_final_md_lactancia { get; set; }
        public decimal? ct_final_mi_lactancia { get; set; }
        public decimal? ct_final_moi_lactancia { get; set; }
        public decimal? ct_final_mod_lactancia { get; set; }

        public decimal? ct_incurrido_md_recria { get; set; }
        public decimal? ct_incurrido_mi_recria { get; set; }
        public decimal? ct_incurrido_moi_recria { get; set; }
        public decimal? ct_incurrido_mod_recria { get; set; }

        public decimal? ct_final_md_recria { get; set; }
        public decimal? ct_final_mi_recria { get; set; }
        public decimal? ct_final_moi_recria { get; set; }
        public decimal? ct_final_mod_recria { get; set; }

        public decimal? ct_incurrido_md_engorde { get; set; }
        public decimal? ct_incurrido_mi_engorde { get; set; }
        public decimal? ct_incurrido_moi_engorde { get; set; }
        public decimal? ct_incurrido_mod_engorde { get; set; }

        public decimal? ct_final_md_engorde { get; set; }
        public decimal? ct_final_mi_engorde { get; set; }
        public decimal? ct_final_moi_engorde { get; set; }
        public decimal? ct_final_mod_engorde { get; set; }

        public decimal? ct_incurrido_md_descarte { get; set; }
        public decimal? ct_incurrido_mi_descarte { get; set; }
        public decimal? ct_incurrido_moi_descarte { get; set; }
        public decimal? ct_incurrido_mod_descarte { get; set; }

        public decimal? ct_final_md_descarte { get; set; }
        public decimal? ct_final_mi_descarte { get; set; }
        public decimal? ct_final_moi_descarte { get; set; }
        public decimal? ct_final_mod_descarte { get; set; }

        //COSTOS UNITARIOS

        public decimal? cu_md_lactancia { get; set; }
        public decimal? cu_mod_lactancia { get; set; }
        public decimal? cu_mi_lactancia { get; set; }
        public decimal? cu_moi_lactancia { get; set; }

        public decimal? cu_md_recria { get; set; }
        public decimal? cu_mod_recria { get; set; }
        public decimal? cu_mi_recria { get; set; }
        public decimal? cu_moi_recria { get; set; }

        public decimal? cu_md_engorde { get; set; }
        public decimal? cu_mod_engorde { get; set; }
        public decimal? cu_mi_engorde { get; set; }
        public decimal? cu_moi_engorde { get; set; }

        public decimal? cu_md_descarte { get; set; }
        public decimal? cu_mod_descarte { get; set; }
        public decimal? cu_mi_descarte { get; set; }
        public decimal? cu_moi_descarte { get; set; }

       
    }
}
