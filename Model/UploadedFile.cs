using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class UploadedFile
    {
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public string FileLength { get; set; }

        [DataMember]
        public string FileName { get; set; }

        //Other information. On upload only path and size are obvious.
        //...
    }
}
