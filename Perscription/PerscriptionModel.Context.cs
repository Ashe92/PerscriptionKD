﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Perscription
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PerscriptionEntities : DbContext
    {
        public PerscriptionEntities()
            : base("name=PerscriptionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<DoctorRecep> DoctorRecep { get; set; }
        public virtual DbSet<Level> Level { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Perscript> Perscript { get; set; }
    }
}
