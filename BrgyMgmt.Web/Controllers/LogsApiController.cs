using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web.Http;

namespace BrgyMgmt.Web.Controllers
{
    public class LogsApiController : ApiController
    {
        private ApplicationUserManager userManager;
        private UnitOfWork unitOfWork;

        public LogsApiController()
        {
            this.userManager = new ApplicationUserManager(new UserStore(new BrgyMgmtEntities()));
            this.unitOfWork = new UnitOfWork();
        }
        public async Task<IHttpActionResult> Post([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            unitOfWork.EstablishmentLogRepository.Insert(new EstablishmentLog()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                LogDateTime = DateTime.Now,
                 
            });
            return Ok();
        }
        //public async Task<List<Barangay>> GetBarangays()
        //{
        //    return unitOfWork.b
        //}
    }
}
