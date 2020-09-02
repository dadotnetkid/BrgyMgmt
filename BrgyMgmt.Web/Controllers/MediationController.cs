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
using System.Reflection;
using System.ComponentModel;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    public class MediationController : Controller {
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
        //public ActionResult Index() {
        //    ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
        //    return View();
        //}
        BrgyMgmt.Web.Models.BrgyMgmtEntities db = new BrgyMgmt.Web.Models.BrgyMgmtEntities();
        public ActionResult LargeDataComboBoxPartial() {
            return PartialView("_cbResidentPartial");
        }
        #region Complaints
        public ActionResult Complaints() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult gvComplaintsPartial() {
            var model = unitOfWork.ComplaintRepo.Get(includeProperties: "ResidentRespondents");
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.DisputeNature = maintenance.Where(z => z.MaintenanceTableType == "Dispute").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.SettlementMode = maintenance.Where(z => z.MaintenanceTableType == "SettlementMode").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.DisputeAction = maintenance.Where(z => z.MaintenanceTableType == "DisputeAction").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            return PartialView("_gvComplaintsPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintsPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Complaint item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.DisputeNature = maintenance.Where(z => z.MaintenanceTableType == "Dispute").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.SettlementMode = maintenance.Where(z => z.MaintenanceTableType == "SettlementMode").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.DisputeAction = maintenance.Where(z => z.MaintenanceTableType == "DisputeAction").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ModelState.IsValid) {
                try {
                    item.DateTimeRecorded = DateTime.Now;
                    unitOfWork.ComplaintRepo.Insert(item);

                    String[] residentListBoxes = new string[] { "lbResidentComplainants", "lbResidentRespondents", "lbResidentVictims" };
                    for (int i = 0; i < residentListBoxes.Count(); i++) {
                        //var lb = residentListBoxes[i];
                        var listbox = ListBoxExtension.GetSelectedValues<string>(residentListBoxes[i]);
                        if (ListBoxExtension.GetSelectedValues<string>(residentListBoxes[i]) != null) {
                            foreach (var lbItem in listbox) {
                                var resident = unitOfWork.ResidentRepository.GetByID(Convert.ToInt32(lbItem));
                                switch (residentListBoxes[i]) {
                                    case "lbResidentComplainants":
                                        item.ResidentComplainants.Add(resident);
                                        break;
                                    case "lbResidentRespondents":
                                        item.ResidentRespondents.Add(resident);
                                        break;
                                    case "lbResidentVictims":
                                        item.ResidentVictims.Add(resident);
                                        break;
                                }
                            }
                        }
                    }
                    //model.Add(item);
                    unitOfWork.Save();
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvComplaintsPartial", unitOfWork.ComplaintRepo.Get(includeProperties: "ResidentComplainants, ResidentRespondents, ResidentVictims"));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintsPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Complaint item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.DisputeNature = maintenance.Where(z => z.MaintenanceTableType == "Dispute").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.SettlementMode = maintenance.Where(z => z.MaintenanceTableType == "SettlementMode").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.DisputeAction = maintenance.Where(z => z.MaintenanceTableType == "DisputeAction").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ModelState.IsValid) {
                try {
                    var modelItem = unitOfWork.ComplaintRepo.Get().Where(x => x.ComplaintId == item.ComplaintId).SingleOrDefault();

                    String[] residentListBoxes = new string[] { "lbResidentComplainants", "lbResidentRespondents", "lbResidentVictims" };
                    for (int i = 0; i < residentListBoxes.Count(); i++) {
                        var modelItemTpe = (i < 1) ? modelItem.ResidentComplainants : (i > 1) ? modelItem.ResidentVictims : modelItem.ResidentRespondents;

                        var listbox = ListBoxExtension.GetSelectedValues<string>(residentListBoxes[i]);

                        var currentResidentTypeList = new List<Resident>();
                        var controlResidentList = new List<Resident>();
                        var residentsToRemoveInComplaint = new List<Resident>();
                        var residentsToAddInComplaint = new List<Resident>();

                        currentResidentTypeList = modelItemTpe.ToList();

                        if (ListBoxExtension.GetSelectedValues<string>(residentListBoxes[i]).Count() > 0) {
                            foreach (var lbItem in listbox) {
                                foreach (var residentInControl in listbox) {
                                    controlResidentList.Add(unitOfWork.ResidentRepository.GetByID(Convert.ToInt32(residentInControl)));
                                }
                                residentsToRemoveInComplaint = currentResidentTypeList.Where(p => !controlResidentList.Any(p2 => p2.ResidentId == p.ResidentId)).ToList();
                                residentsToAddInComplaint = controlResidentList.Where(p => !currentResidentTypeList.Any(p2 => p2.ResidentId == p.ResidentId)).ToList();

                                foreach (var residentToRemove in residentsToRemoveInComplaint) {
                                    modelItemTpe.Remove(residentToRemove);
                                }
                                foreach (var residentToAdd in residentsToAddInComplaint) {
                                    modelItemTpe.Add(residentToAdd);
                                }
                            }
                        } else {
                            foreach (var residentToRemove in currentResidentTypeList) {
                                modelItemTpe.Remove(residentToRemove);
                            }
                        }
                    }
                    modelItem.ComplaintTitle = item.ComplaintTitle;
                    modelItem.ComplainantNarrative = item.ComplainantNarrative;
                    modelItem.IncidentDateTime = item.IncidentDateTime;
                    modelItem.IncidentLocation = item.IncidentLocation;
                    modelItem.DisputeNature = item.DisputeNature;
                    modelItem.NonResidentComplainants = item.NonResidentComplainants;
                    modelItem.NonResidentRespondents = item.NonResidentRespondents;
                    modelItem.NonResidentVictims = item.NonResidentVictims;
                    modelItem.ModeOfSettlement = item.ModeOfSettlement;
                    modelItem.ComplaintStatus = item.ComplaintStatus;
                    modelItem.GovernmentSavings = item.GovernmentSavings;
                    modelItem.Remarks = item.Remarks;


                    unitOfWork.ComplaintRepo.Update(modelItem);
                    unitOfWork.Save();
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvComplaintsPartial", unitOfWork.ComplaintRepo.Get(includeProperties: "ResidentComplainants, ResidentRespondents, ResidentVictims"));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintsPartialDelete(System.Int32 ComplaintId) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.DisputeNature = maintenance.Where(z => z.MaintenanceTableType == "Dispute").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.SettlementMode = maintenance.Where(z => z.MaintenanceTableType == "SettlementMode").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.DisputeAction = maintenance.Where(z => z.MaintenanceTableType == "DisputeAction").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ComplaintId >= 0) {
                try {
                    using (AuditScope.Create("Complaint:Delete", () => ComplaintId, new { LastUpdatedBy = User.Identity.Name })) {
                        var item = unitOfWork.ComplaintRepo.GetByID(ComplaintId);
                        unitOfWork.ComplaintRepo.Delete(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvComplaintsPartial", unitOfWork.ComplaintRepo.Get(includeProperties: "ResidentComplainants, ResidentRespondents, ResidentVictims"));
        }
        public ActionResult ComplaintReportViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int complaintId) {
            var report = FetchComplaintReportData(complaintId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == complaintId);
            var rpt = new rptComplaint() {
                DataSource = report
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }

        private IEnumerable<ComplaintReport> FetchComplaintReportData(int v) {
            //var rep = 

            return unitOfWork.ComplaintRepo.Get().Where(y => y.ComplaintId == v).Select(x => new ComplaintReport {
                ComplaintId = x.ComplaintId, ComplaintTitle = x.ComplaintTitle, DateReported = x.IncidentDateTime,

                DateRecorded = x.DateTimeRecorded, IncidentLocation = x.IncidentLocation,
                //IncidentType = "ascascsac",
                IncidentType = unitOfWork.MaintenanceTableRepository.GetByID(x.DisputeNature).MaintenanceEntryName,
                //Enum.GetName(typeof(IncidentType),
                //,
                Narative = x.ComplainantNarrative,
                //ResidentRespondents = "sdsdf",
                ResidentComplainants = GetResidentNames(x.ResidentComplainants),
                ResidentRespondents = GetRespondentNamesToString(x.ResidentRespondents),
                ResidentVictims = GetVictimNamesToString(x.ResidentVictims),
                NonResidentComplainants = x.NonResidentComplainants, NonResidentRespondents = x.NonResidentRespondents,
                NonResidentVictims = x.NonResidentVictims
            });
            //var count = rep.Count();
            //return rep;
        }
        private string GetEnumDescription(Enum value) {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attributes != null && attributes.Any()) {
                return attributes.First().Description;
            }
            return value.ToString();
        }
        private static string GetResidentNames(ICollection<Resident> residentList) {
            var fullNames = residentList.Select(x => x.FullName);
            var respondents = string.Join(",", fullNames.ToArray());
            return respondents;
        }
        private static string GetRespondentNamesToString(ICollection<Resident> residentRespondents) {
            var fullNames = residentRespondents.Select(x => x.FullName);
            var respondents = string.Join(",", fullNames.ToArray());
            return respondents;
        }
        private static string GetComplainantNamesToString(ICollection<Resident> residentComplainants) {
            var fullNames = residentComplainants.Select(x => x.FullName);
            var respondents = string.Join("<br>", fullNames.ToArray());
            return respondents;
        }
        private static string GetVictimNamesToString(ICollection<Resident> residentVictims) {
            var fullNames = residentVictims.Select(x => x.FullName);
            var respondents = string.Join("<br>", fullNames.ToArray());
            return respondents;
        }

        public ActionResult cmbComplainantsPartial() {
            return PartialView("_cmbComplainantsPartial");
        }
        public ActionResult cmbRespondentsPartial() {
            return PartialView("_cmbRespondentsPartial");
        }
        public ActionResult cmbVictimsPartial() {
            return PartialView("_cmbVictimsPartial");
        }
        public ActionResult cmbComplaintSearchPartial() {
            return PartialView("_cmbComplaintSearchPartial");
        }
        #endregion
        #region Settlement Detail

        [ValidateInput(false)]
        public ActionResult gvComplaintSettlementDetailPartial(int complaintId) {
            ViewBag.Officers = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { Id = x.EmployeeId, Name = x.EmployeeName });
            ViewBag.Template = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 2).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });

            ViewData["ComplaintId"] = complaintId;
            var model = unitOfWork.SettlementRepository.Get().Where(x => x.ComplaintId == complaintId);
            model = model.Count() == 0 ? new List<Settlement>() : model;


            return PartialView("_gvComplaintSettlementDetailPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintSettlementDetailPartialAddNew(BrgyMgmt.Web.Models.Settlement item, int complaintId) {
            ViewBag.Officers = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { Id = x.EmployeeId, Name = x.EmployeeName });
            ViewBag.Template = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 2).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            ViewData["ComplaintId"] = complaintId;
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Settlement:Create", () => item)) {
                        item.ComplaintId = complaintId;
                        item.CreatedBy = User.Identity.Name;
                        unitOfWork.SettlementRepository.Insert(item);
                        unitOfWork.Save();
                    }

                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvComplaintSettlementDetailPartial", unitOfWork.SettlementRepository.Get().Where(x => x.ComplaintId == complaintId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintSettlementDetailPartialUpdate(BrgyMgmt.Web.Models.Settlement item, int complaintId) {
            ViewBag.Officers = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { Id = x.EmployeeId, Name = x.EmployeeName });
            ViewBag.Template = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 2).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            ViewData["complaintId"] = complaintId;
            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Settlement:Update", () => item)) {
                        item.LastUpdatedBy = User.Identity.Name;
                        item.ComplaintId = complaintId;
                        unitOfWork.SettlementRepository.Update(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvComplaintSettlementDetailPartial", unitOfWork.SettlementRepository.Get().Where(x => x.ComplaintId == complaintId));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvComplaintSettlementDetailPartialDelete(System.Int32 SettlementId, int complaintId) {
            ViewBag.Officers = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { Id = x.EmployeeId, Name = x.EmployeeName });
            ViewBag.Template = unitOfWork.LetterTemplateRepository.Get().Where(x => x.TemplateType == 2).Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });
            ViewData["complaintId"] = complaintId;
            if (SettlementId >= 0) {
                try {
                    using (AuditScope.Create("Employee:Delete", () => SettlementId, new { LastUpdatedBy = User.Identity.Name })) {
                        var item = unitOfWork.SettlementRepository.GetByID(SettlementId);
                        unitOfWork.SettlementRepository.Delete(item);
                        unitOfWork.Save();
                    }
                } catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvComplaintSettlementDetailPartial", unitOfWork.SettlementRepository.Get().Where(x => x.ComplaintId == complaintId));
        }
        public ActionResult SummonReportViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId) {
            //var report = FetchComplaintReportData(2);
            var report = GetSummonData(summonId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == complaintId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptSummon() {
                DataSource = report
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }
        private object GetSummonData(int v) {
            var data = unitOfWork.SettlementRepository.Get().Where(x => x.SettlementId == v).Select(x => new SummonReport {
                SettlementId = x.SettlementId,
                ComplaintId = x.ComplaintId, Title = x.Complaint.ComplaintTitle,
                SettlementDate = x.SettlementDate,
                Location = x.Location,
                PresidingStaff = GetStaffDetails(x.PresidingStaff),
                LetterDelivered = x.LetterDelivered,
                LetterAcknowledged = x.LetterAcknowledged,
                LetterTemplate = x.LetterTemplate,
                CaseClosed = x.CaseClosed,
                LetterContent = x.LetterContent,
                Decision = x.Decision,
                CreatedBy = x.CreatedBy,
                Complainants = GetNamesToString(x.Complaint.ResidentComplainants, x.Complaint.NonResidentComplainants),
                Respondents = GetNamesToString(x.Complaint.ResidentRespondents, x.Complaint.NonResidentRespondents),
                Victims = GetNamesToString(x.Complaint.ResidentVictims, x.Complaint.NonResidentVictims)

            });
            return data;
        }
        private string GetStaffDetails(int presidingStaff) {
            var staff = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeId == presidingStaff).SingleOrDefault();
            return staff.EmployeeName + "\r\n" + staff.Designation;

        }
        private string GetNamesToString(ICollection<Resident> residents, string nonResident) {
            var fullNames = residents.Select(x => x.FullName);
            var residentList = string.Join(",", fullNames.ToArray());
            if (!string.IsNullOrWhiteSpace(nonResident)) {
                residentList += ", " + nonResident;
            }
            return residentList;
        }
        public ActionResult InvitationViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId = 0) {
            //var report = FetchComplaintReportData(2);
            //var report = GetSummonData(summonId);
            var report = unitOfWork.SettlementRepository.Get(x => x.SettlementId == summonId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptInvitation() {
                DataSource = report
            };
            return PartialView("_pucInvitationViewerPartial", rpt);
        }
        public ActionResult ViewInvite([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId = 0) {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath; var report = unitOfWork.SettlementRepository.Get(x => x.SettlementId == summonId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptInvitation() {
                DataSource = report
            };
            return View("ViewInvite", rpt);
        }

        public ActionResult ReturnLetterViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId) {
            //var report = FetchComplaintReportData(2);
            //var report = GetSummonData(summonId);
            var report = unitOfWork.SettlementRepository.Get(x => x.SettlementId == summonId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptInvitationReturn() {
                DataSource = report
            };
            return PartialView("_pucReportViewerPartial", rpt);
        }

        public ActionResult ReturnViewerPartial([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId = 0) {
            
            var result = int.TryParse(Request.Params["summonId"], out int number);
            var settlementId = result ? number : 0;
            //var report = FetchComplaintReportData(2);
            //var report = GetSummonData(summonId);
            var report = unitOfWork.SettlementRepository.Get(x => x.SettlementId == settlementId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptInvitation() {
                DataSource = report
            };
            return PartialView("_pucViewerPartial", rpt);
        }

        public ActionResult pucViewerReport([ModelBinder(typeof(DevExpressEditorsBinder))] int summonId = 0) {
            //var report = FetchComplaintReportData(2);
            //var report = GetSummonData(summonId);
            var report = unitOfWork.SettlementRepository.Get(x => x.SettlementId == summonId);
            //var model = unitOfWork.ComplaintRepository.Get(x => x.complaintId == 2);
            var rpt = new rptInvitationReturn() {
                DataSource = report
            };
            return PartialView("_pucViewerPartial", rpt);
        }
        



        #endregion



        #region Settlements
        [Route("mediation/settlements")]
        public ActionResult Settlements() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }


        [ValidateInput(false)]
        public ActionResult gvSettlementsPartial() {
            ViewBag.Officers = unitOfWork.EmployeeRepository.Get().Where(x => x.EmployeeType == 1).Select(x => new { Id = x.EmployeeId, Name = x.EmployeeName });
            ViewBag.Template = unitOfWork.LetterTemplateRepository.Get().Select(x => new { Id = x.TemplateId, Name = x.TemplateName, Content = x.TemplateBody });

            return PartialView("_gvSettlementsPartial", unitOfWork.SettlementRepository.Get());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvSettlementsPartialAddNew(BrgyMgmt.Web.Models.Settlement item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvSettlementsPartial", unitOfWork.SettlementRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvSettlementsPartialUpdate(BrgyMgmt.Web.Models.Settlement item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvSettlementsPartial", unitOfWork.SettlementRepository.Get());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvSettlementsPartialDelete(System.Int32 SettlementId) {
            var model = new object[0];
            if (SettlementId >= 0) {
                try {
                    using (AuditScope.Create("Settlement:Delete", () => SettlementId, new { LastUpdatedBy = User.Identity.Name })) {
                        Settlement settlement = unitOfWork.SettlementRepository.GetByID(SettlementId);
                        unitOfWork.SettlementRepository.Delete(settlement);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvSettlementsPartial", unitOfWork.SettlementRepository.Get());
        }

        public ActionResult SettlementsEditPartial([ModelBinder(typeof(DevExpressEditorsBinder))]int? settlementId) {
            var model = unitOfWork.SettlementRepository.Get().Where(x => x.SettlementId == settlementId).SingleOrDefault();

            return PartialView("_flSettlementsEditPartial", model);
        }
        #endregion


        #region Report Monitor
        public ActionResult Monitor() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            return View();
        }
        #endregion

    }


}