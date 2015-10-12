using System;
using System.Collections.Generic;
using System.Linq;

namespace Kata.ShoppingCart
{
    public class Checkout
    {
        private List<Item> _items;
        private readonly List<SpecialPrice> _specials;
        private readonly IItemFinder _itemFinder;
        
        public Checkout(IItemFinder itemFinder, List<SpecialPrice> specials)
        {
            // guard clauses here to catch any issues early on if a null object is passed into this class
            if (itemFinder == null)
                throw new ArgumentNullException("itemFinder");
            if (specials == null)
                throw new ArgumentNullException("specials");

            _itemFinder = itemFinder;
            _specials = specials;

            _items = new List<Item>();
        }

        /// <summary>
        /// Clear the list of items. Done to reset for a new items to be scanned for a new checkout
        /// </summary>
        public void ClearItems()
        {
            _items.Clear();
        }

        /// <summary>
        /// Gets the total amount due for all of the scan items.
        /// </summary>
        /// <returns></returns>
        public decimal Total()
        {
            decimal total = 0;
            // Grouping items to be able to determine if they qualify for the special price.
            var groupedItems = _items.GroupBy(i => i.Name);

            foreach (var item in groupedItems) 
            {
                // Look to see if there are any specials for the given item. If there are calucate the special price + the regular price of
                // any of the items above the special amount.
                var special = _specials.FirstOrDefault(s => s.ItemName == item.Key);

                if (special != null)
                {
                    var itemCount = item.Count();
                    var discountCount = itemCount / special.ItemCount; // Doing this to see if there are enough items for mutli discounts -> IE 6s when the special is for 3, etc
                    var leftOverCount = itemCount % special.ItemCount; // Find out how many items are left that don't get the discount -> IE 4 when the special is 3, etc

                    // Add the cost of the items * the amount of the items + the special price.
                    total += discountCount * special.TotalAmount;
                    total += leftOverCount * item.First().Price;
                }
                else
                {
                    // Not a special item, so just sum up the price and add it to the total.
                    total += item.Sum(i => i.Price);
                }
            }

            return total;
        }

        /// <summary>
        /// Scan an item, and adds it to the list of items that have been scanned.
        /// </summary>
        /// <param name="sku"></param>
        public void Scan(string sku)
        {
            // Guard clause to make sure we receive input.
            if (string.IsNullOrWhiteSpace(sku))
                throw new ArgumentNullException("sku", "sku cannot be null, empty, or whitespace");

            // Get the item information by looking up the SKU.
            var item = _itemFinder.FindItem(sku);
            _items.Add(item);
        }
    }
}
