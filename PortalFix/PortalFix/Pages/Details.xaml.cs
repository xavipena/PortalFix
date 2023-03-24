using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PortalFix.ViewModels;

namespace PortalFix.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details : ContentPage
    {
        DetailsViewModel vm;
        public Details()
        {
            InitializeComponent();
            vm = new DetailsViewModel();
            BindingContext = vm;
        }

        private void ImageButtonMail_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Report());
        }

        private void ImageButtonOK_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}