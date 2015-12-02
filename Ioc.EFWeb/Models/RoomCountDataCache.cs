namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoomCountDataCache")]
    public partial class RoomCountDataCache
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string CheckInDate { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string HotelId { get; set; }

        [Key]
        [Column(Order = 3)]
        public bool HasRoom { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(10)]
        public string RoomTypeCode { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool HashPush { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime LastModifyDate { get; set; }

        [Key]
        [Column(Order = 7)]
        public DateTime CreateDate { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsDel { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SourceType { get; set; }
    }
}
