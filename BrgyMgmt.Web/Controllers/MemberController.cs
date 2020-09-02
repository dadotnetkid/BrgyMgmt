using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Services;
using DevExpress.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    public class MemberController : Controller {
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

        private UserStore _userStore;
        public UserStore UserStore {
            get => _userStore ?? HttpContext.GetOwinContext().Get<UserStore>();
            private set {
                _userStore = value;
            }
        }



        private UnitOfWork unitOfWork = new UnitOfWork();
        public MemberController() { }
        public MemberController(ApplicationUserManager userManager, ApplicationSignInManager signInManager) {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        #region Users
        public ActionResult Users() {
            if (!BrgyMgmt.Web.Services.Licensing.CheckSession()) {
                return RedirectToAction("license", "security");
            }
            else {
                ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;
                return View();
            }
        }

        //public ActionResult BinaryImageColumnPhotoUpdate() {
        //    return BinaryImageEditExtension.GetCallbackResult(DevExpress.Web.BinaryStorageMode.Session);
        //}
        public ActionResult BinaryImageColumnPhotoUpdate() {
            return BinaryImageEditExtension.GetCallbackResult();
        }

        [ValidateInput(false)]
        public ActionResult gvUserPartial() {
            var allRoles = unitOfWork.RoleRepository.Get().Select(x => new { Id = x.Id, Name = x.Name });
            //ViewData["AllRoles"] = unitOfWork.RoleRepository.Get().Select(x => new { Id = x.Id, Name = x.Name });
            if (User.IsInRole("Administrator")) {
                allRoles = allRoles.Where(x => x.Name != "SA");
            }
            ViewData["AllRoles"] = allRoles;
            //ViewBag.Departments = unitOfWork.DepartmentRepository.Get().Select(x => new { Id = x.DepartmentId, Name = x.DepartmentName });
            //ViewBag.Positions = unitOfWork.PositionRepository.Get().Select(x => new { Id = x.PositionId, Name = x.PositionName });
            //ViewBag.Companies = unitOfWork.CompanyRepository.Get()
            //.Where(x => x.isSupervisor == true)
            //.Select(x => new { Id = x.CompanyId, Name = x.CompanyName });
            //ViewBag.Territories = unitOfWork.ClientTerritoryRepository.Get().Select(x => new { Id = x.ClientTerritoryId, Name = x.TerritoryName });

            var model = unitOfWork.UserRepository.Fetch(includeProperties: "UserRoles").Where(x => x.UserRoles.Any(r => r.Name != "SA"));
            //var roles = model.

            return PartialView("_gvUserPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> gvUserPartialAddNew([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))] User item) {
            var allRoles = unitOfWork.RoleRepository.Get().Select(x => new { Id = x.Id, Name = x.Name });
            if (User.IsInRole("Administrator")) {
                allRoles = allRoles.Where(x => x.Name != "SA");
            }
            ViewData["AllRoles"] = allRoles;
            if (ModelState.IsValid) {
                try {
                    var user = new User {
                        Id = Guid.NewGuid().ToString(),
                        UserName = item.Email,
                        Email = item.Email,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        //MiddleName = item.MiddleName,
                        //Gender = item.Gender,
                        //BirthDate = item.BirthDate,
                        //CivilStatus = item.CivilStatus,
                        //Nationality = item.Nationality,
                        //Religion = item.Religion,
                        PhoneNumber = item.PhoneNumber,
                        //FullAddress = item.FullAddress,
                        //DepartmentId = item.DepartmentId,
                        //PositionId = item.PositionId,
                        Photo = item.Photo,
                        LockoutEndDateUtc = item.LockoutEndDateUtc,
                        AccessFailedCount = item.AccessFailedCount,
                        //Companies = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Companies")),
                        //Territories = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Territories"))
                    };
                    IdentityResult result = await UserManager.CreateAsync(user, TextBoxExtension.GetValue<string>("Password"));

                    var userRolesStringList = await UserManager.GetRolesAsync(user.Id);
                    string[] userRoles = new string[userRolesStringList.Count];
                    int index = 0;
                    foreach (var role in userRolesStringList) {
                        userRoles[index] = role;
                        index += 1;
                    }

                    var selectedRoles = CheckBoxListExtension.GetSelectedValues<string>("UserRolesValues");

                    result = await UserManager.AddToRolesAsync(user.Id, selectedRoles.Except(userRoles).ToArray<string>());
                    result = await UserManager.RemoveFromRolesAsync(user.Id, userRolesStringList.Except(selectedRoles).ToArray<string>());
                    //string accreditedCourseList = string.Empty;

                    //foreach (var accreditedCourse in accreditedCourses) {
                    //    accreditedCourseList += accreditedCourse + ",";
                    //    //await UserStore.AddCourseAccreditation(user.Id, accreditedCourse);
                    //}

                    //result = await UserStore.AddCourseAccreditation(user.Id, accreditedCourses.Except(userRoles).ToArray<string>());

                    //var db = new BarangayEntities();
                    //var usersInCompanies = db.Companies.Where(x => x.Users.Contains);
                    //usersInCompanies.Users.Remove()
                    //var user = UserManager.FindById()

                    //var usersInCompanies = unitOfWork.CompanyRepository.Get(includeProperties: "Comanpies").Where(x => x.Users.Contains())

                    //var currentCompanies = unitOfWork
                    //var companies = TokenBoxExtension.GetSelectedValues<string>("Companies");
                    //foreach (var company in companies) {
                    //    var companyToRe
                    //}

                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvUserPartial", unitOfWork.UserRepository.Fetch(includeProperties: "UserRoles").Where(x => x.UserRoles.Any(r => r.Name != "SA")));
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> gvUserPartialUpdate([ModelBinder(typeof(DevExpress.Web.Mvc.DevExpressEditorsBinder))]User item) {
            ViewData["AllRoles"] = unitOfWork.RoleRepository.Get().Select(x => new { Id = x.Id, Name = x.Name });
            //ViewBag.Companies = unitOfWork.CompanyRepository.Get().Select(x => new { Id = x.CompanyId, Name = x.CompanyName });

            if (ModelState.IsValid) {
                try {
                    var user =
                    UserManager.FindById(item.Id);

                    user.Email = item.Email;
                    user.UserName = item.Email;
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    //user.MiddleName = item.MiddleName;
                    //user.Gender = item.Gender;
                    //user.BirthDate = item.BirthDate;
                    //user.CivilStatus = item.CivilStatus;
                    //user.Nationality = item.Nationality;
                    //user.Religion = item.Religion;
                    user.PhoneNumber = item.PhoneNumber;
                    //user.FullAddress = item.FullAddress;
                    //user.DepartmentId = item.DepartmentId;
                    //user.PositionId = item.PositionId;
                    //user.isSupervisor = item.isSupervisor;
                    //user.Photo = item.Photo;
                    user.Photo = BinaryImageEditExtension.GetValue<byte[]>("Photo");

                    user.LockoutEndDateUtc = item.LockoutEndDateUtc;
                    user.AccessFailedCount = item.AccessFailedCount;


                    //user.Supervisors = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Supervisors"));
                    //user.Territories = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("Territories"));

                    IdentityResult result = await UserManager.UpdateAsync(user);

                    var newPass = TextBoxExtension.GetValue<string>("NewPassword");
                    if (!string.IsNullOrEmpty(newPass)) {
                        user.PasswordHash = UserManager.PasswordHasher.HashPassword(newPass);
                        //var result = await UserManager.UpdateAsync(user);
                    }


                    var userRolesStringList = await UserManager.GetRolesAsync(item.Id);
                    string[] userRoles = new string[userRolesStringList.Count];
                    int index = 0;
                    foreach (var role in userRolesStringList) {
                        //userRoles[index] = (RoleManager.Roles.Where(x => x.Name == role).Select(y => y.Id).FirstOrDefault());
                        userRoles[index] = role;
                        index += 1;
                    }

                    var selectedRoles = CheckBoxListExtension.GetSelectedValues<string>("UserRolesValues");

                    result = await UserManager.AddToRolesAsync(item.Id, selectedRoles.Except(userRoles).ToArray<string>());
                    result = await UserManager.RemoveFromRolesAsync(item.Id, userRolesStringList.Except(selectedRoles).ToArray<string>());



                    //var accreditedCourses = CheckBoxListExtension.GetSelectedValues<string>("cblAccredited");
                    //var accreditedCoursesAlt = string.Join(",", TokenBoxExtension.GetSelectedValues<string>("AccreditedCourses"));
                    //foreach (var accreditedCourse in accreditedCourses) {
                    //    var course = unitOfWork.CourseRepository.GetByID(Convert.ToInt32(accreditedCourse));
                    //    user.Courses.Add(course);
                        

                    //    ////course.Users.Add(user);
                    //    //UserStore.AddCourseAccreditation(user.Id, accreditedCourse);
                    //}

                    
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_gvUserPartial", unitOfWork.UserRepository.Fetch(includeProperties: "UserRoles").Where(x => x.UserRoles.Any(r => r.Name != "SA")));
        }
        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> gvUserPartialDelete(System.String Id) {
            if (Id != null) {
                try {
                    var user = await UserManager.FindByIdAsync(Id);
                    var result = await UserManager.DeleteAsync(user);
                }
                catch (Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_gvUserPartial", unitOfWork.UserRepository.Fetch(includeProperties: "UserRoles").Where(x => x.UserRoles.Any(r => r.Name != "SA")));
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangeUserPassword(ChangeUserPasswordViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);

            if (user == null) {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            user.PasswordHash = UserManager.PasswordHasher.HashPassword(model.Password);
            var result = await UserManager.UpdateAsync(user);




            //var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded) {
                //return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }
        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }

        #endregion



        #region Helpers
        public ActionResult LoginStatus() {
            return PartialView("_LoginStatus", GetLoginStatus());
        }

        private object GetLoginStatus() {
            //return unitOfWork.UserRepository.Get().Where(u => u.Id == User.Identity.GetUserId()).Select(x => new User { Photo = x.Photo ?? MissingImage() }).FirstOrDefault();

            //var rolesList = UserManager.GetRolesAsync(User.Identity.GetUserId()).ConfigureAwait(false);
            var rolesList = UserManager.GetRoles(User.Identity.GetUserId());
            string joined = string.Join(Environment.NewLine, UserManager.GetRoles(User.Identity.GetUserId()));

            return (from u in UserManager.Users.ToList()
                    where u.Id == User.Identity.GetUserId()
                    select new LoginStatusModel {
                        Name = u.FullName,
                        //Position = UserManager.GetRolesAsync(User.Identity.GetUserId()).ToString(),
                        Position = string.Join(" | ", UserManager.GetRoles(User.Identity.GetUserId())).ToUpper(),
                        //HireDate = u.HireDate,
                        Photo = u.Photo ?? MissingImage()
                    }).FirstOrDefault();
        }

        private byte[] MissingImage() {
            var webClient = new WebClient();

            //byte[] imageBytes = webClient.DownloadData(Request.Url + "/content/img/user.jpg");
            byte[] imageBytes = webClient.DownloadData((System.Web.HttpContext.Current.Request).Url.GetLeftPart(System.UriPartial.Authority) + System.Web.VirtualPathUtility.ToAbsolute("~/") + "/content/img/user.png");



            //HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + ResolveUrl("~/")

            return imageBytes;
        }

        #endregion
    }
}