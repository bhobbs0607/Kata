using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ShoppingCart
{
    /// <summary>
    /// Interface to be used to query against to find a given item.
    /// </summary>
    public interface IItemFinder
    {
        Item FindItem(string sku);
    }
}
