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
    public class ProposePo
    {
        public ProposePo() { }

        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int totalQty { get; set; }
        [DataMember]
        public int supplier1Qty { get; set; }
        [DataMember]
        public int supplier2Qty { get; set; }
        [DataMember]
        public int supplier3Qty { get; set; }

    }
}
