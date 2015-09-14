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
    public class ReportModel
    {
        public ReportModel() { }

        [DataMember]
        public int ReportID { get; set; }
        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime StartD { get; set; }
        [DataMember]
        public DateTime EndD { get; set; }
        [DataMember]
        public string Remark { get; set; }
        [DataMember]
        public int Type { get; set; }
        [DataMember]
        public int Criteria { get; set; }
        [DataMember]
        public int Precriteria { get; set; }

        [DataMember]
        public List<ReportResult> Results { get; set; }

    }
}
