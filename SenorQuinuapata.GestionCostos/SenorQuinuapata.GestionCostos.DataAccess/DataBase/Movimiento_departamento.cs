//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SenorQuinuapata.GestionCostos.DataAccess.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movimiento_departamento
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> edad { get; set; }
        public string genero { get; set; }
        public int id_departamento { get; set; }
        public Nullable<int> ingreso { get; set; }
        public Nullable<int> salida { get; set; }
        public Nullable<int> saldo { get; set; }
        public Nullable<int> avance { get; set; }
        public Nullable<int> q_equivalente { get; set; }
        public Nullable<decimal> cu_md { get; set; }
        public Nullable<decimal> cu_mod { get; set; }
        public Nullable<decimal> cu_cif { get; set; }
        public Nullable<decimal> cu_total { get; set; }
        public Nullable<decimal> costo_total { get; set; }
    
        public virtual Departamento Departamento { get; set; }
    }
}
