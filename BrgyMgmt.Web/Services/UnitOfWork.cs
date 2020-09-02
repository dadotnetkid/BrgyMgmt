using BrgyMgmt.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Services
{
    public class UnitOfWork : IDisposable
    {
        private BrgyMgmtEntities context = new BrgyMgmtEntities();

        private GenericRepository<Establishment> establishmentRepository;
        public GenericRepository<Establishment> EstablishmentRepository
        {
            get
            {

                if (this.establishmentRepository == null)
                {
                    this.establishmentRepository = new GenericRepository<Establishment>(context);
                }
                return establishmentRepository;
            }
        }
        private GenericRepository<EstablishmentLog> establishmentLogRepository;
        public GenericRepository<EstablishmentLog> EstablishmentLogRepository
        {
            get
            {

                if (this.establishmentLogRepository == null)
                {
                    this.establishmentLogRepository = new GenericRepository<EstablishmentLog>(context);
                }
                return establishmentLogRepository;
            }
        }

        private GenericRepository<User> userRepository;
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        private GenericRepository<UserRole> roleRepository;
        public GenericRepository<UserRole> RoleRepository
        {
            get
            {

                if (this.roleRepository == null)
                {
                    this.roleRepository = new GenericRepository<UserRole>(context);
                }
                return roleRepository;
            }
        }
        private GenericRepository<Resident> residentRepository;
        public GenericRepository<Resident> ResidentRepository
        {
            get
            {

                if (this.residentRepository == null)
                {
                    this.residentRepository = new GenericRepository<Resident>(context);
                }
                return residentRepository;
            }
        }
        private GenericRepository<Household> householdRepository;
        public GenericRepository<Household> HouseholdRepository
        {
            get
            {

                if (this.householdRepository == null)
                {
                    this.householdRepository = new GenericRepository<Household>(context);
                }
                return householdRepository;
            }
        }
        private GenericRepository<Employee> employeeRepository;
        public GenericRepository<Employee> EmployeeRepository
        {
            get
            {

                if (this.employeeRepository == null)
                {
                    this.employeeRepository = new GenericRepository<Employee>(context);
                }
                return employeeRepository;
            }
        }

        private GenericRepository<Clearance> clearanceRepo;
        public GenericRepository<Clearance> ClearanceRepo
        {
            get
            {

                if (this.clearanceRepo == null)
                {
                    this.clearanceRepo = new GenericRepository<Clearance>(context);
                }
                return clearanceRepo;
            }
        }

        private GenericRepository<CertificateCommunity> certificateCommunityRepo;
        public GenericRepository<CertificateCommunity> CertificateCommunityRepo
        {
            get
            {

                if (this.certificateCommunityRepo == null)
                {
                    this.certificateCommunityRepo = new GenericRepository<CertificateCommunity>(context);
                }
                return certificateCommunityRepo;
            }
        }
        private GenericRepository<ConfigData> configDataRepo;
        public GenericRepository<ConfigData> ConfigDataRepo
        {
            get
            {

                if (this.configDataRepo == null)
                {
                    this.configDataRepo = new GenericRepository<ConfigData>(context);
                }
                return configDataRepo;
            }
        }
        private GenericRepository<Complaint> complaintRepo;
        public GenericRepository<Complaint> ComplaintRepo
        {
            get
            {

                if (this.complaintRepo == null)
                {
                    this.complaintRepo = new GenericRepository<Complaint>(context);
                }
                return complaintRepo;
            }
        }
        private GenericRepository<Settlement> settlementRepository;
        public GenericRepository<Settlement> SettlementRepository
        {
            get
            {

                if (this.settlementRepository == null)
                {
                    this.settlementRepository = new GenericRepository<Settlement>(context);
                }
                return settlementRepository;
            }
        }
        private GenericRepository<MaintenanceTable> maintenanceTableRepository;
        public GenericRepository<MaintenanceTable> MaintenanceTableRepository
        {
            get
            {

                if (this.maintenanceTableRepository == null)
                {
                    this.maintenanceTableRepository = new GenericRepository<MaintenanceTable>(context);
                }
                return maintenanceTableRepository;
            }
        }
        private GenericRepository<Certificate> certificateRepository;
        public GenericRepository<Certificate> CertificateRepository
        {
            get
            {

                if (this.certificateRepository == null)
                {
                    this.certificateRepository = new GenericRepository<Certificate>(context);
                }
                return certificateRepository;
            }
        }
        private GenericRepository<LetterTemplate> letterTemplateRepository;
        public GenericRepository<LetterTemplate> LetterTemplateRepository
        {
            get
            {

                if (this.letterTemplateRepository == null)
                {
                    this.letterTemplateRepository = new GenericRepository<LetterTemplate>(context);
                }
                return letterTemplateRepository;
            }
        }
        private GenericRepository<HouseholdPropertyProduction> householdPropertyProductionRepository;
        public GenericRepository<HouseholdPropertyProduction> HouseholdPropertyProductionRepository
        {
            get
            {

                if (this.householdPropertyProductionRepository == null)
                {
                    this.householdPropertyProductionRepository = new GenericRepository<HouseholdPropertyProduction>(context);
                }
                return householdPropertyProductionRepository;
            }
        }

        private GenericRepository<Disaster> disasterRepo;
        public GenericRepository<Disaster> DisasterRepo
        {
            get
            {

                if (this.disasterRepo == null)
                {
                    this.disasterRepo = new GenericRepository<Disaster>(context);
                }
                return disasterRepo;
            }
        }
        private GenericRepository<DisasterStatus> disasterStatusRepo;
        public GenericRepository<DisasterStatus> DisasterStatusRepo
        {
            get
            {

                if (this.disasterStatusRepo == null)
                {
                    this.disasterStatusRepo = new GenericRepository<DisasterStatus>(context);
                }
                return disasterStatusRepo;
            }
        }
        private GenericRepository<DisasterRelocationSite> disasterRelocationSiteRepo;
        public GenericRepository<DisasterRelocationSite> DisasterRelocationSiteRepo
        {
            get
            {

                if (this.disasterRelocationSiteRepo == null)
                {
                    this.disasterRelocationSiteRepo = new GenericRepository<DisasterRelocationSite>(context);
                }
                return disasterRelocationSiteRepo;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}