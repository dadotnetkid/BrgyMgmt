using DevExpress.Web.Mvc;
using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.SqlServer;
using System.Text;
using System.Drawing;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    [RoutePrefix("maintenance")]
    public class MaintenanceController : Controller {
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
        private UnitOfWork unitOfWork = new UnitOfWork();

        public MaintenanceController() { }
        public MaintenanceController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
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





        #region Document
        [Route("barangay-setup/configurations")]
        public ActionResult Configurations() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            //var model = BarangayProfileData.Get();
            return View();
            //return View(model);
        }

        #endregion

        #region Profile
        [Route("barangay-setup/profile")]
        public ActionResult BarangayProfile() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            //var model = BarangayProfileData.Get();
            return View();
        }
        //public ActionResult cbpProfilePartial(BarangayProfileData data) {
        //    if (Request.Params["actionParam"] == "update") {
        //        BarangayProfileData.Update(data);
        //    }
        //    return PartialView("_cbpProfilePartial", BarangayProfileData.Get());
        //}
        #endregion
        #region Officials
        [Route("barangay-setup/officials")]
        public ActionResult Officials() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvOfficialsPartial() {
            //var model = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).OrderBy(x => x.SortOrder);
            var model = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder);
            ViewBag.Committees = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Committee").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            return PartialView("_gvOfficialsPartial", model);
        }

        private string GetCommitteNames(string committees) {
            if (string.IsNullOrEmpty(committees)) return string.Empty;
            StringBuilder sb = new StringBuilder();
            var Committees = unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Committee");
            foreach (var item in committees.Split(',')) {
                sb.Append(Committees.Where(x => x.MaintenanceId == Convert.ToInt32(item)).Select(x => x.MaintenanceEntryName).SingleOrDefault() + "<br/>");
            }
            return sb.ToString();
            //var userCommitteeList = committees.Split(',').ToList();
            //var Committees = unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Committee");
            //var userCommitteeListNames = Committees.Join(userCommitteeList, c => c.MaintenanceId, u => u.)
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvOfficialsPartialAddNew(BrgyMgmt.Web.Models.Employee item) {
            //var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Officials:Create", () => item)) {
                        item.EmployeeType = 1;

                        item.Committees = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Committees"));


                        //item.Committees = item.BiometricCapture ?? new byte[0];
                        unitOfWork.EmployeeRepository.Insert(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvOfficialsPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).OrderBy(x => x.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvOfficialsPartialUpdate(BrgyMgmt.Web.Models.Employee item) {
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Officials:Update", () => item)) {
                        item.EmployeeType = 1;

                        item.Committees = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Committees"));


                        //item.Committees = item.BiometricCapture ?? new byte[0];
                        unitOfWork.EmployeeRepository.Update(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvOfficialsPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvOfficialsPartialDelete(System.Int32 EmployeeId) {
            var model = new object[0];
            if (EmployeeId >= 0) {
                try {
                    using (AuditScope.Create("Employee:Delete", () => EmployeeId, new { LastUpdatedBy = User.Identity.Name })) {
                        Employee employee = unitOfWork.EmployeeRepository.GetByID(EmployeeId);
                        unitOfWork.EmployeeRepository.Delete(employee);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvOfficialsPartial", model);
        }

        #endregion
        #region Staff
        [Route("barangay-setup/staff")]
        public ActionResult Staff() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvStaffPartial() {
            var model = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 2).OrderBy(z => z.EndDate);
            ViewBag.Committees = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Committee").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            return PartialView("_gvStaffPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 2).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvStaffPartialAddNew(BrgyMgmt.Web.Models.Employee item) {
            ViewBag.Committees = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Committee").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Employee:Create", () => item)) {
                        item.EmployeeType = 2;

                        item.Committees = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Committees"));


                        //item.Committees = item.BiometricCapture ?? new byte[0];
                        unitOfWork.EmployeeRepository.Insert(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvStaffPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 2).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvStaffPartialUpdate(BrgyMgmt.Web.Models.Employee item) {
            ViewBag.Committees = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Committee").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ModelState.IsValid) {
                try {
                    item.EmployeeType = 2;

                    item.Committees = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Committees"));

                    unitOfWork.EmployeeRepository.Update(item);
                    unitOfWork.Save();
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvStaffPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 2).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvStaffPartialDelete(System.Int32 EmployeeId) {
            ViewBag.Committees = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Committee").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (EmployeeId >= 0) {
                try {
                    using (AuditScope.Create("Staff:Delete", () => EmployeeId, new { LastUpdatedBy = User.Identity.Name })) {
                        Employee employee = unitOfWork.EmployeeRepository.GetByID(EmployeeId);
                        unitOfWork.EmployeeRepository.Delete(employee);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvStaffPartial", unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 2).Select(x => new { x.EmployeeId, x.EmployeeName, x.EmployeeType, x.StartDate, x.EndDate, x.SortOrder, x.Designation, x.Committees, CommitteeNames = GetCommitteNames(x.Committees) }).OrderBy(x => x.SortOrder));
        }

        #endregion      
        #region Certificate Templates
        [Route("barangay-setup/certificate-templates")]
        public ActionResult Templates() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvLetterTemplatesPartial() {
            var model = unitOfWork.LetterTemplateRepository.Get();
            return PartialView("_gvLetterTemplatesPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvLetterTemplatesPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] LetterTemplate item) {
            if (ModelState.IsValid) {
                try {
                    item.CreatedBy = User.Identity.Name;
                    item.DateCreated = DateTime.Now;

                    unitOfWork.LetterTemplateRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLetterTemplatesPartial", unitOfWork.LetterTemplateRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLetterTemplatesPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] BrgyMgmt.Web.Models.LetterTemplate item) {
            if (ModelState.IsValid) {
                try {
                    var modelItem = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateId == item.TemplateId).SingleOrDefault();

                    modelItem.TemplateName = item.TemplateName;
                    modelItem.TemplateBody = item.TemplateBody;
                    modelItem.SortOrder = item.SortOrder;

                    unitOfWork.LetterTemplateRepository.Update(modelItem);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLetterTemplatesPartial", unitOfWork.LetterTemplateRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLetterTemplatesPartialDelete(System.Guid TemplateId) {
            var model = new object[0];
            if (TemplateId != null) {
                try {
                    using (AuditScope.Create("LetterTemplate:Delete", () => TemplateId, new { LastUpdatedBy = User.Identity.Name })) {
                        LetterTemplate template = unitOfWork.LetterTemplateRepository.GetByID(TemplateId);
                        unitOfWork.LetterTemplateRepository.Delete(template);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvLetterTemplatesPartial", model);
        }

        #endregion


        #region Religion
        [Route("resident-config/religions")]
        public ActionResult Religions() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvReligionsPartial() {
            return PartialView("_gvReligionsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Religion").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvReligionsPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Religion";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvReligionsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Religion").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvReligionsPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvReligionsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Religion").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvReligionsPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Religion:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvReligionsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Religion").OrderBy(z => z.SortOrder));
        }
        #endregion
        #region Ethnicity
        [Route("resident-config/ethnicities")]
        public ActionResult Ethnicities() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvEthnicitiesPartial() {
            return PartialView("_gvEthnicitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Ethnicity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEthnicitiesPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Ethnicity";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEthnicitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Ethnicity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEthnicitiesPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEthnicitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Ethnicity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEthnicitiesPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Ethnicities:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvEthnicitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Ethnicity").OrderBy(z => z.SortOrder));
        }
        #endregion
        #region Relationships
        [Route("resident-config/relationships")]
        public ActionResult Relationships() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        BrgyMgmt.Web.Models.BrgyMgmtEntities db1 = new BrgyMgmt.Web.Models.BrgyMgmtEntities();

        [ValidateInput(false)]
        public ActionResult gvRelationshipsPartial() {
            var model = db1.MaintenanceTables;
            return PartialView("_gvRelationshipsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Relationship").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelationshipsPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Relationship";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                    db1.SaveChanges();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvRelationshipsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Relationship").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelationshipsPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvRelationshipsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Relationship").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelationshipsPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Relationship:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvRelationshipsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Relationship").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Education
        [Route("resident-config/education")]
        public ActionResult Education() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvEducationPartial() {
            return PartialView("_gvEducationPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducationStatus").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "EducationStatus";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEducationPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducationStatus").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEducationPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducationStatus").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Education:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvEducationPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducationStatus").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Educational Attainment
        [Route("resident-config/educational-attainment")]

        public ActionResult EducationalAttainment() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvEducationalAttainmentPartial() {
            return PartialView("_gvEducationalAttainmentPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducAttainment").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationalAttainmentPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("EducationAttainment:Create", () => item)) {
                        item.MaintenanceTableType = "EducAttainment";
                        unitOfWork.MaintenanceTableRepository.Insert(item);
                        unitOfWork.Save();
                    }                    
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEducationalAttainmentPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducAttainment").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationalAttainmentPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("EducationAttainment:Update", () => item)) {
                        unitOfWork.MaintenanceTableRepository.Update(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEducationalAttainmentPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducAttainment").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEducationalAttainmentPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("EducationAttainment:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvEducationalAttainmentPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "EducAttainment").OrderBy(z => z.SortOrder));
        }

        #endregion

        #region Land Tenure
        [Route("household-config/land-tenure")]
        public ActionResult LandTenure() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvLandTenurePartial() {
            return PartialView("_gvLandTenurePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "LandTenure").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvLandTenurePartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "LandTenure";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLandTenurePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "LandTenure").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLandTenurePartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLandTenurePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "LandTenure").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLandTenurePartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("LandTenure:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvLandTenurePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "LandTenure").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Monthly Income
        [Route("household-config/monthly-income")]
        public ActionResult MonthlyIncome() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvMonthlyIncomePartial() {
            return PartialView("_gvMonthlyIncomePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "MonthlyIncome").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvMonthlyIncomePartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "MonthlyIncome";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvMonthlyIncomePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "MonthlyIncome").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvMonthlyIncomePartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvMonthlyIncomePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "MonthlyIncome").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvMonthlyIncomePartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("MonthlyIncome:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvMonthlyIncomePartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "MonthlyIncome").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Water Supplies
        [Route("household-config/water-supplies")]
        public ActionResult WaterSupplies() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvWaterSuppliesPartial() {
            return PartialView("_gvWaterSuppliesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "WaterSupply").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvWaterSuppliesPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "WaterSupply";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvWaterSuppliesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "WaterSupply").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvWaterSuppliesPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvWaterSuppliesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "WaterSupply").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvWaterSuppliesPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("WaterSupplies:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvWaterSuppliesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "WaterSupply").OrderBy(z => z.SortOrder));
        }



        #endregion
        #region Toilet Facilities
        [Route("household-config/toilet-facilities")]
        public ActionResult ToiletFacilities() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvToiletFacilitiesPartial() {
            return PartialView("_gvToiletFacilitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "ToiletFacility").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvToiletFacilitiesPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "ToiletFacility";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvToiletFacilitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "ToiletFacility").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvToiletFacilitiesPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvToiletFacilitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "ToiletFacility").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvToiletFacilitiesPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("ToiletFacilities:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvToiletFacilitiesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "ToiletFacility").OrderBy(z => z.SortOrder));
        }



        #endregion
        #region Power Sources
        [Route("household-config/power-sources")]
        public ActionResult PowerSources() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvPowerSourcesPartial() {
            return PartialView("_gvPowerSourcesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Electricity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvPowerSourcesPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Electricity";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvPowerSourcesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Electricity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvPowerSourcesPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvPowerSourcesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Electricity").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvPowerSourcesPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("PowerSources:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvPowerSourcesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Electricity").OrderBy(z => z.SortOrder));
        }
        #endregion
        #region  Waste Disposal
        [Route("household-config/waste-disposal")]
        public ActionResult WasteDisposal() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvWasteDisposalPartial() {
            return PartialView("_gvWasteDisposalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "SanitationPractice").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvWasteDisposalPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "SanitationPractice";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvWasteDisposalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "SanitationPractice").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvWasteDisposalPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvWasteDisposalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "SanitationPractice").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvWasteDisposalPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("WasteDisposal:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvWasteDisposalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "SanitationPractice").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Vegetable Garden
        [Route("household-config/vegetable-gardens")]
        public ActionResult VegetableGardens() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvVegetableGardensPartial() {
            return PartialView("_gvVegetableGardensPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Garden").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvVegetableGardensPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Garden";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvVegetableGardensPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Garden").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvVegetableGardensPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvVegetableGardensPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Garden").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvVegetableGardensPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("VegetableGarden:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvVegetableGardensPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Garden").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Family Planning
        [Route("household-config/family-planning")]
        public ActionResult FamilyPlanning() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvFamilyPlanningPartial() {
            return PartialView("_gvFamilyPlanningPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "FamilyPlanning").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvFamilyPlanningPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "FamilyPlanning";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvFamilyPlanningPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "FamilyPlanning").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvFamilyPlanningPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvFamilyPlanningPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "FamilyPlanning").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvFamilyPlanningPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("FamilyPlanning:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvFamilyPlanningPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "FamilyPlanning").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Breast Feeding
        [Route("household-config/breast-feeding")]
        public ActionResult BreastFeeding() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvBreastFeedingPartial() {
            var model = new object[0];
            return PartialView("_gvBreastFeedingPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "BreastFeed").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvBreastFeedingPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "BreastFeed";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvBreastFeedingPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "BreastFeed").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvBreastFeedingPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvBreastFeedingPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "BreastFeed").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvBreastFeedingPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("BreastFeeding:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvBreastFeedingPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "BreastFeed").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Other Nutritional Info
        [Route("household-config/other-nutritional-info")]
        public ActionResult OtherNutritional() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvOtherNutritionalPartial() {
            var model = new object[0];
            return PartialView("_gvOtherNutritionalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "OtherNutrition").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvOtherNutritionalPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "OtherNutrition";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvOtherNutritionalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "OtherNutrition").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvOtherNutritionalPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvOtherNutritionalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "OtherNutrition").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvOtherNutritionalPartialDelete(System.Int32 MaintenanceId) {
            var model = new object[0];
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("OtherNutritional:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvOtherNutritionalPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "OtherNutrition").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Livestock
        [Route("household-config/livestock")]
        public ActionResult Livestock() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvLivestockPartial() {
            return PartialView("_gvLivestockPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Livestock").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvLivestockPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Livestock";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLivestockPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Livestock").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLivestockPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvLivestockPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Livestock").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvLivestockPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Livestock:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvLivestockPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Livestock").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Vehicles
        [Route("household-config/vehicles")]
        public ActionResult Vehicles() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvVehiclesPartial() {
            return PartialView("_gvVehiclesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Vehicle").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvVehiclesPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Vehicle";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvVehiclesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Vehicle").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvVehiclesPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvVehiclesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Vehicle").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvVehiclesPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Vehicles:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.ResidentRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvVehiclesPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Vehicles").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Equipments
        [Route("household-config/equipments")]
        public ActionResult Equipments() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvEquipmentsPartial() {
            var model = new object[0];
            return PartialView("_gvEquipmentsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Equipment").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvEquipmentsPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Equipment";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEquipmentsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Equipment").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEquipmentsPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvEquipmentsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Equipment").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvEquipmentsPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("Equipment:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvEquipmentsPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Equipment").OrderBy(z => z.SortOrder));
        }

        #endregion
        #region Children Count
        [Route("household-config/children-count")]
        public ActionResult ChildrenCount() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvChildrenPartial() {
            var model = new object[0];
            return PartialView("_gvChildrenPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Children").OrderBy(z => z.SortOrder));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvChildrenPartialAddNew(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    item.MaintenanceTableType = "Children";
                    unitOfWork.MaintenanceTableRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvChildrenPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Children").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvChildrenPartialUpdate(BrgyMgmt.Web.Models.MaintenanceTable item) {
            if (ModelState.IsValid) {
                try {
                    unitOfWork.MaintenanceTableRepository.Update(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvChildrenPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Children").OrderBy(z => z.SortOrder));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvChildrenPartialDelete(System.Int32 MaintenanceId) {
            if (MaintenanceId >= 0) {
                try {
                    using (AuditScope.Create("WasteDisposal:Delete", () => MaintenanceId, new { LastUpdatedBy = User.Identity.Name })) {
                        MaintenanceTable mainentance = unitOfWork.MaintenanceTableRepository.GetByID(MaintenanceId);
                        unitOfWork.MaintenanceTableRepository.Delete(mainentance);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvChildrenPartial", unitOfWork.MaintenanceTableRepository.Get().Where(x => x.MaintenanceTableType == "Children").OrderBy(z => z.SortOrder));
        }

        #endregion


        public ActionResult reProfilePartial() {
            return PartialView("_reProfilePartial");
        }
    }
}