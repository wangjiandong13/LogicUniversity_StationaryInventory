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
    public class ReportResult
    {
        public ReportResult() { }

        [DataMember]
        public String MonthYear { get; set; }
        [DataMember]
        public List<ReportResultItems> ReportItems { get; set; }
    }
}

