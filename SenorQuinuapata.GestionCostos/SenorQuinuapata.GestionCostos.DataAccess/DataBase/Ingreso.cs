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
    
    public partial class Ingreso
    {
        public int id { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public Nullable<int> edad { get; set; }
        public string genero { get; set; }
        public string codigo_origen { get; set; }
        public string codigo_destino { get; set; }
        public Nullable<int> lactancia { get; set; }
        public Nullable<int> recria { get; set; }
        public Nullable<int> engorde { get; set; }
        public Nullable<int> descarte { get; set; }
        public Nullable<int> mortalidad { get; set; }
    }
}
