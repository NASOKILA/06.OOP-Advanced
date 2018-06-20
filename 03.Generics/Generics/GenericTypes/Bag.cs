    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericTypes
{
    //Pravim klasa da e Generic kato mu lsagame <T>
    public class Bag<T>
    {

        public Bag()
        {
            this.Items = new List<T>();
        }

        private List<T> Items { get; }


        public T GetEmenementAtIndex(int index) {
            
            T element = this.Items[index];
            return element;
        }

        public void AddItem(T item) {

            if(!this.Items.Contains(item))
                this.Items.Add(item);
        }

        public void RemoveItem(T item)
        {
            if (this.Items.Contains(item))
                this.Items.Remove(item);
        }

        public override string ToString()
        {
            return string.Join(", ", this.Items);
        }

    }
}
