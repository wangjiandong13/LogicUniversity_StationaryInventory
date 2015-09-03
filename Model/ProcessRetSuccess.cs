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
    public class ProcessRetSuccess
    {
        public ProcessRetSuccess() { }

        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Bin { get; set; }
        [DataMember]
        public string ItemID { get; set; }
        [DataMember]
        public string ItemName { get; set; }
        [DataMember]
        public int TotalQty { get; set; }
        [DataMember]
        public int ActualQty { get; set; }
    }
}
