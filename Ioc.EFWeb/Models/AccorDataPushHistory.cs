namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AccorDataPushHistory")]
    public partial class AccorDataPushHistory
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string HotelCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime StartDate { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime EndDate { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(10)]
        public string InvTypeCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string RatePlanCode { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string LocatorID { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "datetime2")]
        public DateTime PushTime { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime SaveTime { get; set; }

        public string ContextJson { get; set; }

        [Key]
        [Column(Order = 8)]
        public DateTime LastModifiedTime { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string PushType { get; set; }
    }
}
