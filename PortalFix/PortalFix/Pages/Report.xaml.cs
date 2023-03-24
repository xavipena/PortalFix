using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PortalFix.ViewModels;

namespace PortalFix.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Report : ContentPage
    {
        private readonly ReportViewModel vm;
        public Report()
        {
            InitializeComponent();
            vm = new ReportViewModel();
            BindingContext = vm;

            vm.SelectedSalesperson = new Salesperson();
            vm.TxtSubject = string.Empty;
            vm.TxtWhen = string.Empty;
            vm.TxtBody = string.Empty;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (vm.NoMissingData())
            {
                if (vm.CallSendEmail())
                {
                    DisplayAlert("Aviso", "Información enviada", "OK");
                    Navigation.PopToRootAsync();
                }
            }
            else
            {
                DisplayAlert("Aviso", "Se han de rellenar todas las casillas", "OK");
            }

        }
    }
}