//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ioc.AutofacWebApi2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OTAAccorPushPriceData
    {
        public long ID { get; set; }
        public string TimeStamp { get; set; }
        public string EchoToken { get; set; }
        public string Target { get; set; }
        public string Version { get; set; }
        public string PrimaryLangID { get; set; }
        public string HotelCode { get; set; }
        public string LocatorID { get; set; }
        public Nullable<System.DateTime> Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public Nullable<bool> IsRoom { get; set; }
        public string InvTypeCode { get; set; }
        public string RatePlanCode { get; set; }
        public Nullable<int> NumberOfGuests { get; set; }
        public string CurrencyCode { get; set; }
        public Nullable<int> DecimalPlaces { get; set; }
        public Nullable<decimal> AmountBeforeTax { get; set; }
        public Nullable<decimal> AmountAfterTax { get; set; }
        public Nullable<int> MealPlanCodes { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
