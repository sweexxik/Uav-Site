using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.BLL.UserStore.Interface;
using Main.BLL.UserStore.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Main.WEB.Startup))]
namespace Main.WEB
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("UserStore");
        }
    }
}

