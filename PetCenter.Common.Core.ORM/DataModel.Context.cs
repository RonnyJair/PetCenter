﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetCenter.Common.Core.ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Entities;

    public partial class BdPetCenterEntities1 : DbContext
    {
        public BdPetCenterEntities1()
            : base("name=BdPetCenterEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Afp> Afps { get; set; }
        public virtual DbSet<Asistencia> Asistencias { get; set; }
        public virtual DbSet<Banco> Bancoes { get; set; }
        public virtual DbSet<Concepto> Conceptoes { get; set; }
        public virtual DbSet<Contrato> Contratoes { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<EmpleadoAfp> EmpleadoAfps { get; set; }
        public virtual DbSet<EmpleadoOnp> EmpleadoOnps { get; set; }
        public virtual DbSet<EmpleadoSueldoBase> EmpleadoSueldoBases { get; set; }
        public virtual DbSet<EsSalud> EsSaluds { get; set; }
        public virtual DbSet<Falta> Faltas { get; set; }
        public virtual DbSet<Justificacion> Justificacions { get; set; }
        public virtual DbSet<Moneda> Monedas { get; set; }
        public virtual DbSet<Onp> Onps { get; set; }
        public virtual DbSet<Planilla> Planillas { get; set; }
        public virtual DbSet<PlanillaEmpleado> PlanillaEmpleadoes { get; set; }
        public virtual DbSet<PlanillaEmpleadoConcepto> PlanillaEmpleadoConceptoes { get; set; }
        public virtual DbSet<SeguroVidaLey> SeguroVidaLeys { get; set; }
        public virtual DbSet<SueldoMinimo> SueldoMinimoes { get; set; }
        public virtual DbSet<Tardanza> Tardanzas { get; set; }
        public virtual DbSet<TipoCuenta> TipoCuentas { get; set; }
        public virtual DbSet<TipoDocumento> TipoDocumentoes { get; set; }
        public virtual DbSet<Ubigeo> Ubigeos { get; set; }
        public virtual DbSet<Uit> Uits { get; set; }
    }
}
