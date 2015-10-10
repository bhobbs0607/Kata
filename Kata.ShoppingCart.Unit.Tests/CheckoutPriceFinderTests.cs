using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Kata.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CheckoutPriceFinderTests
    {
        [TestMethod]
        public void ShouldRetrieveCorrectPriceForOneItem()
        {
            var priceFinder = new Mock<IPriceFinder>();
            var subject = new Checkout(new Mock<IDiscounter>().Object, priceFinder.Object);

            subject.Scan("A");

            priceFinder.Verify(v => v.PriceFor(It.IsAny<string>()));
        }

        [TestMethod]
        public void ShouldFindPriceForItemPassedIn()
        {
            var priceFinder = new Mock<IPriceFinder>();
            var item = "a";

            new Checkout(new Mock<IDiscounter>().Object, priceFinder.Object).Scan(item);

            priceFinder.Verify(v => v.PriceFor(item));
        }

        [TestMethod]
        public void ShouldRetrieveCorrectPriceForMultipleItems()
        {
            var priceFinder = new Mock<IPriceFinder>();
            var subject = new Checkout(new Mock<IDiscounter>().Object, priceFinder.Object);
            var items = "AB";

            subject.Scan(items);

            priceFinder.Verify(v => v.PriceFor(It.IsAny<string>()), Times.Exactly(items.Length));
        }
    }
}
