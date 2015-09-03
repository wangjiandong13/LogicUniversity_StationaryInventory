using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;

namespace RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CollectionAPI" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CollectionAPI.svc or CollectionAPI.svc.cs at the Solution Explorer and start debugging.
    public class CollectionAPI : ICollectionAPI
    {
        public List<CollectionPoint> getCollectionPoint()
        {
            BusinessLogic.CollectionPointController BL = new BusinessLogic.CollectionPointController();
            return BL.getCollectionPoint();
        }

        public List<CollectionPoint> getCollectionPoint(string CPID)
        {
            throw new NotImplementedException();
        }
    }
}
