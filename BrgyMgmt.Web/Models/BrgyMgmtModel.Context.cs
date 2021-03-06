﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrgyMgmt.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BrgyMgmtEntities : DbContext
    {
        public BrgyMgmtEntities()
            : base("name=BrgyMgmtEntities")
        {
        }
    	public static BrgyMgmtEntities Create() {
    		return new BrgyMgmtEntities();
    	}	
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserClaim> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Complaint> Complaints { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<CertificateCommunity> CertificateCommunities { get; set; }
        public virtual DbSet<Settlement> Settlements { get; set; }
        public virtual DbSet<MaintenanceTable> MaintenanceTables { get; set; }
        public virtual DbSet<HouseholdPropertyProduction> HouseholdPropertyProductions { get; set; }
        public virtual DbSet<Household> Households { get; set; }
        public virtual DbSet<LetterTemplate> LetterTemplates { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Clearance> Clearances { get; set; }
        public virtual DbSet<CustomLog> CustomLogs { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ApplicationSetting> ApplicationSettings { get; set; }
        public virtual DbSet<ConfigData> ConfigDatas { get; set; }
        public virtual DbSet<DisasterRelocationSite> DisasterRelocationSites { get; set; }
        public virtual DbSet<Disaster> Disasters { get; set; }
        public virtual DbSet<DisasterStatus> DisasterStatuses { get; set; }
        public virtual DbSet<EstablishmentLog> EstablishmentLogs { get; set; }
        public virtual DbSet<Establishment> Establishments { get; set; }
    }
}
