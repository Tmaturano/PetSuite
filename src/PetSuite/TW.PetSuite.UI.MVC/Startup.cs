using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TW.PetSuite.UI.MVC.Startup))]
namespace TW.PetSuite.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
