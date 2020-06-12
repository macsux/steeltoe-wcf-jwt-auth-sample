using System;
using Steeltoe.Security.Authentication.CloudFoundry.Wcf;

namespace SteeltoeWcf
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            var client = new ServiceReference1.ValueServiceClient("BasicHttpsBinding_IValueService", "https://wcf-with-jwt.apps.pcfone.io/ValueService.svc");
            // var client = new ServiceReference1.ValueServiceClient("BasicHttpsBinding_IValueService", "https://localhost:44315/ValueService.svc");
            var opt = new CloudFoundryOptions(); 
            opt.AccessTokenEndpoint = "/oauth/token"; // default
            opt.AuthorizationUrl = "https://pivot-astakhov.login.run.pcfone.io";
            opt.AuthorizationEndpoint = "/oauth/authorize"; // default
            opt.ClientId = "76761955-8dc9-4f0b-9ece-066feb064eb1";
            opt.ClientSecret = "ac14fe49-e5c6-4cde-9a97-7cd72951ba74";
            opt.AdditionalTokenScopes = "todo.read todo.write";
            client.Endpoint.EndpointBehaviors.Add(new JwtHeaderEndpointBehavior(opt));
            try
            {
                string msg = client.GetData();
                Console.WriteLine(msg);
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}