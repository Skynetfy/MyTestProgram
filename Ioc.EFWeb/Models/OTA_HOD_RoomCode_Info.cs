namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OTA_HOD_RoomCode_Info
    {
        [Key]
        [Column(Order = 0)]
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
    }
}
