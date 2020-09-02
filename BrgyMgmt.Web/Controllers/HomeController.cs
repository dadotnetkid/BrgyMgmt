using DevExpress.Web.Mvc;
using Audit.Core;
using Audit.SqlServer;
using Audit.SqlServer.Providers;
using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Services;
using DevExpress.CodeParser;
using DevExpress.Web.Internal;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BrgyMgmt.Web.Controllers {
    //[Authorize]
    public class HomeController : Controller {
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
        public HomeController() { }
        public HomeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
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
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            var residents = unitOfWork.ResidentRepository.Get(includeProperties: "Household");
            ViewBag.ResidentCount = residents.Count();
            ViewBag.RegisteredVoters = residents.Where(x => x.isVoter == true).Count();
            ViewBag.PendingCases = unitOfWork.ComplaintRepo.Get().Where(x => x.ComplaintStatus == 323).Count();
            ViewBag.Households = unitOfWork.HouseholdRepository.Get().Count();
            return View();
            //return View();
        }



        #region ABOUT


        public ActionResult About() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }


        [ValidateInput(false)]
        public ActionResult GridViewPartial() {
            var model = unitOfWork.ResidentRepository.Get();
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(BrgyMgmt.Web.Models.Resident item) {
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
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(BrgyMgmt.Web.Models.Resident item) {
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
            return PartialView("_GridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 ResidentId) {
            var model = new object[0];
            if (ResidentId >= 0) {
                try {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model);
        }





        #endregion







        #region Error 404
        public ActionResult NotFound() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion



        #region Dasboard Widgets
        [ValidateInput(false)]
        public ActionResult gvSettlementsPartial() {
            var model = unitOfWork.SettlementRepository.Get(includeProperties: "Complaint").Where(x => x.SettlementDate.Date >= DateTime.Today);
            return PartialView("_gvSettlementsPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult gvTaxPartial() {
            var model = unitOfWork.CertificateCommunityRepo.Get().Where(x => x.DateIssued.Date >= DateTime.Today);
            return PartialView("_gvTaxPartial", model);
        }

        [ValidateInput(false)]
        public ActionResult gvClearancesPartial() {
            var model = unitOfWork.ClearanceRepo.Get().Where(x => x.IssuedDate.Date >= DateTime.Today);
            return PartialView("_gvClearancesPartial", model);
        }
        #endregion


    }
}