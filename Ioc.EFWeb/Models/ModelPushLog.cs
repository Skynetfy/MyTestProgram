namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModelPushLog")]
    public partial class ModelPushLog
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string ModelType { get; set; }

        [StringLength(200)]
        public string PushType { get; set; }

        [StringLength(50)]
        public string HotelID { get; set; }

        [StringLength(50)]
        public string TimeStamp { get; set; }

        [Column(TypeName = "text")]
        public string XmlContent { get; set; }

        public DateTime? Createdate { get; set; }
    }
}
