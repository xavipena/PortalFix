using System;
using System.Collections.Generic;
using System.Text;

namespace PortalFix.Configuration
{
    static class Settle
    {
        public enum NetworkStatus
        {
            NotReachable,
            ReachableViaCarrierDataNetwork,
            ReachableViaWiFiNetwork
        }

        static Settle()
        {
        }
    }
}
