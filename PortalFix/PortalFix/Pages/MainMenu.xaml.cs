
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PortalFix.ViewModels;

namespace PortalFix.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        private readonly MainMenuViewModel vm;
        public MainMenu()
        {
            InitializeComponent();
            vm = new MainMenuViewModel();
            BindingContext = vm;
        }

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuOption men = ((ListView)sender).SelectedItem as MenuOption;
            if (men == null)
            {
                return;
            }

            // Clear selection
            ((ListView)sender).SelectedItem = null;

            Singleton.icon = men.iimageSource;
            vm.SaveCurrentSelection(men.menuID);
            if (men.menuID == Options.SEND_MAIL)
            {
                await Navigation.PushAsync(new Report());
            }
            else
            {
                await Navigation.PushAsync(new SubMenu());
            }
        }
    }
}