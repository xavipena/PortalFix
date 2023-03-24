using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PortalFix
{
    public class FixManager
    {
        ISoapService soapService;

        public FixManager(ISoapService service)
        {
            soapService = service;
        }

        public Task<List<wsCategory>> GetCategoriesAsync()
        {
            return soapService.RefreshCategoriesAsync();
        }

        public Task<List<wsIncident>> GetIncidentsAsync()
        {
            return soapService.RefreshIncidentsAsync();
        }
        public Task<wsDetail> GetIncidentDetailAsync()
        {
            return soapService.RefreshIncidentDetailAsync();
        }
        public Task<List<wsSalesperson>> GetSalespersonsAsync()
        {
            return soapService.RefreshSalespersonAsync();
        }
        public Task<bool> SendEmailAsync()
        {
            return soapService.SendEmailAsync();
        }
    }
}
