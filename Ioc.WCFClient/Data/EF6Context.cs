namespace Ioc.WCFClient.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EF6Context : DbContext
    {
        public EF6Context()
            : base("name=EF6Context")
        {
        }

        public virtual DbSet<CANPOL_Extract> CANPOL_Extract { get; set; }
        public virtual DbSet<ModelPushLog> ModelPushLog { get; set; }
        public virtual DbSet<OTA_HotelInfoHZToAccor> OTA_HotelInfoHZToAccor { get; set; }
        public virtual DbSet<OTA_RoomPriceDataCache> OTA_RoomPriceDataCache { get; set; }
        public virtual DbSet<OTAAccorPushCountData> OTAAccorPushCountData { get; set; }
        public virtual DbSet<OTAAccorPushDataXmlResult> OTAAccorPushDataXmlResult { get; set; }
        public virtual DbSet<OTAAccorPushPriceData> OTAAccorPushPriceData { get; set; }
        public virtual DbSet<OTAAccorPushSalesBookingRuleData> OTAAccorPushSalesBookingRuleData { get; set; }
        public virtual DbSet<PushLog> PushLog { get; set; }
        public virtual DbSet<AccorDataPushHistory> AccorDataPushHistory { get; set; }
        public virtual DbSet<OTA_HOD_Info> OTA_HOD_Info { get; set; }
        public virtual DbSet<OTA_HOD_RoomCode_Info> OTA_HOD_RoomCode_Info { get; set; }
        public virtual DbSet<OTAAccorPushSalesAvailData> OTAAccorPushSalesAvailData { get; set; }
        public virtual DbSet<RoomCountDataCache> RoomCountDataCache { get; set; }
        public virtual DbSet<V_CheckHotelInfo> V_CheckHotelInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
