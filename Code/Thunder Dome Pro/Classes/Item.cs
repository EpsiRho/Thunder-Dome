using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace Thunder_Dome_Pro.Classes
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name { get;set; }

        public int Id { get; set; }

        public string PosterLink { get; set; }

        [JsonIgnore]
        private string holdStatus { get; set; }
        public string HoldStatus
        {
            get { return holdStatus; }
            set
            {
                if (value != holdStatus)
                {
                    holdStatus = value;
                    this.OnPropertyChanged("HoldStatus");
                }
            }
        }


        [JsonIgnore]
        private int shield;
        [JsonIgnore]
        public int Shield
        {
            get { return shield; }
            set
            {
                if (value != shield)
                {
                    shield = value;
                    this.OnPropertyChanged("Shield");
                }
            }
        }

        [JsonIgnore]
        private SolidColorBrush isHeld;
        [JsonIgnore]
        public SolidColorBrush IsHeld
        {
            get { return isHeld; }
            set
            {
                if (value != isHeld)
                {
                    isHeld = value;
                    this.OnPropertyChanged("IsHeld");
                }
            }
        }

        [JsonIgnore]
        private Visibility showElim;
        [JsonIgnore]
        public Visibility ShowElim
        {
            get { return showElim; }
            set
            {
                if (value != showElim)
                {
                    showElim = value;
                    this.OnPropertyChanged("ShowElim");
                }
            }
        }

        [JsonIgnore]
        private Visibility showSel;
        [JsonIgnore]
        public Visibility ShowSel
        {
            get { return showSel; }
            set
            {
                if (value != showSel)
                {
                    showSel = value;
                    this.OnPropertyChanged("ShowSel");
                }
            }
        }

        [JsonIgnore]
        public bool needsClean;

        public Item()
        {

        }
        public Item(Item i)
        {
            this.Name = i.Name;
            this.Id = i.Id;
            this.isHeld = i.IsHeld;
            this.holdStatus = i.HoldStatus;
            this.PosterLink = i.PosterLink;
            this.Shield = i.Shield;
            this.ShowElim = Visibility.Collapsed;
            this.ShowSel = Visibility.Collapsed;
        }
    }
}
