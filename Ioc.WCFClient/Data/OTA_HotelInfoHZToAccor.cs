namespace Ioc.WCFClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OTA_HotelInfoHZToAccor
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string HZHotelId { get; set; }

        [StringLength(50)]
        public string AccorHotelId { get; set; }

        [StringLength(50)]
        public string HZRoomType { get; set; }

        [StringLength(50)]
        public string AccorRoomType { get; set; }

        [StringLength(50)]
        public string HZRate { get; set; }

        [StringLength(50)]
        public string AccorRate { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
