namespace Ioc.WCFClient.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OTAAccorPushDataXmlResult")]
    public partial class OTAAccorPushDataXmlResult
    {
        public long ID { get; set; }

        [StringLength(200)]
        public string PushType { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public DateTime? TimeStamp { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
