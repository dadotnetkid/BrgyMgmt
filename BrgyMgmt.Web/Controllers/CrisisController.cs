using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Services;
using DevExpress.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.SqlServer;


namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    [RoutePrefix("crisis-management")]
    public class CrisisController : Controller {
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
        public CrisisController() { }
        public CrisisController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
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


        [Route("alerts")]
        public ActionResult Index() {
            //ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            //return View();
            return RedirectToAction("disasters", "crisis");
        }
        #region Disasters
        [Route("disasters")]
        public ActionResult Disasters() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvDisastersPartial() {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.DisasterTypes = maintenance.Where(z => z.MaintenanceTableType == "DisasterType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            var model = new object[0];
            return PartialView("_gvDisastersPartial", unitOfWork.DisasterRepo.Get());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvDisastersPartialAddNew(BrgyMgmt.Web.Models.Disaster item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvDisastersPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvDisastersPartialUpdate(BrgyMgmt.Web.Models.Disaster item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvDisastersPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvDisastersPartialDelete(System.Int32 DisasterId) {
            var model = new object[0];
            if (DisasterId >= 0) {
                try {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvDisastersPartial", model);
        }

        #endregion
        #region Relocation Sites
        [Route("relocation-sites")]
        public ActionResult RelocationSites() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }

        [ValidateInput(false)]
        public ActionResult gvRelocationSitesPartial() {
            var model = new object[0];
            return PartialView("_gvRelocationSitesPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelocationSitesPartialAddNew(BrgyMgmt.Web.Models.DisasterRelocationSite item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvRelocationSitesPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelocationSitesPartialUpdate(BrgyMgmt.Web.Models.DisasterRelocationSite item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvRelocationSitesPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvRelocationSitesPartialDelete(System.Int32 DisasterRelocationSiteId) {
            var model = new object[0];
            if (DisasterRelocationSiteId >= 0) {
                try {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvRelocationSitesPartial", model);
        }

        #endregion
        #region Rescue Teams
        [Route("rescue-teams")]
        public ActionResult RescueTeams() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }
        #endregion

        #region ResidentRelocation
        [ValidateInput(false)]
        public ActionResult gvResidentRelocationsPartial() {
            var model = new object[0];
            return PartialView("_gvResidentRelocationsPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentRelocationsPartialAddNew(BrgyMgmt.Web.Models.Resident item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvResidentRelocationsPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentRelocationsPartialUpdate(BrgyMgmt.Web.Models.Resident item) {
            var model = new object[0];
            if (ModelState.IsValid) {
                try {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            } else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvResidentRelocationsPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentRelocationsPartialDelete(System.Int32 ResidentId) {
            var model = new object[0];
            if (ResidentId >= 0) {
                try {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvResidentRelocationsPartial", model);
        }
        #endregion

        #region Contact Tracing
        [Route("contact-tracing")]
        public ActionResult ContactTracing() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }
        #endregion
    }
}