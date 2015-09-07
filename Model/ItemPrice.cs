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
    public partial class ItemPrice : ITrackable
    {
        [DataMember]
        public int IPID { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string SupplierID { get; set; }
        [DataMember]
        public Nullable<double> Price { get; set; }
    
        [DataMember]
        public Item Item { get; set; }
        [DataMember]
        public Supplier Supplier { get; set; }
    
        [DataMember]
        public TrackingState TrackingState { get; set; }
        [DataMember]
        public ICollection<string> ModifiedProperties { get; set; }
        [JsonProperty, DataMember]
        private Guid EntityIdentifier { get; set; }
    }
}
