﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFRESTService
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MindReaderEntities : DbContext
    {
        public MindReaderEntities()
            : base("name=MindReaderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Character_Name> Character_Name { get; set; }
        public virtual DbSet<Character_Type> Character_Type { get; set; }
        public virtual DbSet<Professional_Type> Professional_Type { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
    }
}
