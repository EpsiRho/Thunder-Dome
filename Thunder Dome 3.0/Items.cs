using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thunder_Dome_3._0
{
    public class Item
    {
        public string Name { get; set; }
        public int Progress { get; set; }
        public Item(string name)
        {
            Name = name;
            Progress = 0;
        }
        public Item()
        {
            Name = "NULL";
            Progress = 0;
        }


    }

    public class ItemsViewModel
    {
        private ObservableCollection<Item> itemsLeft = new ObservableCollection<Item>();
        public ObservableCollection<Item> ItemsLeft { get { return this.itemsLeft; } }
        private ObservableCollection<Item> itemsRight = new ObservableCollection<Item>();
        public ObservableCollection<Item> ItemsRight { get { return this.itemsRight; } }
        public void AddLeftItem(string name)
        {
            this.itemsLeft.Add(new Item(name));
        }
        public void AddLeftItem(Item item)
        {
            this.itemsLeft.Add(item);
        }
        public void RemoveLeftItem(Item item)
        {
            itemsLeft.Remove(item);
        }
        public void ChangeLeftItemWeight(Item item, int progress)
        {
            int i = itemsLeft.IndexOf(item);
            itemsLeft[i].Progress = progress;
        }
        public void AddRightItem(Item item)
        {
            this.itemsRight.Add(item);
        }
        public void RemoveRightItem(Item item)
        {
            itemsRight.Remove(item);
        }
        public void ClearLists(int i = 0)
        {
            if (i == 0)
            {
                itemsLeft.Clear();
                itemsRight.Clear();
            }
            else if(i == 1)
            {
                itemsLeft.Clear();
            }
            else
            {
                itemsRight.Clear();
            }
        }
    }
}
