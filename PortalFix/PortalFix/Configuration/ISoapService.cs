using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalFix
{
    public interface ISoapService
    {
        // Interface to methods in Droid project

        Task<List<wsCategory>> RefreshCategoriesAsync();
        Task<List<wsIncident>> RefreshIncidentsAsync();
        Task<List<wsSalesperson>> RefreshSalespersonAsync();
        Task<wsDetail> RefreshIncidentDetailAsync();
        Task<bool> SendEmailAsync();
    }
}
