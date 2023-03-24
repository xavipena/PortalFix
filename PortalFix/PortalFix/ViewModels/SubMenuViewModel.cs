using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;

namespace PortalFix.ViewModels
{
    class SubMenuViewModel : BaseViewModel
    {
        public ObservableCollection<MenuOption> SubMenu { get; set; }
        public string PageTitle { get; set; }
        public string PageSubtitle { get; set; }

        public SubMenuViewModel()
        {
            SubMenu = new ObservableCollection<MenuOption>();
            var mainOptions = LoadMenuOptions();
            foreach (MenuOption mo in mainOptions)
            {
                SubMenu.Add(mo);
            }
            PageTitle = Singleton.levelOneTitle;
            PageSubtitle = "Selecciona una de las incidencias de este tipo";
            if (Singleton.levelOneSelection == 10)
            {
                PageSubtitle = "Incididencias identificadas, en proceso de corrección";
            }
        }

        private MenuOption ConvertToMenuOption(wsIncident inc)
        {
            return new MenuOption
            {
                menuID = int.Parse(inc.IDInc),
                description = inc.IncName,
                iimageSource = Singleton.icon
            };
        }

        private MenuOptionList LoadMenuOptions()
        {
            MenuOptionList mopl = new MenuOptionList();
            List<wsIncident> incs = App.PortalFixManager.GetIncidentsAsync().Result;

            foreach (wsIncident ic in incs)
            {
                mopl.Add(ConvertToMenuOption(ic));
            }
            return mopl;
        }

        public void SaveCurrentSelection(int option)
        {
            Singleton.levelTwoSelection = option;
            foreach (MenuOption mo in SubMenu)
            {
                if (mo.menuID == option)
                {
                    Singleton.levelTwoTitle = mo.description;
                }
            }
        }
    }
}
