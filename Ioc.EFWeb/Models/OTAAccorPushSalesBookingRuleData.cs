namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OTAAccorPushSalesBookingRuleData")]
    public partial class OTAAccorPushSalesBookingRuleData
    {
        [Key]
        public long D { get; set; }

        [StringLength(50)]
        public string TimeStamp { get; set; }

        [StringLength(50)]
        public string EchoToken { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        [StringLength(20)]
        public string Version { get; set; }

        [StringLength(20)]
        public string PrimaryLangID { get; set; }

        [StringLength(50)]
        public string HotelCode { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public bool? IsRoom { get; set; }

        [StringLength(50)]
        public string InvTypeCode { get; set; }

        [StringLength(50)]
        public string RatePlanCode { get; set; }

        [StringLength(50)]
        public string BrandCode { get; set; }

        [StringLength(50)]
        public string ChainCode { get; set; }

        public bool? Mon { get; set; }

        public bool? Tue { get; set; }

        public bool? Weds { get; set; }

        public bool? Thur { get; set; }

        public bool? Fri { get; set; }

        public bool? Sat { get; set; }

        public bool? Sun { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
