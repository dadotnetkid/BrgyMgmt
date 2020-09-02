using BrgyMgmt.Web.Models;
using BrgyMgmt.Web.Properties;
using DeviceId;
using LogicNP.CryptoLicensing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Services {
    public class Constants {
        public const string LocalConnectionString = "Data Source=localhost;Initial Catalog=btms-runruno;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
    }
    public class Licensing {
        public static bool CheckSession() {
            var DeviceId = new DeviceIdBuilder()
                .AddMachineName()
                .AddMacAddress()
                .AddProcessorId()
                .AddMotherboardSerialNumber()
                .ToString();
            string licenseCode;
            using (var db = new BrgyMgmtEntities()) {
                licenseCode = db.ApplicationSettings.Find(1).ApplicationSettingsValue;

            }
            CryptoLicense license = new CryptoLicense(licenseCode, Resources.SessionString);
            //return license.GetUserDataFieldValue("MachineCode", "#") == DeviceId;
            return true;
        }

    }
}