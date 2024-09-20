using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_4_Dedok
{
    public class Backpack
    {
        public string Color { get; set; }
        public string Manufacturer { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }

        private Item[] contents;
        private int itemCount; 

        public event EventHandler<ItemEventArgs> ItemAdded;
        public event EventHandler<ItemEventArgs> ItemRemoved;

        public Backpack(string color, string manufacturer, double weight, double volume, int capacity)
        {
            Color = color;
            Manufacturer = manufacturer;
            Weight = weight;
            Volume = volume;
            contents = new Item[capacity];
            itemCount = 0;
        }
        public void AddItem(Item item)
        {
            if (itemCount >= contents.Length)
            {
                Console.WriteLine("Рюкзак переповнений!");
                return;
            }

            contents[itemCount] = item;
            itemCount++;
            OnItemAdded(new ItemEventArgs(item));
        }
        public void RemoveItem(Item item)
        {
            int index = Array.IndexOf(contents, item);
            if (index >= 0)
            {
                for (int i = index; i < itemCount - 1; i++)
                {
                    contents[i] = contents[i + 1];
                }
                contents[itemCount - 1] = null;
                itemCount--;
                OnItemRemoved(new ItemEventArgs(item));
            }
        }
        protected virtual void OnItemAdded(ItemEventArgs e)
        {
            ItemAdded?.Invoke(this, e);
        }
        protected virtual void OnItemRemoved(ItemEventArgs e)
        {
            ItemRemoved?.Invoke(this, e);
        }
        public Item[] GetContents()
        {
            Item[] currentContents = new Item[itemCount];
            Array.Copy(contents, currentContents, itemCount);
            return currentContents;
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }

        public override string ToString()
        {
            return $"{Name} (Volume: {Volume}L)";
        }
    }
    public class ItemEventArgs : EventArgs
    {
        public Item Item { get; private set; }

        public ItemEventArgs(Item item)
        {
            Item = item;
        }
    }
    public static class BackpackExtensions
    {
        public static bool CanAddItem(this Backpack backpack, Item item)
        {
            double usedVolume = 0;
            foreach (var i in backpack.GetContents())
            {
                usedVolume += i.Volume;
            }

            return usedVolume + item.Volume <= backpack.Volume;
        }
    }
}