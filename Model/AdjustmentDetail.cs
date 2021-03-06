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
    public partial class AdjustmentDetail : ITrackable
    {
        [DataMember]
        public int AdjSN { get; set; }
        [DataMember]
        public string AdjID { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public Nullable<int> Qty { get; set; }
        [DataMember]
        public Nullable<double> Price { get; set; }
        [DataMember]
        public string Reason { get; set; }
        [DataMember]
        public string Remark { get; set; }
    
        
        public AdjustmentVoucher AdjustmentVoucher { get; set; }
        
        public Item Item { get; set; }
    
        public TrackingState TrackingState { get; set; }
        public ICollection<string> ModifiedProperties { get; set; }
        private Guid EntityIdentifier { get; set; }
    }
}
