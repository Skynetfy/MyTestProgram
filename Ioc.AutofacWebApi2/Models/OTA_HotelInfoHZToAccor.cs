//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ioc.AutofacWebApi2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OTA_HotelInfoHZToAccor
    {
        public int ID { get; set; }
        public string HZHotelId { get; set; }
        public string AccorHotelId { get; set; }
        public string HZRoomType { get; set; }
        public string AccorRoomType { get; set; }
        public string HZRate { get; set; }
        public string AccorRate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}