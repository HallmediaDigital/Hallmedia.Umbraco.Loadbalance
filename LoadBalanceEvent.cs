using System.Configuration;
using Umbraco.Core;
using Umbraco.Core.Sync;

namespace Hallmedia.Umbraco.Loadbalance
{
    public class LoadBalanceEvent : IApplicationEventHandler
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
            //This should be executed on your master server
            var serverIsMaster = bool.Parse(ConfigurationManager.AppSettings["serverIsMaster"]);

            if (serverIsMaster)
                ServerRegistrarResolver.Current.SetServerRegistrar(new MasterServerRegistrar());
            else
                ServerRegistrarResolver.Current.SetServerRegistrar(new FrontEndReadOnlyServerRegistrar());
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication,
            ApplicationContext applicationContext)
        {
        }
    }
}