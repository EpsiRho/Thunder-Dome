using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Thunder_Dome_Pro.Classes;

namespace Thunder_Dome_Pro.ViewModels
{
    public class ProvidersViewModel
    {
        // UI notification functions
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<Flatrate> items = new ObservableCollection<Flatrate>();
        public ObservableCollection<Flatrate> Items
        {
            get { return items; }
            set
            {
                items = value;
                this.OnPropertyChanged("Items");
            }
        }
        public ProvidersViewModel() { }
    }
}
