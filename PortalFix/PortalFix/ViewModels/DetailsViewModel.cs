using MvvmHelpers;

namespace PortalFix.ViewModels
{
    class DetailsViewModel : BaseViewModel
    {
        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string InfoLine { get; set; }
        public string PageDetail { get; set; }
        public string PageSolution { get; set; }

        public DetailsViewModel()
        {
            PageTitle = Singleton.levelOneTitle;
            PageSubTitle = Singleton.levelTwoTitle;
            if (Singleton.levelOneSelection == 10)
            {
                InfoLine = "Ten en cuenta esta incidencia hasta su resolución";
            }
            else
            {
                InfoLine = "Prueba a resolver el problema con estos consejos o envía una incidencia";
            }

            wsDetail detail = App.PortalFixManager.GetIncidentDetailAsync().Result;
            PageDetail = detail.Detail;
            PageSolution = detail.Solution;
        }
    }
}
