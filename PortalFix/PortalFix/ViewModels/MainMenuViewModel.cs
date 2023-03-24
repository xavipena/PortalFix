using System.Collections.Generic;
using System.Collections.ObjectModel;
using MvvmHelpers;

namespace PortalFix.ViewModels
{
    class MainMenuViewModel : BaseViewModel
    {
        public ObservableCollection<MenuOption> MainMenuOps { get; set; }

        public MainMenuViewModel()
        {
            MainMenuOps = new ObservableCollection<MenuOption>();
            MenuOptionList mainOptions = LoadMenuOptions();
            foreach (MenuOption mo in mainOptions)
            {
                MainMenuOps.Add(mo);
            }
        }

        private MenuOption ConvertToMenuOption(wsCategory cat)
        {
            string icon = string.Empty;
            switch (cat.type)
            {
                case Types.Categories.INCIDENT:
                    icon = "warning.png";
                    break;
                case Types.Categories.WARNING:
                    icon = "qmark_red.png";
                    break;
                case Types.Categories.PROCEDURE:
                    icon = "qmark_blue.png";
                    break;
                case Types.Categories.SOLVED:
                    icon = "OK.png";
                    break;
            }
            return new MenuOption
            {
                menuID = int.Parse(cat.IDCat),
                description = cat.CatName,
                iimageSource = icon,
                count = string.Format("{0:00}", cat.count),
                backColor = cat.type == Types.Categories.WARNING ? "LightCoral" : "LightBlue"
            };
        }

        private MenuOptionList LoadMenuOptions()
        {
            MenuOptionList mopl = new MenuOptionList();
            List<wsCategory> cats = App.PortalFixManager.GetCategoriesAsync().Result;
            
            foreach (wsCategory ct in cats)
            {
                mopl.Add(ConvertToMenuOption(ct));
            }
            mopl.Add(new MenuOption
            {
                menuID = Options.SEND_MAIL,
                description = "No es ninguna de estas",
                iimageSource = "mail.png",
                count = ""
            });
            return mopl;
        }

        public void SaveCurrentSelection(int option)
        {
            Singleton.levelOneSelection = option;
            foreach (MenuOption mo in MainMenuOps)
            {
                if (mo.menuID == option)
                {
                    Singleton.levelOneTitle = mo.description;
                }
            }
        }
    }
}
