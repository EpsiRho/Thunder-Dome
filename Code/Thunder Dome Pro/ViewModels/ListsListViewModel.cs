using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Thunder_Dome_Pro.ViewModels
{
    public class ListsListViewModel
    {
        // UI notification functions
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<string> lists = new ObservableCollection<string>();
        public ObservableCollection<string> Lists
        {
            get { return lists; }
            set
            {
                lists = value;
                this.OnPropertyChanged("Lists");
            }
        }
        public ListsListViewModel() { }
    }
}
