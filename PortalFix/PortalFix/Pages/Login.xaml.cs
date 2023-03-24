using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PortalFix.ViewModels;

using Xamarin.Essentials;

namespace PortalFix.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        LoginViewModel vm = new LoginViewModel();
        public Login()
        {
            BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "PIN incorrecto", "OK");
            vm.WelcomeText = "Acceso";
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);


            btnGo.Clicked += (object sender, EventArgs e) =>
            {
                //XFFlipViewControl1.IsFlipped = !XFFlipViewControl1.IsFlipped;
                if (vm.ValidCredential())
                {

                    NetworkAccess current = Connectivity.NetworkAccess;
                    if (current == NetworkAccess.Internet)
                    {
                        vm.WelcomeText = "CARGANDO...";
                        // Connection to internet is available
                        Navigation.PushAsync(new MainMenu());
                    }
                    else
                    {
                        DisplayAlert("Error", "No hay una conexión a Internet", "OK");
                    }
                }
            };
        }
        protected override void OnAppearing()
        {
            vm.WelcomeText = "Acceso";
            Password.Text = string.Empty;
        }
    }
}