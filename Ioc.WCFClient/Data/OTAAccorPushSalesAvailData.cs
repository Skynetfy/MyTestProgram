namespace Ioc.WCFClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OTAAccorPushSalesAvailData")]
    public partial class OTAAccorPushSalesAvailData
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string TimeStamp { get; set; }

        [StringLength(50)]
        public string LocatorID { get; set; }

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
        public string RatePlanCodeType { get; set; }

        [StringLength(50)]
        public string InvCodeApplication { get; set; }

        [StringLength(50)]
        public string BrandCode { get; set; }

        public bool? Mon { get; set; }

        public bool? Tue { get; set; }

        public bool? Weds { get; set; }

        public bool? Thur { get; set; }

        public bool? Fri { get; set; }

        public bool? Sat { get; set; }

        public bool? Sun { get; set; }

        [StringLength(50)]
        public string FixedPatternLength { get; set; }

        public bool? ArrivalDateBased { get; set; }

        [StringLength(50)]
        public string TimeUnit { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string MinMaxMessageType { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
