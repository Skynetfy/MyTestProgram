namespace Ioc.WCFClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CANPOL_Extract
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string HotelID { get; set; }

        [Required]
        [StringLength(200)]
        public string Level { get; set; }

        [Required]
        [StringLength(200)]
        public string Type { get; set; }

        [Required]
        [StringLength(200)]
        public string Code { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string FromDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ToDate { get; set; }

        [StringLength(50)]
        public string Mon { get; set; }

        [StringLength(50)]
        public string Tue { get; set; }

        [StringLength(50)]
        public string Wed { get; set; }

        [StringLength(50)]
        public string Thu { get; set; }

        [StringLength(50)]
        public string Fri { get; set; }

        [StringLength(50)]
        public string Sat { get; set; }

        [StringLength(50)]
        public string Sun { get; set; }

        [StringLength(50)]
        public string Display { get; set; }

        [Column("Nb brackets")]
        [StringLength(50)]
        public string Nb_brackets { get; set; }

        [StringLength(50)]
        public string Forbidden { get; set; }

        [StringLength(50)]
        public string FromDays { get; set; }

        [StringLength(50)]
        public string ToDays { get; set; }

        [StringLength(50)]
        public string FromTime { get; set; }

        [StringLength(50)]
        public string ToTime { get; set; }

        [Column("Penalty status")]
        [StringLength(200)]
        public string Penalty_status { get; set; }

        [StringLength(200)]
        public string Amount { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
