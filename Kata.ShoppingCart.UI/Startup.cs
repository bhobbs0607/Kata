using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kata.ShoppingCart.UI.Startup))]
namespace Kata.ShoppingCart.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
