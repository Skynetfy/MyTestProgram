//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ioc.ClaimsBasicMvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ModelPushLog
    {
        public long ID { get; set; }
        public string ModelType { get; set; }
        public string PushType { get; set; }
        public string HotelID { get; set; }
        public string TimeStamp { get; set; }
        public string XmlContent { get; set; }
        public Nullable<System.DateTime> Createdate { get; set; }
    }
}
