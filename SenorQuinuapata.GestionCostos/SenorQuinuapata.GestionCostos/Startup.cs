using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SenorQuinuapata.GestionCostos.Startup))]
namespace SenorQuinuapata.GestionCostos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
