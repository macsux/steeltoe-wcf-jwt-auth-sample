using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.ServiceModel;
using Microsoft.Extensions.Configuration;
using Steeltoe.CloudFoundry.Connector;
using Steeltoe.CloudFoundry.Connector.Services;
using Steeltoe.Security.Authentication.CloudFoundry;
using Steeltoe.Security.Authentication.CloudFoundry.Wcf;

namespace CloudFoundryWcf
{
    public class MyJwtAuthorizationManager : ServiceAuthorizationManager
    {
        public static ServiceAuthorizationManager Instance { get; set; }
        public MyJwtAuthorizationManager()
        {
            
        }

        public override bool CheckAccess(OperationContext operationContext)
        {
            return Instance.CheckAccess(operationContext);
        }
    }
}