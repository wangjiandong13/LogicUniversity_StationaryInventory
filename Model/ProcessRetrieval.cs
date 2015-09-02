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
    public class ProcessRetrieval
    {
        public ProcessRetrieval() { }

        [DataMember]
        public int EmpID { get; set; }
        [DataMember]
        public int ReqID { get; set; }

    }
}
