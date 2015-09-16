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
    public class ReportResultItemsWeb
    {
        public ReportResultItemsWeb() { }

        [DataMember]
        public String x { get; set; }
        [DataMember]
        public double y { get; set; }
    }
}
