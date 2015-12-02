namespace Ioc.EFWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PushLog")]
    public partial class PushLog
    {
        public int ID { get; set; }

        [StringLength(200)]
        public string Type { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
