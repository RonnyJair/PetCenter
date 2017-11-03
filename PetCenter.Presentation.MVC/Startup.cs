using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetCenter.Presentation.MVC.Startup))]
namespace PetCenter.Presentation.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
