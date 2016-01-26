using System;
using System.Threading.Tasks;
using UAV.Domain.UserStore.Identity;

namespace UAV.Domain.UserStore.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
