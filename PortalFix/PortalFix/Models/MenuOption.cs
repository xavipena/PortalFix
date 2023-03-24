using System.Collections.Generic;
using MvvmHelpers;

namespace PortalFix
{
    public class MenuOption : ObservableObject
    {
        public int menuID { get; set; }
        public string description { get; set; }
        public string iimageSource { get; set; }
        public string count { get; set;  }
        public string backColor { get; set; }
    }
    public class MenuOptionList : List<MenuOption>
    {
        public List<MenuOption> menuList { get; set; }
    }
    public class Salesperson
    {
        public int spCode { get; set; }
        public string spName { get; set; }
    }
    public class SalespersonList : List<Salesperson>
    {
        public List<Salesperson> salepersonList { get; set; }
    }
}
