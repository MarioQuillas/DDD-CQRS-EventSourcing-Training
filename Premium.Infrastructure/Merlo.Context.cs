﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Premium.Infrastructure
{
    public partial class MerloEntities : DbContext
    {
        public MerloEntities()
            : base("name=MerloEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<MatchEvent> MatchEvents { get; set; }
        public DbSet<Match> Matches { get; set; }
    }
}
