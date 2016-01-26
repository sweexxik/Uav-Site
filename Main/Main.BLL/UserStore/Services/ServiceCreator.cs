using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main.BLL.UserStore.Interface;
using UAV.Domain.UserStore.Repositories;

namespace Main.BLL.UserStore.Services
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUnitOfWork(connection));
        }
    }
}
