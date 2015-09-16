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
    public class ReportResultWeb
    {
        public ReportResultWeb() { }

        [DataMember]
        public String key { get; set; }
        [DataMember]
        public ICollection<ReportResultItemsWeb> values { get; set; }
    }
}

