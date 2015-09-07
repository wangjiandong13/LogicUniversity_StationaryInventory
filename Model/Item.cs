//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using TrackableEntities;
    
    [JsonObject(IsReference = true)]
    [DataContract]
    public partial class Item : ITrackable
    {
        public Item()
        {
            this.AdjustmentDetail = new List<AdjustmentDetail>();
            this.CartItems = new List<CartItems>();
            this.DisbursementDetail = new List<DisbursementDetail>();
            this.ItemPrice = new List<ItemPrice>();
            this.PurchaseOrderDetail = new List<PurchaseOrderDetail>();
            this.RequisitionDetail = new List<RequisitionDetail>();
            this.RetrievalDetail = new List<RetrievalDetail>();
            this.StockCard = new List<StockCard>();
        }
    
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public Nullable<int> ItemCatID { get; set; }
        [DataMember]
        public Nullable<int> RoLvl { get; set; }
        [DataMember]
        public Nullable<int> RoQty { get; set; }
        [DataMember]
        public string UOM { get; set; }
        [DataMember]
        public Nullable<int> Stock { get; set; }
        [DataMember]
        public string Bin { get; set; }
    
        [DataMember]
        public ICollection<AdjustmentDetail> AdjustmentDetail { get; set; }
        [DataMember]
        public ICollection<CartItems> CartItems { get; set; }
        [DataMember]
        public ICollection<DisbursementDetail> DisbursementDetail { get; set; }
        [DataMember]
        public ItemCategory ItemCategory { get; set; }
        [DataMember]
        public ICollection<ItemPrice> ItemPrice { get; set; }
        [DataMember]
        public ICollection<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        [DataMember]
        public ICollection<RequisitionDetail> RequisitionDetail { get; set; }
        [DataMember]
        public ICollection<RetrievalDetail> RetrievalDetail { get; set; }
        [DataMember]
        public ICollection<StockCard> StockCard { get; set; }
    
        [DataMember]
        public TrackingState TrackingState { get; set; }
        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }
        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}
