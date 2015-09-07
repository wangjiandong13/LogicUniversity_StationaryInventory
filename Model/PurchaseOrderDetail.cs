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
    public partial class PurchaseOrderDetail : ITrackable
    {
        [DataMember]
        public int PoSN { get; set; }
        [DataMember]
        public Nullable<int> PoID { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public Nullable<int> Qty { get; set; }
        [DataMember]
        public Nullable<int> ActualQty { get; set; }
        [DataMember]
        public Nullable<double> Price { get; set; }
        [DataMember]
        public string Remarks { get; set; }
    
        
        public Item Item { get; set; }
        
        public PurchaseOrder PurchaseOrder { get; set; }
    
        public TrackingState TrackingState { get; set; }
        public ICollection<string> ModifiedProperties { get; set; }
        private Guid EntityIdentifier { get; set; }
    }
}
