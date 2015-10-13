using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ShoppingCart
{
    /// <summary>
    /// Object used as a place holder for items.
    /// </summary>
    public class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Sku { get; set; }
    }
}
