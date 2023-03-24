using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Services.Protocols;
using System.Net;

using PortalFix;

namespace PortalFix.Droid
{
    public class SoapService : ISoapService
    {
        public static PereladaOraWS.PereladaOraWS wsOra;
        TaskCompletionSource<bool> getRequestComplete = null;

        public List<wsCategory> Categories { get; private set; } = new List<wsCategory>();
        public List<wsIncident> Incidents{ get; private set; } = new List<wsIncident>();
        public List<wsSalesperson> Salespersons { get; private set; } = new List<wsSalesperson>();
        public wsDetail IncDetails { get; private set; }

        public SoapService()
        {
            wsOra = new PereladaOraWS.PereladaOraWS
            {
                Url = Server._HOST + Server._PORTALFIX_ORA_URL
            };
            wsOra.FixGetCategoriesCompleted += wsOra_GetCategoriesCompleted;

            // WS calls
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.ServerCertificateValidationCallback += delegate {
                return true;
            };

        }

        // Convert from DataRow to data model class
        private static wsCategory ConvertToCategory(DataRow item)
        {
            return new wsCategory
            {
                IDCat = item[0].ToString(),
                CatName = item[1].ToString(),
                type = item[2].ToString(),
                count = int.Parse(item[3].ToString())
            };
        }
        private static wsIncident ConvertToIncident(DataRow item)
        {
            return new wsIncident
            {
                IDInc = item[0].ToString(),
                IncName = item[1].ToString()
            };
        }
        private static wsSalesperson ConvertToSalesperson(DataRow item)
        {
            return new wsSalesperson
            {
                SalespersonCode = int.Parse(item[0].ToString()),
                SalespersonName = item[1].ToString()
            };
        }

        // Event handlers for tasks defined in the proxy class
        private void wsOra_GetCategoriesCompleted(object sender, PereladaOraWS.FixGetCategoriesCompletedEventArgs e)
        {
            try
            {
                getRequestComplete ??= new TaskCompletionSource<bool>();

                Categories = new List<wsCategory>();
                foreach (DataRow drow in e.Result.Tables[0].Rows)
                {
                    Categories.Add(ConvertToCategory(drow));
                }
                getRequestComplete?.TrySetResult(true);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }
        }

        // ----------------------------------------------------------------------------------
        // Async version. This one is waiting forever for the task to complete. So I changed
        // to a Sync call below
        // ----------------------------------------------------------------------------------

        public async Task<List<wsCategory>> _RefreshCategoriesAsync()
        {
            getRequestComplete = new TaskCompletionSource<bool>();

            wsOra.FixGetCategoriesAsync();
            await getRequestComplete.Task;
            return Categories;
        }

        public Task<List<wsCategory>> RefreshCategoriesAsync()
        {
            Categories = new List<wsCategory>();
            DataSet ds = wsOra.FixGetCategories();
            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                Categories.Add(ConvertToCategory(drow));
            }
            return Task.FromResult<List<wsCategory>>(Categories);
        }

        public Task<List<wsIncident>> RefreshIncidentsAsync()
        {
            Incidents = new List<wsIncident>();
            DataSet ds = wsOra.FixGetIncidentlist(Singleton.levelOneSelection);
            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                Incidents.Add(ConvertToIncident(drow));
            }
            return Task.FromResult<List<wsIncident>>(Incidents);
        }
        public Task<List<wsSalesperson>> RefreshSalespersonAsync()
        {
            Salespersons = new List<wsSalesperson>();
            DataSet ds = wsOra.FixGetSalespersons();
            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                Salespersons.Add(ConvertToSalesperson(drow));
            }
            return Task.FromResult<List<wsSalesperson>>(Salespersons);
        }

        public Task<wsDetail> RefreshIncidentDetailAsync()
        {
            IncDetails = new wsDetail();
            DataSet ds = wsOra.FixGetIncident(Singleton.levelOneSelection, Singleton.levelTwoSelection);
            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                IncDetails.Detail = drow[0].ToString();
                IncDetails.Solution = drow[1].ToString();
            }
            return Task.FromResult<wsDetail>(IncDetails);
        }

        public Task<bool> SendEmailAsync()
        {
            bool status = wsOra.FixSendNewIncident(Singleton.EmailBody);
            return Task.FromResult<bool>(status);
        }
    }
}