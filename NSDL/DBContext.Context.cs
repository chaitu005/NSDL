﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NSDL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SingleEntities : DbContext
    {
        public SingleEntities()
            : base("name=SingleEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bank_master> Bank_master { get; set; }
        public virtual DbSet<Branch_master> Branch_master { get; set; }
        public virtual DbSet<Chequemaster> Chequemasters { get; set; }
        public virtual DbSet<Client_master1> Client_master1 { get; set; }
        public virtual DbSet<Instrument_master> Instrument_master { get; set; }
        public virtual DbSet<Stock_master> Stock_master { get; set; }
        public virtual DbSet<Lot_size> Lot_size { get; set; }
        public virtual DbSet<Vendor_master> Vendor_master { get; set; }
        public virtual DbSet<Book_size> Book_size { get; set; }
        public virtual DbSet<Inward_entry> Inward_entry { get; set; }
        public virtual DbSet<Trxbackoffice> Trxbackoffices { get; set; }
        public virtual DbSet<Security> Securities { get; set; }
        public virtual DbSet<Sysparameter> Sysparameters { get; set; }
        public virtual DbSet<Reasonfortrade> Reasonfortrades { get; set; }
        public virtual DbSet<Bpmaster> Bpmasters { get; set; }
        public virtual DbSet<Cc_calender> Cc_calender { get; set; }
        public virtual DbSet<Chequestop> Chequestops { get; set; }
        public virtual DbSet<Rate_master> Rate_master { get; set; }
        public virtual DbSet<Used_slip> Used_slip { get; set; }
        public virtual DbSet<Auth_master> Auth_master { get; set; }
        public virtual DbSet<Backoffice_balance> Backoffice_balance { get; set; }
        public virtual DbSet<Backoffice_audit> Backoffice_audit { get; set; }
        public virtual DbSet<Backoffice_delete> Backoffice_delete { get; set; }
        public virtual DbSet<Interdepository> Interdepositories { get; set; }
        public virtual DbSet<Interdepository_auth> Interdepository_auth { get; set; }
        public virtual DbSet<Security_status> Security_status { get; set; }
    
        public virtual ObjectResult<GetRecievedIn_Result> GetRecievedIn()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetRecievedIn_Result>("GetRecievedIn");
        }
    }
}
