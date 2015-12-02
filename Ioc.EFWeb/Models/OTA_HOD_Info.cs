namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OTA_HOD_Info
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string HotelCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string HotelName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string LastModifiedTime { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string BrandCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(100)]
        public string BrandName { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string hotelStatus { get; set; }
    }
}
