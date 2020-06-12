using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Steeltoe.Security.Authentication.CloudFoundry.Wcf;

namespace CloudFoundryWcf
{
    public class SteeltoeHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new ServiceHost(serviceType, baseAddresses).AddJwtAuthorization(ApplicationConfig.Configuration, null, ApplicationConfig.LoggerFactory);
        }
        
    }
}