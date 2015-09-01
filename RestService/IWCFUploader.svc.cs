using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "IWCFUploader" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select IWCFUploader.svc or IWCFUploader.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
                     InstanceContextMode = InstanceContextMode.PerCall,
                     IgnoreExtensionDataObject = true,
                     IncludeExceptionDetailInFaults = true)]
    public class WCFUploader : IIWCFUploader
    {
        #region IWCFUploader Members

        public UploadedFile Upload(Stream Uploading)
        {
            UploadedFile upload = new UploadedFile
            {
                FilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString())
            };

            int length = 0;
            using (FileStream writer = new FileStream(upload.FilePath, FileMode.Create))
            {
                int readCount;
                var buffer = new byte[8192];
                while ((readCount = Uploading.Read(buffer, 0, buffer.Length)) != 0)
                {
                    writer.Write(buffer, 0, readCount);
                    length += readCount;
                }
            }

            upload.FileLength = length.ToString();

            return upload;
        }

        public UploadedFile Transform(UploadedFile Uploading, string FileName)
        {
            Uploading.FileName = FileName;
            return Uploading;
        }

        #endregion
    }
}
