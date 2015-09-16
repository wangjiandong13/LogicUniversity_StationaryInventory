using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Upload" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Upload.svc or Upload.svc.cs at the Solution Explorer and start debugging.
    public class Upload : IUpload
    {
        string IUpload.Upload(string imageStr,string Filename)
        {
            AppDomain root = AppDomain.CurrentDomain;
            AppDomainSetup setup = new AppDomainSetup();
            string savePath = root.SetupInformation.ApplicationBase.Replace("RestService\\", "") + "Web\\img\\signatures\\" + Filename+".jpg";
            byte[] b = Convert.FromBase64String(imageStr);
            FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate);
            fs.Write(b, 0, b.Length);
            fs.Close();
            return "/img/signatures/" + Filename + ".jpg";
        }
    }
}
