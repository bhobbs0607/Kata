using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.ShoppingCart.Unit.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void EmptyCheckoutHasZeroTotal()
        {
            var discounter = new Mock<IDiscounter>();
            Assert.That(0, Is.EqualTo(new Checkout(discounter.Object, new Mock<IPriceFinder>().Object).Total()));
        }

        [TestMethod]
        public void ScanningShouldGetDiscounts()
        {
            var discounter = new Mock<IDiscounter>();
            new Checkout(discounter.Object, new Mock<IPriceFinder>().Object).Scan("");
            discounter.Verify(v => v.DiscountFor(It.IsAny<string>()), Times.Never());
        }

        [TestMethod]
        public void ScanningShouldGetDiscountForScannedItem()
        {
            var discounter = new Mock<IDiscounter>();
            var item = "a";
            new Checkout(discounter.Object, new Mock<IPriceFinder>().Object).Scan(item);
            discounter.Verify(v => v.DiscountFor(item));
        }

        [TestMethod]
        public void GettingTotalWithDiscountAppliesDiscount()
        {
            var discounter = new Mock<IDiscounter>();
            discounter.Setup(v => v.DiscountFor(It.IsAny<string>())).Returns(20);
            var checkout = new Checkout(discounter.Object, new Mock<IPriceFinder>().Object);
            checkout.Scan("a");
            Assert.That(checkout.Total(), Is.EqualTo(-20));
        }

        [TestMethod]
        public void ScanningMultipleItemsGetsDiscountForEachOne()
        {
            var discounter = new Mock<IDiscounter>();
            var item = "ab";
            new Checkout(discounter.Object, new Mock<IPriceFinder>().Object).Scan(item);
            discounter.Verify(v => v.DiscountFor(It.IsAny<string>()), Times.Exactly(item.Length));
        }
    }
}
