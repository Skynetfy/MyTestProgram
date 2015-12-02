namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OTA_RoomPriceDataCache
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string HotelID { get; set; }

        [Required]
        [StringLength(200)]
        public string RoomType { get; set; }

        public decimal HotelPrice { get; set; }

        public decimal MarketPrice { get; set; }

        [Required]
        public string PriceCheck { get; set; }

        public DateTime BizDate { get; set; }

        public bool HashPush { get; set; }

        public DateTime LastModifyDate { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDel { get; set; }
    }
}
