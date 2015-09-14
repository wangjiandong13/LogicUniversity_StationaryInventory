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
    public class ReportResultItems
    {
        public ReportResultItems() { }

        [DataMember]
        public int Qty { get; set; }
        [DataMember]
        public String Subject { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}
