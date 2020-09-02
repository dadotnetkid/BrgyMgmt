using DevExpress.Web.Mvc;
using BrgyMgmt.Web.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrgyMgmt.Web.Models;
using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.SqlServer;
using System.Text;
using System.Web.UI.WebControls;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    [RoutePrefix("transactions")]
    public class TransactionController : Controller {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        public ApplicationSignInManager SignInManager {
            get => _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            private set {
                _signInManager = value;
            }
        }
        public ApplicationUserManager UserManager {
            get {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set {
                _userManager = value;
            }
        }
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager {
            get {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set {
                _roleManager = value;
            }
        }
        private UnitOfWork unitOfWork = new Services.UnitOfWork();
        public TransactionController() { }
        public TransactionController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
            UserManager = userManager;
            SignInManager = signInManager;

            Configuration.DataProvider = new SqlDataProvider() {
                ConnectionString = BrgyMgmt.Web.Services.Constants.LocalConnectionString,
                Schema = "dbo",
                TableName = "CustomLogs",
                IdColumnName = "EventId",
                JsonColumnName = "JsonData",
                LastUpdatedDateColumnName = "LastUpdatedDate",
                CustomColumns = new List<CustomColumn>() {
                    new CustomColumn("EventType", ev => ev.EventType)
                }
            };
        }

        public ActionResult Index() {
            return View();
        }        
        #region Certificates
        [Route("certificates")]
        public ActionResult Certificates() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }
        }

        [ValidateInput(false)]
        public ActionResult gvCertificatesPartial() {
            ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            ViewBag.CertificateType = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 1).OrderBy(z => z.SortOrder).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            return PartialView("_gvCertificatesPartial", unitOfWork.CertificateRepository.Get());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvCertificatesPartialAddNew(BrgyMgmt.Web.Models.Certificate item) {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            ViewBag.CertificateType = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 1).OrderBy(z => z.SortOrder).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });

            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Certificates:Create", () => item)) {
                        unitOfWork.CertificateRepository.Insert(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCertificatesPartial", unitOfWork.CertificateRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCertificatesPartialUpdate(BrgyMgmt.Web.Models.Certificate item) {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            ViewBag.CertificateType = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 1).OrderBy(z => z.SortOrder).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Certificates:Update", () => item, new { LastUpdatedBy = User.Identity.Name })) {
                        unitOfWork.CertificateRepository.Update(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCertificatesPartial", unitOfWork.CertificateRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCertificatesPartialDelete(System.Int32 CertificateId) {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            ViewBag.CertificateType = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 1).OrderBy(z => z.SortOrder).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });

            if (CertificateId >= 0) {
                try {
                    using (AuditScope.Create("Certificates:Delete", () => CertificateId, new { LastUpdatedBy = User.Identity.Name })) {
                        Certificate certificate = unitOfWork.CertificateRepository.GetByID(CertificateId);
                        unitOfWork.CertificateRepository.Delete(certificate);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvCertificatesPartial", unitOfWork.CertificateRepository.Get());
        }
        [Route("certificates/viewer")]
        public ActionResult CertificateReportViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? certificateId) {
            var model = unitOfWork.CertificateRepository.Get(x => x.CertificateId == certificateId);
            var rpt = new rptCertificate() {
                DataSource = model
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }
        public ActionResult cmbResidentSearchPartial() {
            return PartialView("_cmbResidentSearchPartial");
        }
        public ActionResult pucValidateResidentPartial(int residentId = 0) {
            if (residentId != 0) {
                var resident = unitOfWork.ResidentRepository.GetByID(residentId);

                //var caseCount1 = resident.ComplaintRespondents.Count();

                //var caseCount = unitOfWork.ComplaintRepo.Get().Where(x => x.ResidentRespondents.Contains(resident)).Count();

                var hasCase = unitOfWork.ComplaintRepo.Get().Where(x => x.ResidentRespondents.Contains(resident) && x.ComplaintStatus == 323).Count() > 0;

                ViewBag.HasCase = hasCase.ToString();
                ViewBag.AlertMessage = resident.FullName + " has an ongoing case. Clearance is not possible.";

            }
            return PartialView("_pucValidateResidentPartial");
        }
        public ActionResult cmbTemplateTypePartial() {
            var residentId = Convert.ToInt32(Request.Params["residentId"]);
            var resident = unitOfWork.ResidentRepository.GetByID(residentId);
            var isNotCleared = unitOfWork.ComplaintRepo.Get().Where(x => x.ResidentRespondents.Contains(resident) 
            //&& x.ClearedRespondents == false
            ).Count() > 0;
            //bool isCleared = hasBlotter > 1;

            var allowedCertificates = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 1).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            if (isNotCleared) {
                allowedCertificates = allowedCertificates.Where(x => x.Id != 1);
                ViewBag.Notice = isNotCleared;
            }
            ViewBag.CertificateType = allowedCertificates;

            return PartialView("_cmbTemplateTypePartial");
        }
        #endregion
        #region CommunityTax
        [Route("community-tax-certificate")]
        public ActionResult CommunityTax() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }
        }

        [ValidateInput(false)]
        public ActionResult gvCommunityTaxPartial() {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            return PartialView("_gvCommunityTaxPartial", unitOfWork.CertificateCommunityRepo.Get());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvCommunityTaxPartialAddNew(BrgyMgmt.Web.Models.CertificateCommunity item) {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("CommunityTax:Create", () => item)) {
                        unitOfWork.CertificateCommunityRepo.Insert(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCommunityTaxPartial", unitOfWork.CertificateCommunityRepo.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCommunityTaxPartialUpdate(BrgyMgmt.Web.Models.CertificateCommunity item) {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("CommunityTax:Update", () => item, new { LastUpdatedBy = User.Identity.Name })) {
                        unitOfWork.CertificateCommunityRepo.Update(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvCommunityTaxPartial", unitOfWork.CertificateCommunityRepo.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvCommunityTaxPartialDelete(System.Int32 TaxCertificateId) {
            ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            if (TaxCertificateId >= 0) {
                try {
                    using (AuditScope.Create("CommunityTax:Delete", () => TaxCertificateId, new { LastUpdatedBy = User.Identity.Name })) {
                        var item = unitOfWork.CertificateCommunityRepo.GetByID(TaxCertificateId);
                        unitOfWork.CertificateCommunityRepo.Delete(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvCommunityTaxPartial", unitOfWork.CertificateCommunityRepo.Get());
        }
        [Route("certificates/community-tax")]
        public ActionResult CommunityTaxReportViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? taxCertificateid) {
            var model = unitOfWork.CertificateCommunityRepo.Get(x => x.TaxCertificateId == taxCertificateid);
            var rpt = new rptCommunityTax() {
                DataSource = model
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }
        #endregion
        #region Clearances
        [Route("clearances")]
        public ActionResult Clearances() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }
        }

        [ValidateInput(false)]
        public ActionResult gvClearancesPartial() {
            //ViewBag.Residents = unitOfWork.ResidentRepository.Get().Select(x => new { Id = x.ResidentId, Name = x.FullName });
            ViewBag.Purpose = unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Clearance").OrderBy(z => z.SortOrder).Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            return PartialView("_gvClearancesPartial", unitOfWork.ClearanceRepo.Get(includeProperties: "MaintenanceTables"));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvClearancesPartialAddNew(BrgyMgmt.Web.Models.Clearance item) {
            ViewBag.Purpose = unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Clearance").OrderBy(z => z.SortOrder).Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Clearance:Create", () => item)) {
                        //var currentPurposeList = item.MaintenanceTables.ToList();
                        var selectedPurposeIds = CheckBoxListExtension.GetSelectedValues<int>("Purpose");
                        //var selectedPurposeList = new List<MaintenanceTable>
                        foreach (var purposeId in selectedPurposeIds) {
                            var purposeToAdd = unitOfWork.MaintenanceTableRepository.GetByID(purposeId);
                            item.MaintenanceTables.Add(purposeToAdd);
                        }

                        unitOfWork.ClearanceRepo.Insert(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvClearancesPartial", unitOfWork.ClearanceRepo.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvClearancesPartialUpdate(BrgyMgmt.Web.Models.Clearance item) {
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Clearance:Update", () => item, new { LastUpdatedBy = User.Identity.Name })) {
                        using (var db = new BrgyMgmtEntities()) {
                            var model = db.Clearances.FirstOrDefault(it => it.ClearanceId == item.ClearanceId);
                            var modelColl = model.MaintenanceTables.ToList();

                            foreach (var collItem in modelColl) {
                                model.MaintenanceTables.Remove(collItem);
                            }

                            var selectedPurposeIds = CheckBoxListExtension.GetSelectedValues<int>("Purpose");
                            foreach (var purposeId in selectedPurposeIds) {
                                var purposeToAdd = db.MaintenanceTables.Find(purposeId);
                                model.MaintenanceTables.Add(purposeToAdd);
                            }
                            this.UpdateModel(model);
                            db.SaveChanges();
                        }
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvClearancesPartial", unitOfWork.ClearanceRepo.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvClearancesPartialDelete(System.Int32 ClearanceId) {
            if (ClearanceId >= 0) {
                try {
                    using (AuditScope.Create("Clearance:Delete", () => ClearanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        var item = unitOfWork.ClearanceRepo.GetByID(ClearanceId);
                        unitOfWork.ClearanceRepo.Delete(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvClearancesPartial", unitOfWork.ClearanceRepo.Get());
        }
        [Route("certificates/clearances")]
        public ActionResult ClearanceReportViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int? clearanceId) {
            IList<ClearanceReport> clearanceReport = GetClearanceReportData(clearanceId);
            var rpt = new rptClearance() {
                DataSource = clearanceReport
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }
        private IList<ClearanceReport> GetClearanceReportData(int? clearanceId) {
            using (var db = new BrgyMgmtEntities()) {
                var model = db.Clearances.Where(x => x.ClearanceId == clearanceId);
                var report = model.Select(x => new {
                    ClearanceId = x.ClearanceId, Birthdate = x.Resident.BirthDate, CivilStatus = x.Resident.CivilStatus, Gender = x.Resident.Gender,
                    ResidentName = x.Resident.FullName.ToUpper(), RoomNumber = x.Resident.Household.RoomNumber, x.Resident.Household.FloorNumber,
                    x.Resident.Household.BuildingNumber, x.Resident.Household.StreetName, x.Resident.Household.SitioId, x.Resident.Photo, x.IssuedDate,
                    x.CTC, x.CTCDate, x.ORNumber, x.YearsOfStay, x.CTCPlaceIssued, MaintenanceTables = x.MaintenanceTables
                }).AsEnumerable()
                .Select(c => new ClearanceReport {
                    ClearanceId = c.ClearanceId, Age = GetAge(c.Birthdate), CivilStatus = c.CivilStatus, Gender = c.Gender, ResidentName = c.ResidentName,
                    Address = GetFullAddress(c.RoomNumber, c.FloorNumber, c.BuildingNumber, c.StreetName, c.SitioId), Photo = c.Photo, CTC = c.CTC, CTCDate = c.CTCDate,
                    IssuedDate = c.IssuedDate, ORNumber = c.ORNumber, YearsOfStay = c.YearsOfStay, CTCPlaceIssued = c.CTCPlaceIssued, ClearanceReportPurposes = GetClearancePurposes(c.MaintenanceTables)
                }).ToList();

                //var uuu = (from u in model select u).AsEnumerable().Select(c => new ClearanceReport {  }).ToList();


                return report;
            }
        }
        private List<ClearanceReportPurposes> GetClearancePurposes(ICollection<MaintenanceTable> maintenanceTables) {
            List<ClearanceReportPurposes> list = new List<ClearanceReportPurposes>();
            var purposeTypes = unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Clearance");
            foreach (var purpose in purposeTypes) {
                list.Add(new ClearanceReportPurposes { isUsed = maintenanceTables.Where(x => x.MaintenanceEntryName == purpose.MaintenanceEntryName).Count() > 0, ReportPurpose = purpose.MaintenanceEntryName });
                //var clearanceReportPurpose = new ClearanceReportPurposes { isUsed = maintenanceTables.Where(x => x.MaintenanceEntryName == purpose.MaintenanceEntryName).Count() > 0, ReportPurpose  = purpose.MaintenanceEntryName };
            }

            return list;
        }
        private int GetAge(DateTime birthDate) {
            DateTime Today = DateTime.Now;
            TimeSpan ts = Today - birthDate;
            DateTime Age = DateTime.MinValue + ts;
            return Age.Year - 1;
        }
        private string GetFullAddress(string roomNumber, string floorNumber, string buildingNumber, string streetName, int? sitioId) {
            StringBuilder sb = new StringBuilder();
            if (roomNumber != null) sb.Append("Rm. " + roomNumber + ", ");
            if (floorNumber != null) sb.Append(floorNumber + ", ");
            if (buildingNumber != null) sb.Append(buildingNumber + " ");
            if (streetName != null) sb.Append(streetName + " ,");
            if (sitioId != null) sb.Append(unitOfWork.MaintenanceTableRepository.GetByID(sitioId).MaintenanceEntryName + " ,");
            sb.Append("Quezon, Nueva Vizcaya");
            return sb.ToString();
        }

        #endregion
    }
}