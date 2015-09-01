using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IIWCFUploader" in both code and config file together.
    [ServiceContract(Name = "IWCFUploader"]
    public interface IIWCFUploader
    {
        [OperationContract(Name = "Upload")]
        [DataContractFormat]
        [WebInvoke(Method = "POST",
                   UriTemplate = "Upload/",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Upload(Stream Uploading);

        [OperationContract(Name = "Transform")]
        [DataContractFormat]
        [WebInvoke(Method = "POST",
                   UriTemplate = "Transform",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   ResponseFormat = WebMessageFormat.Json)]
        UploadedFile Transform(UploadedFile Uploading, string FileName);
    }
}
