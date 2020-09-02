using DevExpress.CodeParser;
using DevExpress.Office.NumberConverters;
using DevExpress.Web.Mvc;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;

namespace BrgyMgmt.Web.Models {
    public class Reporting {
        //public static Certificate BarangayCertificate
    }
    public class ComplaintReport {
        public int ComplaintId { get; set; }
        public string ComplaintTitle { get; set; }
        public DateTime DateReported { get; set; }
        public string IncidentLocation { get; set; }
        public string IncidentType { get; set; }
        public DateTime DateRecorded { get; set; }
        public string ResidentComplainants { get; set; }
        public string NonResidentComplainants { get; set; }
        public string ResidentRespondents { get; set; }
        public string NonResidentRespondents { get; set; }
        public string ResidentVictims { get; set; }
        public string NonResidentVictims { get; set; }
        public string Narative { get; set; }

    }
    public class SummonReport {
        public int SettlementId { get; set; }
        public int ComplaintId { get; set; }
        public string Title { get; set; }
        public DateTime SettlementDate { get; set; }
        public string Location { get; set; }
        public string PresidingStaff { get; set; }
        public bool? LetterDelivered { get; set; }
        public bool? LetterAcknowledged { get; set; }
        public int? LetterTemplate { get; set; }
        public bool? CaseClosed { get; set; }
        public string LetterContent { get; set; }
        public string Decision { get; set; }
        public string CreatedBy { get; set; }
        public string Complainants { get; set; }
        public string Respondents { get; set; }
        public string Victims { get; set; }

    }
    public class ClearanceReport {
        public int ClearanceId { get; set; }
        public string ResidentName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string CivilStatus { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string CTC { get; set; }
        public DateTime CTCDate { get; set; }
        public string ORNumber { get; set; }
        public string CTCPlaceIssued { get; set; }
        public string Comelec { get; set; }
        public Nullable<int> YearsOfStay { get; set; }
        public List<ClearanceReportPurposes> ClearanceReportPurposes { get; set; }
    }
    public class ClearanceReportPurposes {
        public int ClearanceId { get; set; }
        public string ReportPurpose { get; set; }
        public bool isUsed { get; set; }
        public ClearanceReport ClearanceReport { get; set; }
        public static List<ClearanceReportPurposes> GetReportPurposes() {
            List<ClearanceReportPurposes> list = new List<ClearanceReportPurposes>();
            

            //for (int i = 0; i < purposeTypes.Count(); i++) {
            //    var hasEntry = maintenanceTables.Where(x => x.MaintenanceEntryName == purposeTypes[i].)
            //}
            using (var db = new BrgyMgmtEntities()) {
                var clearances = db.Clearances.Include("MaintenanceTables").ToList();
                var purposeTypes = db.MaintenanceTables.Where(x => x.MaintenanceTableType == "Clearance");
                foreach (var clearance in clearances) {
                    foreach (var purpose in purposeTypes) {

                        list.Add(new ClearanceReportPurposes { ClearanceId = clearance.ClearanceId, isUsed = clearance.MaintenanceTables.Where(x => x.MaintenanceEntryName == purpose.MaintenanceEntryName).Count() > 0, ReportPurpose = purpose.MaintenanceEntryName });
                        //list.Add(new ClearanceReportPurposes { isUsed = clearances.Where(x => x.MaintenanceTables == purpose.MaintenanceEntryName).Count() > 0, ReportPurpose = purpose.MaintenanceEntryName });
                        //var clearanceReportPurpose = new ClearanceReportPurposes { isUsed = maintenanceTables.Where(x => x.MaintenanceEntryName == purpose.MaintenanceEntryName).Count() > 0, ReportPurpose  = purpose.MaintenanceEntryName };
                    }
                }
                
            }
            return list;

        }
    }
    public class DateRangePickerModel {
        [Display(Name = "Start Date")]
        public DateTime Start { get; set; }

        [Display(Name = "End Date")]
        [DateRange(StartDateEditFieldName = "Start", MinDayCount = 1, MaxDayCount = 30)]
        public DateTime End { get; set; }
        public static DateRangePickerModel GetDefaultDates() {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            int days = day - DayOfWeek.Sunday;

            //string resetDate = DateTime.Now.ToShortDateString();
            string resetDate = DateTime.Now.AddDays(-154).ToShortDateString();
            DateTime convertDate = Convert.ToDateTime(resetDate);
            DateTime start = convertDate.AddDays(-days);
            DateTime end = start.AddDays(6);

            return new DateRangePickerModel() { Start = start, End = end };
        }
    }
    


    public class Master {
        public int id { get; set; }
        public string Name { get; set; }
        public List<Child> Child { get; set; }
    }
    public class Child {
        public string ChildName { get; set; }
        public Master Master { get; set; }
    }
}

