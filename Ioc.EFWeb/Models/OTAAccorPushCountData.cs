namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OTAAccorPushCountData")]
    public partial class OTAAccorPushCountData
    {
        public long ID { get; set; }

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

        [StringLength(50)]
        public string LocatorID { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public bool? IsRoom { get; set; }

        [StringLength(50)]
        public string InvTypeCode { get; set; }

        [StringLength(50)]
        public string RatePlanCode { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
