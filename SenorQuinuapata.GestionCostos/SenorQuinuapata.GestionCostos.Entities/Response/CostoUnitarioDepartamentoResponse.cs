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
        public decimal consumo_inicial_md { get; set; }
        public decimal consumo_inicial_mod { get; set; }
        public decimal consumo_inicial_cif { get; set; }
        public decimal costo_agregado_md { get; set; }
        public decimal costo_agregado_mod { get; set; }
        public decimal costo_agregado_cif { get; set; }
        public int unidades_transferidas_recria { get; set; }
        public int unidades_transferidas_mortalidad { get; set; }
        public int unidades_finales_proceso { get; set; }
        public int? q_equivalente { get; set; }
    }
}
