﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bd_sgcquinuapataEntities : DbContext
    {
        public bd_sgcquinuapataEntities()
            : base("name=bd_sgcquinuapataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Movimiento_departamento> Movimiento_departamento { get; set; }
        public virtual DbSet<Ingreso> Ingreso { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Consumo> Consumo { get; set; }
        public virtual DbSet<Flujo_unidades_departamento> Flujo_unidades_departamento { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Asistencia> Asistencia { get; set; }
        public virtual DbSet<Activo_biologico> Activo_biologico { get; set; }
    }
}
