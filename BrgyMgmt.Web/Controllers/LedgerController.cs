using BrgyMgmt.Web.Models;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BrgyMgmt.Web.Controllers {
    [Authorize]
    [RoutePrefix("ledger")]
    public class LedgerController : Controller {
        public ActionResult Tax() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            return View();
        }

        #region Services Collections
        rptServices servicesReport = new rptServices();
        public ActionResult Receipts() {
            ViewBag.LocalPath = (System.Web.HttpContext.Current.Request).Url.LocalPath;

            //DateRangePickerModel dtp = DateRangePickerModel.GetDefaultDates();
            //ViewBag.Start = dtp.Start;
            //ViewBag.End = dtp.End;

            return View();
        }
        
        public ActionResult ReceiptReportPartial() {
            DateRangePickerModel dtp = DateRangePickerModel.GetDefaultDates();

            var start = string.IsNullOrEmpty(Request.Params["From"]) ? dtp.Start : new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Int64.Parse(Request.Params["From"])).ToLocalTime();
            var end = string.IsNullOrEmpty(Request.Params["To"]) ? dtp.End : new DateTime(2018, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Int64.Parse(Request.Params["To"])).ToLocalTime();
            //var encoded = "Clinton Lazaro";

            return PartialView("_rvReceiptsReportPartial", GetReceiptReport(start, end));
        }
        protected rptServices GetReceiptReport(DateTime start, DateTime end) {

            servicesReport.Parameters["From"].Value = start;
            servicesReport.Parameters["To"].Value = end;
            //servicesReport.Parameters["EntryBy"].Value = encodedBy;

            servicesReport.CreateDocument();
            return servicesReport;
        }
        #endregion
    }
}