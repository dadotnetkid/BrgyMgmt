using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BrgyMgmt.Web.Services {
    public enum Gender {
        Male, Female, LGBT
    }
    public enum CivilStatus {
        Single, Married, Widowed, Separated, Divorced
    }
    public enum Title {
        Mr, Ms, Mrs, Dr, Prof, Engr, Atty
    }
    public enum EmployeeType {
        Official = 1, Staff = 2
    }
    public enum IncidentType {
        [Description("Peace and Order")] PeaceOrder = 1,
        [Description("Domestic Violence")] DomesticViolence = 2, Theft = 3
    }
    public enum Sitio {
        Kinalabasa, Marangad, Atan, Lintungan, Tayab
    }
    public enum PregnantMonths {
        [Description("None")] None = 1,
        [Description("1 Month")] OneMonth = 1,
        [Description("2 Months")] TwoMonths = 2,
        [Description("3 Months")] ThreeMonths = 3,
        [Description("4 Months")] FourMonths = 4,
        [Description("5 Months")] FiveMonths = 5,
        [Description("6 Months")] SixMonths = 6,
        [Description("7 Months")] SevenMonths = 7,
        [Description("8 Months")] EightMonths = 8,
        [Description("9 Months")] NineMonths = 9
    }
    public enum HealthNutritionType {
        [Description("No. of children")] NumChild = 1,
        [Description("Family Planning")] FamilyPlanning = 2,
        [Description("Breastfeeding")] Breastfeeding = 3,
        [Description("Others")] Others = 4
    }
    
    public enum HomeTenure {
        [Description("Owner")] NumChild = 1,
        [Description("Renter | Lessee | Tenant")] Tenant = 2,
        [Description("Caretaker | Pinatitirahan")] Caretaker = 3
    }


    public enum HomeTenureship {
        [Description("Owner")] Owner = 1,
        [Description("Renter | Lessee | Tenant")] Tenant = 2,
        [Description("Caretaker | Pinatitirahan")] Caretaker = 3,
    }
    public enum LetterTemplateType {
        Certification = 1, Summon = 2, Decision = 3
    }
    public static class EnumHelpers {
        public static string ToStringEnums(Enum en) {
            var type = en.GetType();

            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0) {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0) {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return en.ToString();
        }
        public static IList SpacesToList(Type type) {
            var list = new ArrayList();
            var enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues) {
                list.Add(new KeyValuePair<int, string>(Convert.ToInt16(value), ToStringEnums(value)));
            }
            return list;
        }





        //public static string GetEnumDescription(Enum value) {
        //    FieldInfo fi = value.GetType().GetField(value.ToString());

        //    DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

        //    if (attributes != null && attributes.Any()) {
        //        return attributes.First().Description;
        //    }

        //    return value.ToString();
        //}
    }

}