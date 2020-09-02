using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Models {
    public class HouseHoldPropertiesViewModel {
        public string MaintenanceTableType { get; set; }
        public int MaintenanceEntryId { get; set; }
        public int Quantity { get; set; }
    }
    public class HouseHoldPropertiesModel {
        public int MaintenanceEntryId { get; set; }
        public int Quantity { get; set; }
    }

}