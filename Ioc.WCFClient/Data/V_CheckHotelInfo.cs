namespace Ioc.WCFClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class V_CheckHotelInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string HotelCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string RoomCode { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaxOccupancy { get; set; }

        [StringLength(50)]
        public string HotelID { get; set; }

        [StringLength(50)]
        public string RatePlanCode { get; set; }

        [StringLength(50)]
        public string RoomTypeCode { get; set; }
    }
}
