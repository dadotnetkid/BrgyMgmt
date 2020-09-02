using BrgyMgmt.Web.Models;
using DevExpress.XtraPrinting.Native;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BrgyMgmt.Web.Controllers
{
    public class MemberAPIController : ApiController
    {
        ApplicationUserManager userManager;
        public MemberAPIController()
        {
            this.userManager = new ApplicationUserManager(new UserStore(new BrgyMgmtEntities()));
        }
        [HttpPost]
        public async Task<IHttpActionResult> Registration([FromBody] RegisterViewModel item)
        {
            try
            {
                var user = new Models.User()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = item.Email,
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PhoneNumber = item.PhoneNumber
                }; ;
                var res = await userManager.CreateAsync(user, item.Password);
                return Ok(res.Succeeded);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        public async Task<User> FindUser()
        {
            var res = User.Identity.GetUserId();
            return await userManager.FindByIdAsync(res);
        }
    }
}
