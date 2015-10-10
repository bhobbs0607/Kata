using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.ShoppingCart
{
    public interface IDiscounter
    {
        int DiscountFor(string s);
    }
}
