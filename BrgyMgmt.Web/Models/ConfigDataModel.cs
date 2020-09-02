using DevExpress.XtraGauges.Core.Model;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace BrgyMgmt.Web.Models {
    public class ConfigDataModel {
    }
    public class BarangayProfileData {
        public string BarangayName { get; set; }
        public string Municipality { get; set; }
        public string Province { get; set; }
        public string ZIP { get; set; }
        public string Slogan1 { get; set; }
        public string Slogan2 { get; set; }
        public string History { get; set; }
        public string Demographics { get; set; }

        public static BarangayProfileData Get() {
            BarangayProfileData profile = new BarangayProfileData();

            using (var db = new BrgyMgmtEntities()) {
                profile.BarangayName = (db.ConfigData.Where(x => x.ConfigName == "BarangayName").SingleOrDefault()).ConfigValue;
                profile.Municipality = (db.ConfigData.Where(x => x.ConfigName == "Municipality").SingleOrDefault()).ConfigValue;
                profile.Province = (db.ConfigData.Where(x => x.ConfigName == "Province").SingleOrDefault()).ConfigValue;
                profile.ZIP = (db.ConfigData.Where(x => x.ConfigName == "ZIP").SingleOrDefault()).ConfigValue;
                profile.Slogan1 = (db.ConfigData.Where(x => x.ConfigName == "Slogan1").SingleOrDefault()).ConfigValue;
                profile.Slogan2 = (db.ConfigData.Where(x => x.ConfigName == "Slogan2").SingleOrDefault()).ConfigValue;
                profile.History = (db.ConfigData.Where(x => x.ConfigName == "History").SingleOrDefault()).ConfigValue;
                profile.Demographics = (db.ConfigData.Where(x => x.ConfigName == "Demographics").SingleOrDefault()).ConfigValue;
                //profile.Logo = (db.ConfigData.Where(x => x.ConfigName == "Logo").SingleOrDefault()).ConfigValue;
                //var properties = TypeDescriptor.GetProperties(typeof(Models.BarangayProfile));
                //foreach (PropertyDescriptor property in properties) {
                //    var val = db.UnitDetails.Where(x => x.UnitName == property.Name);
            }

            return profile;
        }

        public static void Update(BarangayProfileData data) {
            using (var db = new BrgyMgmtEntities()) {
                foreach (PropertyInfo prop in data.GetType().GetProperties()) {
                    ConfigData item = db.ConfigData.Where(x => x.ConfigName == prop.Name).SingleOrDefault();
                    item.ConfigValue = prop.GetValue(data, null).ToString() ?? item.ConfigValue;
                }
                db.SaveChanges();
            }

        }

    }
}