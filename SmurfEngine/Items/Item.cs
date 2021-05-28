using SmurfEngine.Attributes;
using SmurfEngine.Characters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Items
{
    public class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            this.Name = name;
        }
    }
}
