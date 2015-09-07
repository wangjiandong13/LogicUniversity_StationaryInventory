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
    public partial class Department : ITrackable
    {
        public Department()
        {
            this.Delegate = new List<Delegate>();
            this.Disbursement = new List<Disbursement>();
            this.Employee3 = new List<Employee>();
            this.Requisition = new List<Requisition>();
        }
    
        [DataMember]
        public string DeptID { get; set; }
        [DataMember]
        public string DeptName { get; set; }
        [DataMember]
        public Nullable<int> CPID { get; set; }
        [DataMember]
        public Nullable<int> Contact { get; set; }
        [DataMember]
        public Nullable<int> DeptHead { get; set; }
        [DataMember]
        public Nullable<int> DeptRep { get; set; }
        [DataMember]
        public Nullable<int> Phone { get; set; }
        [DataMember]
        public Nullable<int> Fax { get; set; }
    
        
        public CollectionPoint CollectionPoint { get; set; }
        
        public ICollection<Delegate> Delegate { get; set; }
        
        public Employee Employee { get; set; }
        
        public Employee Employee1 { get; set; }
        
        public Employee Employee2 { get; set; }
        
        public ICollection<Disbursement> Disbursement { get; set; }
        
        public ICollection<Employee> Employee3 { get; set; }
        
        public ICollection<Requisition> Requisition { get; set; }
    
        public TrackingState TrackingState { get; set; }
        public ICollection<string> ModifiedProperties { get; set; }
        private Guid EntityIdentifier { get; set; }
    }
}
