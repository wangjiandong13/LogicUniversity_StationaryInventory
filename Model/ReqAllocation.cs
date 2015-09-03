using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using TrackableEntities;

namespace Model
{
    [JsonObject(IsReference = true)]
    [DataContract]
    public class ReqAllocation
    {
        public ReqAllocation() { }

        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public int ReqID { get; set; }
        [DataMember]
        public string Dept { get; set; }
        [DataMember]
        public string Priority { get; set; }
        [DataMember]
        public int RequestQty { get; set; }
        [DataMember]
        public int IssueQty { get; set; }
    }
}
