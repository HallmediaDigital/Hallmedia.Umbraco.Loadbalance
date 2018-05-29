using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Sync;

namespace Hallmedia.Umbraco.Loadbalance
{
    public class MasterServerRegistrar : IServerRegistrar2
    {
        public IEnumerable<IServerAddress> Registrations => Enumerable.Empty<IServerAddress>();

        public ServerRole GetCurrentServerRole()
        {
            return ServerRole.Master;
        }

        public string GetCurrentServerUmbracoApplicationUrl()
        {
            //NOTE: If you want to explicitly define the URL that your application is running on,
            // this wil be used for the server to communicate with itself, you can return the 
            // custom path here and it needs to be in this format:
            // http://www.mysite.com/umbraco

            return null;
        }
    }

    public class FrontEndReadOnlyServerRegistrar : IServerRegistrar2
    {
        public IEnumerable<IServerAddress> Registrations => Enumerable.Empty<IServerAddress>();

        public ServerRole GetCurrentServerRole()
        {
            return ServerRole.Slave;
        }

        public string GetCurrentServerUmbracoApplicationUrl()
        {
            return null;
        }
    }
}