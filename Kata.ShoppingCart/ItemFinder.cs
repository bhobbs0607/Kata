using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ShoppingCart
{
    public class ItemFinder : IItemFinder
    {
        public List<Item> Items { get; set; }
        
        public ItemFinder()
        {
            Items = new List<Item>();
        }
        public Item FindItem(string sku)
        {
            return Items.FirstOrDefault(i => i.Name == sku);
        }
    }
}
