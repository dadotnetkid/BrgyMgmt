using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Models {
    public partial class Resident {
        //public string FullName {
        //    get {
        //        string dspFirstName = string.IsNullOrWhiteSpace(this.FirstName) ? "" : this.FirstName;
        //        string dspLastName = string.IsNullOrWhiteSpace(this.LastName) ? "" : this.LastName;

        //        return string.Format("{0} {1}", dspFirstName, dspLastName);
        //    }
        //}
        //public static object GetResidentsInBlotters(int blotterId, int identityTYpe) {
        //    if (blotterId == 0) return new List<string>();
        //    using (var db = new BarangayEntities()) {
        //        switch (identityTYpe) {
        //            case 1:
        //                return db.Blotters.Find(blotterId).ResidentComplainants.Select(x => new { Id = x.ResidentId, Name = x.FullName }).ToList();
        //            case 2:
        //                return db.Blotters.Find(blotterId).ResidentRespondents.Select(x => new { Id = x.ResidentId, Name = x.FullName }).ToList();
        //            case 3:
        //                return db.Blotters.Find(blotterId).ResidentVictims.Select(x => new { Id = x.ResidentId, Name = x.FullName }).ToList();
        //            default:
        //                return db.Blotters.Find(blotterId).ResidentComplainants.Select(x => new { Id = x.ResidentId, Name = x.FullName }).ToList();
        //        }
        //    }


        //}
        public static string GetAge(DateTime Dob) {
            DateTime Now = DateTime.Now;
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++) {
                if (PastYearDate.AddMonths(i) == Now) {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now) {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            //return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            //Years, Months, Days, Hours, Seconds);
            return String.Format("{0}y {1}m", Years, Months);
        }

    }
    //public partial class Civilian{
    //    public string FullName {
    //        get {
    //            string dspFirstName = string.IsNullOrWhiteSpace(this.FirstName) ? "" : this.FirstName;
    //            string dspLastName = string.IsNullOrWhiteSpace(this.LastName) ? "" : this.LastName;

    //            return string.Format("{0} {1}", dspFirstName, dspLastName);
    //        }
    //    }
    //    public static IList GetResidents() {
    //        //if (clientId == Guid.Empty) return new List<Object>();
    //        using (var db = new BarangayEntities()) {
    //            return (from c in db.Civilians select new { Id = c.ResidentId, Name = c.FirstName + " " + c.LastName }).ToList();
    //        }
    //    }

    //}
}