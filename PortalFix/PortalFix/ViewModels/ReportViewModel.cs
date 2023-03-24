using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace PortalFix.ViewModels
{
    public class ReportViewModel : INotifyPropertyChanged
    {
        public List<Salesperson> salespersonList;
        public List<Salesperson> SalespersonList
        {
            get { return salespersonList; }
            set
            {
                if (salespersonList != value)
                {
                    salespersonList = value;
                    OnPropertyChanged();
                }
            }
        }

        private Salesperson selectedSalesperson;
        public Salesperson SelectedSalesperson
        {
            get { return selectedSalesperson; }
            set
            {
                if (selectedSalesperson != value)
                {
                    selectedSalesperson = value;
                    OnPropertyChanged();
                }
            }
        }
        private string txtSubject;
        public string TxtSubject
        {
            get { return txtSubject; }
            set
            {
                if (txtSubject != value)
                {
                    txtSubject = value;
                    OnPropertyChanged();
                }
            }
        }
        private string txtWhen;
        public string TxtWhen
        {
            get { return txtWhen; }
            set
            {
                if (txtWhen != value)
                {
                    txtWhen = value;
                    OnPropertyChanged();
                }
            }
        }
        private string txtBody;
        public string TxtBody
        {
            get { return txtBody; }
            set
            {
                if (txtBody != value)
                {
                    txtBody = value;
                    OnPropertyChanged();
                }
            }
        }
        /*
        public IList<Salesperson> PickerList
        {
            get
            {
                return SalespersonList;
            }
        }
        Same as:
        */
        public IList<Salesperson> PickerList => SalespersonList;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            /*
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
            Same as:
            */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ReportViewModel()
        {
            // Load once
            if (SalespersonList == null)
            {
                SalespersonList = LoadSalespersons();
            }
        }

        private Salesperson ConvertToSalesperson(wsSalesperson sp)
        {
            return new Salesperson
            {
                spCode = sp.SalespersonCode,
                spName = sp.SalespersonName
            };
        }

        private SalespersonList LoadSalespersons()
        {
            SalespersonList splist = new SalespersonList();
            List<wsSalesperson> sper = App.PortalFixManager.GetSalespersonsAsync().Result;

            foreach (wsSalesperson sp in sper)
            {
                splist.Add(ConvertToSalesperson(sp));
            }
            return splist;
        }

        public bool NoMissingData()
        {
            bool populated = true;

            populated = populated && SelectedSalesperson.spName != string.Empty;
            populated = populated && TxtSubject != string.Empty;
            populated = populated && TxtWhen != string.Empty;
            populated = populated && TxtBody != string.Empty;

            return populated;
        }

        public bool CallSendEmail()
        {
            string newLine = "\n\n";
            Singleton.EmailBody = "From: " + SelectedSalesperson.spName + newLine + 
                                  "Subject:" + TxtSubject + newLine + 
                                  "When: " + TxtWhen + newLine + 
                                  "Detail:" + TxtBody;
            return App.PortalFixManager.SendEmailAsync().Result;
        }
    }
}
