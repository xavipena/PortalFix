using System;
using System.Collections.Generic;
using System.Text;

namespace PortalFix
{
    public class wsCategory
    {
        public string IDCat { get; set; }
        public string CatName { get; set; }
        public string type { get; set; }
        public int count { get; set; }
    }
    public class wsIncident
    {
        public string IDInc { get; set; }
        public string IncName { get; set; }
    }
    public class wsDetail
    {
        public string Detail { get; set; }
        public string Solution { get; set; }
    }
    public class wsSalesperson
    {
        public int SalespersonCode { get; set; }
        public string SalespersonName { get; set; }
    }
}
