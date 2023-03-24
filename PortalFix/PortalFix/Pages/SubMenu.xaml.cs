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
    public partial class SubMenu : ContentPage
    {
        SubMenuViewModel vm;

        public SubMenu()
        {
            vm = new SubMenuViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            MenuOption men = ((ListView)sender).SelectedItem as MenuOption;
            if (men == null)
            {
                return;
            }
            // Clear selection
            ((ListView)sender).SelectedItem = null;

            vm.SaveCurrentSelection(men.menuID);
            await Navigation.PushAsync(new Details());
        }
    }
}