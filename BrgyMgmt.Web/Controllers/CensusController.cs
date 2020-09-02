using DevExpress.Web.Mvc;
using BrgyMgmt.Web.Services;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using BrgyMgmt.Web.Models;
using Microsoft.AspNet.Identity;
using Audit.Core;
using Audit.SqlServer.Providers;
using Audit.SqlServer;
using Newtonsoft.Json;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    [RoutePrefix("census")]
    public class CensusController : Controller {
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
        public CensusController() { }
        public CensusController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
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



        #region Residents
        public ActionResult Residents() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }            
        }

        [ValidateInput(false)]
        public ActionResult gvResidentsPartial() {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.Religions = maintenance.Where(z => z.MaintenanceTableType == "Religion").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Relationship = maintenance.Where(z => z.MaintenanceTableType == "Relationship").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Ethnicities = maintenance.Where(z => z.MaintenanceTableType == "Ethnicity").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.EducationStatus = maintenance.Where(z => z.MaintenanceTableType == "EducationStatus").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.HomeConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacilities = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Electricity = maintenance.Where(z => z.MaintenanceTableType == "Electricity").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Households = unitOfWork.HouseholdRepository.Get().Select(x => new { Id = x.HouseholdId, Name = x.FriendlyName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.EducAttainment = maintenance.Where(z => z.MaintenanceTableType == "EducAttainment").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });


            var model = unitOfWork.ResidentRepository.Fetch(includeProperties:"Household");

            return PartialView("_gvResidentsPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentsPartialAddNew(BrgyMgmt.Web.Models.Resident item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.Religions = maintenance.Where(z => z.MaintenanceTableType == "Religion").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            if (ModelState.ContainsKey("HouseHoldId"))
                ModelState["HouseHoldId"].Errors.Clear();

            if (ModelState.IsValid) {
                try {

                    using (AuditScope.Create("Resident:Create", () => item)) {
                        if (item.HouseHoldId == 0) {
                            var hhName = ComboBoxExtension.GetValue<string>("HouseHoldName");
                            Household newHousehold = new Household() { FriendlyName = hhName };
                            unitOfWork.HouseholdRepository.Insert(newHousehold);
                            item.HouseHoldId = newHousehold.HouseholdId;
                        }
                        item.Photo = item.Photo ?? new byte[0];
                        item.BiometricCapture = item.BiometricCapture ?? new byte[0];

                        unitOfWork.ResidentRepository.Insert(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvResidentsPartial", unitOfWork.ResidentRepository.Fetch());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentsPartialUpdate(BrgyMgmt.Web.Models.Resident item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.Religions = maintenance.Where(z => z.MaintenanceTableType == "Religion").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            if (ModelState.IsValid) {
                try {
                    using (AuditScope.Create("Resident:Update", () => item, new { LastUpdatedBy = User.Identity.Name })) {
                        item.Photo = BinaryImageEditExtension.GetValue<byte[]>("Photo");
                        item.BiometricCapture = item.BiometricCapture ?? new byte[0];
                        if (item.HouseholdHead == true) {
                            using (var db = new BrgyMgmtEntities()) {
                                Resident oldHouseholdHead = db.Residents.Where(x => x.HouseholdHead == true && x.HouseHoldId == item.HouseHoldId && x.ResidentId != item.ResidentId).FirstOrDefault();
                                if (oldHouseholdHead != null) {
                                    oldHouseholdHead.HouseholdHead = false;
                                }
                                db.SaveChanges();
                            }
                        }
                        unitOfWork.ResidentRepository.Update(item);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvResidentsPartial", unitOfWork.ResidentRepository.Fetch());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentsPartialDelete(System.Int32 ResidentId) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.Religions = maintenance.Where(z => z.MaintenanceTableType == "Religion").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            if (ResidentId >= 0) {
                try {
                    Resident resident = unitOfWork.ResidentRepository.GetByID(ResidentId);
                    unitOfWork.ResidentRepository.Delete(resident);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvResidentsPartial", unitOfWork.ResidentRepository.Fetch());
        }
        #endregion
        #region HouseHolds
        public ActionResult HouseHolds() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }
        }
        [ValidateInput(false)]
        public ActionResult gvHouseholdsPartial() {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.ConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacility = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.LandTenure = maintenance.Where(z => z.MaintenanceTableType == "LandTenure").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.Electricity = maintenance.Where(z => z.MaintenanceTableType == "Electricity").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.SanitationPractice = maintenance.Where(z => z.MaintenanceTableType == "SanitationPractice").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Garden = maintenance.Where(z => z.MaintenanceTableType == "Garden").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.FamilyPlanning = maintenance.Where(z => z.MaintenanceTableType == "FamilyPlanning").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.BreastFeed = maintenance.Where(z => z.MaintenanceTableType == "BreastFeed").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.OtherNutrition = maintenance.Where(z => z.MaintenanceTableType == "OtherNutrition").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            //IEnumerable<MaintenanceTable> allPropertyProductions = unitOfWork.MaintenanceTableRepository.Get();
            var allLivestock = maintenance.Where(x => x.MaintenanceTableType == "Livestock").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            
            IEnumerable<HouseholdPropertyProduction> currentLivestock = unitOfWork.HouseholdPropertyProductionRepository.Get().Where(x => x.MaintenanceTable.MaintenanceTableType == "Livestock");
            ViewBag.CurrentLivestock = currentLivestock.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName, x.Quantity });


            var currentLivestockProduction = currentLivestock.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName });
            ViewBag.AvailableLivestock = allLivestock.Except(currentLivestockProduction);



            var allEquipments = maintenance.Where(x => x.MaintenanceTableType == "Equipment").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            IEnumerable<HouseholdPropertyProduction> currentEquipments = unitOfWork.HouseholdPropertyProductionRepository.Get().Where(x => x.MaintenanceTable.MaintenanceTableType == "Equipment");
            ViewBag.CurrentEquipments = currentEquipments.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName, x.Quantity });

            var currentEquipmentProperties = currentEquipments.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName });
            ViewBag.AvaialableEquipments = allEquipments.Except(currentEquipmentProperties);

            var allChildrenRanges = maintenance.Where(x => x.MaintenanceTableType == "Children").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            IEnumerable<HouseholdPropertyProduction> currentChildrenRanges = unitOfWork.HouseholdPropertyProductionRepository.Get().Where(x => x.MaintenanceTable.MaintenanceTableType == "Children");
            ViewBag.CurrentChildrenRanges = currentChildrenRanges.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName, x.Quantity });

            var currentChildren = currentChildrenRanges.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName });
            ViewBag.AvaialableChildrenRangess = allChildrenRanges.Except(currentChildren);


            //ViewBag.Households = unitOfWork.HouseholdRepository.Get().Select(x => new { Id = x.HouseholdId, Name = x.FriendlyName });




            return PartialView("_gvHouseholdsPartial", unitOfWork.HouseholdRepository.Get(includeProperties: "HouseholdPropertyProductions"));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdsPartialAddNew(BrgyMgmt.Web.Models.Household item) {
            //ViewBag.Sanitation = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "SanitationPractice").OrderBy(x => x.SortOrder).Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            //ViewBag.Livestock = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Livestock").OrderBy(x => x.SortOrder).Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.ConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacility = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            if (ModelState.IsValid) {
                try {
                    var hhProp = TextBoxExtension.GetValue<string>("hide");
                    var serialized = JsonConvert.DeserializeObject<List<HouseHoldPropertiesModel>>(hhProp);


                    using (AuditScope.Create("Household:Insert", () => item, new { CreatedBy = User.Identity.Name })) {
                        //var lbItems = ListBoxExtension.GetSelectedValues<string>("lbCurrentVehicles");


                        //var hh = db.Households.Find(item.HouseholdId);
                        //var hhh = hh.HouseholdPropertyProductions.ToList();
                        //foreach (var propertyItem in hhh) {
                        //    db.HouseholdPropertyProductions.Remove(propertyItem);
                        //}

                        foreach (var serializedProperty in serialized) {
                            var hhPropertyProduction = new HouseholdPropertyProduction { HouseholdId = item.HouseholdId, MaintenanceId = serializedProperty.MaintenanceEntryId, Quantity = serializedProperty.Quantity };
                            //db.HouseholdPropertyProductions.Add(hhPropertyProduction);
                            item.HouseholdPropertyProductions.Add(hhPropertyProduction);
                        }
                        //hh.ProgramName = item.ProgramName;

                        unitOfWork.HouseholdRepository.Insert(item);
                        unitOfWork.Save();

                        //this.UpdateModel(hh);
                        //db.SaveChanges();
                        }
                    }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvHouseholdsPartial", unitOfWork.HouseholdRepository.Get(includeProperties: "HouseholdPropertyProductions"));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdsPartialUpdate(BrgyMgmt.Web.Models.Household item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.ConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacility = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            var model = db.Households;
            if (ModelState.IsValid) {
                try {
                    //var houseHold = Request.Params["houseHoldProperties"];
                    //var houseHoldProperties = JsonConvert.DeserializeObject<List<HouseHoldPropertiesModel>>(houseHold);

                    var hhProp = TextBoxExtension.GetValue<string>("hide");
                    var serialized = JsonConvert.DeserializeObject<List<HouseHoldPropertiesModel>>(hhProp);


                    using (AuditScope.Create("Resident:Update", () => item, new { LastUpdatedBy = User.Identity.Name })) {
                        //var lbItems = ListBoxExtension.GetSelectedValues<string>("lbCurrentVehicles");


                        var hh = db.Households.Find(item.HouseholdId);
                        var hhh = hh.HouseholdPropertyProductions.ToList();
                        foreach (var propertyItem in hhh) {
                            db.HouseholdPropertyProductions.Remove(propertyItem);
                        }

                        foreach (var serializedProperty in serialized) {
                            var hhPropertyProduction = new HouseholdPropertyProduction { HouseholdId = item.HouseholdId, MaintenanceId = serializedProperty.MaintenanceEntryId, Quantity = serializedProperty.Quantity };
                            db.HouseholdPropertyProductions.Add(hhPropertyProduction);
                        }
                        hh.ProgramName = item.ProgramName;


                        this.UpdateModel(hh);
                        db.SaveChanges();


                        //var itemInstance = unitOfWork.HouseholdRepository.GetByID(item.HouseholdId);
                        //var itemInstanceProperties = itemInstance.HouseholdPropertyProductions.ToList();
                        //foreach (var propertyItem in itemInstanceProperties) {
                        //    unitOfWork.HouseholdPropertyProductionRepository.Delete(propertyItem);
                        //}
                        //unitOfWork.HouseholdRepository.Update(item);
                        //unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvHouseholdsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdsPartialDelete(System.Int32 HouseholdId) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.ConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacility = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Sitio = maintenance.Where(z => z.MaintenanceTableType == "Sitio").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            if (HouseholdId > 0) {
                try {
                    using (AuditScope.Create("Household:Delete", () => HouseholdId, new { LastUpdatedBy = User.Identity.Name })) {
                        Household household = unitOfWork.HouseholdRepository.GetByID(HouseholdId);
                        unitOfWork.HouseholdRepository.Delete(household);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvHouseholdsPartial", unitOfWork.HouseholdRepository.Get(includeProperties: "HouseholdPropertyProductions"));
        }



        #endregion


        #region Resident Detail

        [ValidateInput(false)]
        public ActionResult gvResidentDetailPartial(int householdId) {
            ViewData["HouseholdId"] = householdId;
            ViewBag.Relationships = unitOfWork.MaintenanceTableRepository.Get().Where(z => z.MaintenanceTableType == "Relationship").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            return PartialView("_gvResidentDetailPartial", unitOfWork.ResidentRepository.Get().Where(x => x.HouseHoldId == householdId));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentDetailPartialAddNew(BrgyMgmt.Web.Models.Resident item) {
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
            return PartialView("_gvResidentDetailPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentDetailPartialUpdate(BrgyMgmt.Web.Models.Resident item) {
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
            return PartialView("_gvResidentDetailPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvResidentDetailPartialDelete(System.Int32 ResidentId) {
            var model = new object[0];
            if (ResidentId >= 0) {
                try {
                    using (AuditScope.Create("Resident:Delete", () => ResidentId, new { LastUpdatedBy = User.Identity.Name })) {
                        Resident resident = unitOfWork.ResidentRepository.GetByID(ResidentId);
                        unitOfWork.ResidentRepository.Delete(resident);
                        unitOfWork.Save();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvResidentDetailPartial", model);
        }

        #endregion


        #region Helpers
        public ActionResult BinaryImageColumnPhotoUpdate() {
            return BinaryImageEditExtension.GetCallbackResult();
        }
        public ActionResult cmbHousehold() {
            return PartialView("_cmbHousehold");
        }
        public ActionResult ppcHousehold() {
            return PartialView("_ppcHousehold");
        }
        public ActionResult frmHousehold([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))] Household item) {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();
            ViewBag.Religions = maintenance.Where(z => z.MaintenanceTableType == "Religion").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Relationship = maintenance.Where(z => z.MaintenanceTableType == "Relationship").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Ethnicities = maintenance.Where(z => z.MaintenanceTableType == "Ethnicity").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.EducationStatus = maintenance.Where(z => z.MaintenanceTableType == "EducationStatus").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.HomeConstructionTypes = maintenance.Where(z => z.MaintenanceTableType == "ConstructionType").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });

            ViewBag.MonthlyIncome = maintenance.Where(z => z.MaintenanceTableType == "MonthlyIncome").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.WaterSupply = maintenance.Where(z => z.MaintenanceTableType == "WaterSupply").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.ToiletFacilities = maintenance.Where(z => z.MaintenanceTableType == "ToiletFacility").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Electricity = maintenance.Where(z => z.MaintenanceTableType == "Electricity").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            ViewBag.Households = unitOfWork.HouseholdRepository.Get().Select(x => new { Id = x.HouseholdId, Name = x.FriendlyName });

            if (item.FriendlyName != null) {
                try {
                    unitOfWork.HouseholdRepository.Insert(item);
                    unitOfWork.Save();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_frmHousehold", item);
        }
        #endregion

        BrgyMgmt.Web.Models.BrgyMgmtEntities db = new BrgyMgmt.Web.Models.BrgyMgmtEntities();

        [ValidateInput(false)]
        public ActionResult gvHouseholdProductionsPartial() {

            var model = db.HouseholdPropertyProductions;
            return PartialView("_gvHouseholdProductionsPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdProductionsPartialAddNew(BrgyMgmt.Web.Models.HouseholdPropertyProduction item) {

            var model = db.HouseholdPropertyProductions;

            if (ModelState.IsValid) {
                try {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvHouseholdProductionsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdProductionsPartialUpdate(BrgyMgmt.Web.Models.HouseholdPropertyProduction item) {
            var model = db.HouseholdPropertyProductions;
            if (ModelState.IsValid) {
                try {
                    var modelItem = model.FirstOrDefault(it => it.HouseholdProductionId == item.HouseholdProductionId);
                    if (modelItem != null) {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvHouseholdProductionsPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult gvHouseholdProductionsPartialDelete(System.Int32 HouseholdProductionId) {
            var model = db.HouseholdPropertyProductions;
            if (HouseholdProductionId >= 0) {
                try {
                    var item = model.FirstOrDefault(it => it.HouseholdProductionId == HouseholdProductionId);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvHouseholdProductionsPartial", model.ToList());
        }

        public ActionResult cmbVehiclesPartial() {
            IEnumerable<MaintenanceTable> maintenance = unitOfWork.MaintenanceTableRepository.Get();

            var allVehicles = maintenance.Where(x => x.MaintenanceTableType == "Vehicle").Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceEntryName });
            IEnumerable<HouseholdPropertyProduction> currentVehicles = unitOfWork.HouseholdPropertyProductionRepository.Get().Where(x => x.MaintenanceTable.MaintenanceTableType == "Vehicle" && x.HouseholdId == 1);
            ViewBag.CurrentVehicles = currentVehicles.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName, x.Quantity });

            var currentVehicleProperties = currentVehicles.Select(x => new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName });
            ViewBag.AvailableVehicles = allVehicles.Except(currentVehicleProperties);

            return PartialView("_cmbVehiclesPartial");
        }
    }
}