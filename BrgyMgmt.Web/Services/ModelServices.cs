using BrgyMgmt.Web.Models;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace BrgyMgmt.Web.Services {
    public class ResidentServices {
        const string LargeDatabaseDataContextKey = "DXLargeDatabaseDataContext";
        public static BrgyMgmtEntities db {
            get {
                if (HttpContext.Current.Items[LargeDatabaseDataContextKey] == null)
                    HttpContext.Current.Items[LargeDatabaseDataContextKey] = new BrgyMgmtEntities();
                return (BrgyMgmtEntities)HttpContext.Current.Items[LargeDatabaseDataContextKey];
            }
        }
        public static object GetResidentRange(ListEditItemsRequestedByFilterConditionEventArgs args) {
            //var db = new DARCEntities();


            //int value1 = (int)(HttpContext.Current.Items["value1"] ?? -1);
            //string except = (string)HttpContext.Current.Items["Except"] ?? Guid.Empty.ToString();
            //string clientId = (string)HttpContext.Current.Items["Except"] ?? Guid.Empty.ToString();
            //Guid except = Guid.Parse(clientId);

            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;

            //var retList = db.Residents.Select(x => new { Id = x.ResidentId, FullName = x.FirstName + " " + x.LastName  }).ToList();

            ////var fuck = (from res in db.Residents where (x => x.FullName.Contains(args.Filter)).OrderBy(x => x.FullName).Select(x => new { Id = x.ResidentId, Name = x.FirstName + " " + x.LastName })
            ////            //
            ////           //.Select(x => new { Id = x.Id, name = x.Name })
            ////           .Skip(skip).Take(take);

            //retList = (from resident in retList
            //           where (resident.FullName).Contains(args.Filter)
            //           orderby resident.FullName
            //           //select new { Id = resident.Id, Name = resident.FullName }
            //           select new {
            //               Id = resident.Id,
            //               Name = resident.FullName
            //           }
            //        ).Skip(skip).Take(take);



            var ret = (from resident in db.Residents
                       where (resident.FirstName + " " + resident.LastName).Contains(args.Filter)
                       orderby resident.LastName
                       select new { Id = resident.ResidentId, Name = resident.FirstName + " " + resident.LastName }
                    ).Skip(skip).Take(take);
            return ret.ToList();
        }
        public static Resident GetResidentByID(ListEditItemRequestedByValueEventArgs args) {
            int id;
            if (args.Value == null || !int.TryParse(args.Value.ToString(), out id))
                return null;
            return db.Residents.Where(p => p.ResidentId == id).Take(1).SingleOrDefault();
        }
        public static object GetResidentByValue(object value) {
            return value != null ? db.Residents.Where(p => p.ResidentId == (long)value).Take(1).ToList() : null;
        }
    }
    public class HouseholdServices {
        const string LargeDatabaseDataContextKey = "DXLargeDatabaseDataContext";
        public static BrgyMgmtEntities db {
            get {
                if (HttpContext.Current.Items[LargeDatabaseDataContextKey] == null)
                    HttpContext.Current.Items[LargeDatabaseDataContextKey] = new BrgyMgmtEntities();
                return (BrgyMgmtEntities)HttpContext.Current.Items[LargeDatabaseDataContextKey];
            }
        }
        public static object GetHouseholdRange(ListEditItemsRequestedByFilterConditionEventArgs args) {
            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;
            var ret = (from household in db.Households
                       where (household.FriendlyName).Contains(args.Filter)
                       orderby household.FriendlyName
                       select new { Id = household.HouseholdId, Name = household.FriendlyName }
                    ).Skip(skip).Take(take);
            return ret.ToList();
        }
        public static Household GetHouseholdtByID(ListEditItemRequestedByValueEventArgs args) {
            int id;
            if (args.Value == null || !int.TryParse(args.Value.ToString(), out id))
                return null;
            return db.Households.Where(p => p.HouseholdId == id).Take(1).SingleOrDefault();
        }

        public static object GetCurrentProperties(int id, string propertyType) {
            var obj = db.HouseholdPropertyProductions.Where(x => x.HouseholdId == id && x.MaintenanceTable.MaintenanceTableType == propertyType).Select( x=> new { Id = x.MaintenanceId, Name = x.MaintenanceTable.MaintenanceEntryName , x.Quantity });
            return obj.ToList();
        }

    }

    public class ComplaintServices {
        const string LargeDatabaseDataContextKey = "DXLargeDatabaseDataContext";
        public static BrgyMgmtEntities db {
            get {
                if (HttpContext.Current.Items[LargeDatabaseDataContextKey] == null)
                    HttpContext.Current.Items[LargeDatabaseDataContextKey] = new BrgyMgmtEntities();
                return (BrgyMgmtEntities)HttpContext.Current.Items[LargeDatabaseDataContextKey];
            }
        }
        public static object GetComplaintRange(ListEditItemsRequestedByFilterConditionEventArgs args) {
            //var db = new DARCEntities();


            //int value1 = (int)(HttpContext.Current.Items["value1"] ?? -1);
            //string except = (string)HttpContext.Current.Items["Except"] ?? Guid.Empty.ToString();
            //string clientId = (string)HttpContext.Current.Items["Except"] ?? Guid.Empty.ToString();
            //Guid except = Guid.Parse(clientId);

            var skip = args.BeginIndex;
            var take = args.EndIndex - args.BeginIndex + 1;

            //var retList = db.Residents.Select(x => new { Id = x.ResidentId, FullName = x.FirstName + " " + x.LastName  }).ToList();

            ////var fuck = (from res in db.Residents where (x => x.FullName.Contains(args.Filter)).OrderBy(x => x.FullName).Select(x => new { Id = x.ResidentId, Name = x.FirstName + " " + x.LastName })
            ////            //
            ////           //.Select(x => new { Id = x.Id, name = x.Name })
            ////           .Skip(skip).Take(take);

            //retList = (from resident in retList
            //           where (resident.FullName).Contains(args.Filter)
            //           orderby resident.FullName
            //           //select new { Id = resident.Id, Name = resident.FullName }
            //           select new {
            //               Id = resident.Id,
            //               Name = resident.FullName
            //           }
            //        ).Skip(skip).Take(take);



            var ret = (from complaint in db.Complaints
                       where (complaint.ComplaintTitle).Contains(args.Filter)
                       orderby complaint.ComplaintId
                       select new { Id = complaint.ComplaintId, Title = complaint.ComplaintTitle }
                    ).Skip(skip).Take(take);
            return ret.ToList();
        }
        public static Complaint GetComplaintByID(ListEditItemRequestedByValueEventArgs args) {
            int id;
            if (args.Value == null || !int.TryParse(args.Value.ToString(), out id))
                return null;
            return db.Complaints.Where(p => p.ComplaintId == id).Take(1).SingleOrDefault();
        }

        //public class DocumentServices {
        //    public static BarangayEntities db = new BarangayEntities();
        //    public static object GetRichEditContent(int docId) {
        //        var settlement = db.Settlements.Where(x => x.SettlementId == docId).FirstOrDefault();
        //        return settlement.Notes;
        //    }
        //    public static byte[] ObjectToByteArray(Object obj) {
        //        BinaryFormatter bf = new BinaryFormatter();
        //        using (var ms = new MemoryStream()) {
        //            bf.Serialize(ms, obj);
        //            return ms.ToArray();
        //        }
        //    }
        //    public static object ByteArrayToObject(byte[] arrBytes) {
        //        using (var memStream = new MemoryStream()) {
        //            var binForm = new BinaryFormatter();
        //            memStream.Write(arrBytes, 0, arrBytes.Length);
        //            memStream.Seek(0, SeekOrigin.Begin);
        //            var obj = binForm.Deserialize(memStream);
        //            return obj;
        //        }
        //    }
        //}
    }
}
