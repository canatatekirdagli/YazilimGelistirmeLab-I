﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcYazGelProje.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBYazgelProjeEntities1 : DbContext
    {
        public DBYazgelProjeEntities1()
            : base("name=DBYazgelProjeEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IME_bilgileri> IME_bilgileri { get; set; }
        public virtual DbSet<imedosya> imedosya { get; set; }
        public virtual DbSet<staj_formu> staj_formu { get; set; }
        public virtual DbSet<stajdosya> stajdosya { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<uye> uye { get; set; }
        public virtual DbSet<yonetici> yonetici { get; set; }
    }
}
