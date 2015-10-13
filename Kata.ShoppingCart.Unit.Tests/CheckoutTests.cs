using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;

namespace Kata.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        
        
        public CheckoutTests()
        {
            

        }

        [TestMethod]
        public void CheckoutWithZeroItems()
        {
            Item _itemA = new Item() { Name = "A", Price = 50, Sku = "A"};
            Item _itemB = new Item() { Name = "B", Price = 30, Sku = "B"};
            Item _itemC = new Item() { Name = "C", Price = 20, Sku = "C"};
            Item _itemD = new Item() { Name = "D", Price = 15, Sku = "D"};

            ItemFinder _itemFinder = new ItemFinder();
            List<SpecialPrice> _specials = new List<SpecialPrice>();
            
            _itemFinder.Items.Add(_itemA);
            _itemFinder.Items.Add(_itemB);
            _itemFinder.Items.Add(_itemC);
            _itemFinder.Items.Add(_itemD);

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            var _checkout = new Checkout(_itemFinder, _specials);

            _checkout.ClearItems();
            Assert.AreEqual(0, _checkout.Total());
        }

        [TestMethod]
        public void CheckoutWithOneItem()
        {
            Item _itemA = new Item() { Name = "A", Price = 50, Sku = "A" };
            Item _itemB = new Item() { Name = "B", Price = 30, Sku = "B" };
            Item _itemC = new Item() { Name = "C", Price = 20, Sku = "C" };
            Item _itemD = new Item() { Name = "D", Price = 15, Sku = "D" };

            ItemFinder _itemFinder = new ItemFinder();
            List<SpecialPrice> _specials = new List<SpecialPrice>();

            _itemFinder.Items.Add(_itemA);
            _itemFinder.Items.Add(_itemB);
            _itemFinder.Items.Add(_itemC);
            _itemFinder.Items.Add(_itemD);

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            var _checkout = new Checkout(_itemFinder, _specials);

            _checkout.ClearItems();
            _checkout.Scan("A");

            Assert.AreEqual(50, _checkout.Total());
        }

        [TestMethod]
        public void CheckoutWithSpecialItems()
        {
            Item _itemA = new Item() { Name = "A", Price = 50, Sku = "A" };
            Item _itemB = new Item() { Name = "B", Price = 30, Sku = "B" };
            Item _itemC = new Item() { Name = "C", Price = 20, Sku = "C" };
            Item _itemD = new Item() { Name = "D", Price = 15, Sku = "D" };

            ItemFinder _itemFinder = new ItemFinder();
            List<SpecialPrice> _specials = new List<SpecialPrice>();

            _itemFinder.Items.Add(_itemA);
            _itemFinder.Items.Add(_itemB);
            _itemFinder.Items.Add(_itemC);
            _itemFinder.Items.Add(_itemD);

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            var _checkout = new Checkout(_itemFinder, _specials);

            _checkout.ClearItems();
            for (int i = 1; i <= 3; i++)
            {
                _checkout.Scan("A");
            }

            Assert.AreEqual(130, _checkout.Total());
        }

        [TestMethod]
        public void CheckoutWithOddNumberOfSpecialItems()
        {
            Item _itemA = new Item() { Name = "A", Price = 50, Sku = "A" };
            Item _itemB = new Item() { Name = "B", Price = 30, Sku = "B" };
            Item _itemC = new Item() { Name = "C", Price = 20, Sku = "C" };
            Item _itemD = new Item() { Name = "D", Price = 15, Sku = "D" };

            ItemFinder _itemFinder = new ItemFinder();
            List<SpecialPrice> _specials = new List<SpecialPrice>();

            _itemFinder.Items.Add(_itemA);
            _itemFinder.Items.Add(_itemB);
            _itemFinder.Items.Add(_itemC);
            _itemFinder.Items.Add(_itemD);

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            var _checkout = new Checkout(_itemFinder, _specials);

            _checkout.ClearItems();
            for (int i = 1; i <= 4; i++)
            {
                _checkout.Scan("A");
            }

            Assert.AreEqual(180, _checkout.Total());
        }

        [TestMethod]
        public void CheckoutWithMultipleItems()
        {
            Item _itemA = new Item() { Name = "A", Price = 50, Sku = "A" };
            Item _itemB = new Item() { Name = "B", Price = 30, Sku = "B" };
            Item _itemC = new Item() { Name = "C", Price = 20, Sku = "C" };
            Item _itemD = new Item() { Name = "D", Price = 15, Sku = "D" };

            ItemFinder _itemFinder = new ItemFinder();
            List<SpecialPrice> _specials = new List<SpecialPrice>();

            _itemFinder.Items.Add(_itemA);
            _itemFinder.Items.Add(_itemB);
            _itemFinder.Items.Add(_itemC);
            _itemFinder.Items.Add(_itemD);

            _specials.Add(new SpecialPrice() { ItemName = "A", ItemCount = 3, TotalAmount = 130 });
            _specials.Add(new SpecialPrice() { ItemName = "B", ItemCount = 2, TotalAmount = 45 });

            var _checkout = new Checkout(_itemFinder, _specials);

            _checkout.ClearItems();
            for (int i = 1; i <= 3; i++)
            {
                _checkout.Scan("A");
            }
            _checkout.Scan("B");
            _checkout.Scan("C");

            Assert.AreEqual(180, _checkout.Total());
        }
    }
}
