//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrgyMgmt.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Household
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Household()
        {
            this.HouseholdPropertyProductions = new HashSet<HouseholdPropertyProduction>();
            this.Residents = new HashSet<Resident>();
        }
    
        public int HouseholdId { get; set; }
        public string FriendlyName { get; set; }
        public string RoomNumber { get; set; }
        public string FloorNumber { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public Nullable<int> SitioId { get; set; }
        public Nullable<int> HomeTenure { get; set; }
        public Nullable<int> ConstructionType { get; set; }
        public Nullable<int> FamilyCount { get; set; }
        public Nullable<int> FamilyWithSameKitchen { get; set; }
        public Nullable<int> FamilyWithSeparateKitchen { get; set; }
        public Nullable<int> LandTenure { get; set; }
        public Nullable<int> AverageMonthlyIncome { get; set; }
        public Nullable<int> PotableWaterSupplySource { get; set; }
        public Nullable<int> ToiletFacility { get; set; }
        public Nullable<int> PowerSupply { get; set; }
        public string SanitationPractices { get; set; }
        public Nullable<bool> CompostHeap { get; set; }
        public Nullable<bool> TrashSegregation { get; set; }
        public bool MemberOfLivelihood { get; set; }
        public string ProgramName { get; set; }
        public string VegetableGardens { get; set; }
        public Nullable<bool> HasFishPond { get; set; }
        public string NeedsFirst { get; set; }
        public string NeedsSecond { get; set; }
        public string NeedsThird { get; set; }
        public string FamilyPlanning { get; set; }
        public Nullable<bool> HavePregnantMothers { get; set; }
        public Nullable<int> PregnantMonths { get; set; }
        public Nullable<bool> IsPregnantTeen { get; set; }
        public string BreastFeeding { get; set; }
        public string OtherNutrition { get; set; }
        public string HealthCard { get; set; }
        public string OtherInformation { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HouseholdPropertyProduction> HouseholdPropertyProductions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resident> Residents { get; set; }
    }
}
