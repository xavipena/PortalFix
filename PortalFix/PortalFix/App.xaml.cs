using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PortalFix
{
    public partial class App : Application
    {
        public static FixManager PortalFixManager { get; set; }
        public App()
        {
            InitializeComponent();
            // Initialize NavigationPage for further calls to push & pop
            MainPage = new NavigationPage(new Pages.Login());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
