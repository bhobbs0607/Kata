using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ShoppingCart
{
    /// <summary>
    /// Object used to hold information about special pricing.
    /// </summary>
    public class SpecialPrice
    {
        public string ItemName {get;set;}
        public int ItemCount { get; set; }
        public int TotalAmount{ get; set; }
    }
}
