using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using UAV.Domain.UserStore.EF;
using UAV.Domain.UserStore.Entities;
using UAV.Domain.UserStore.Identity;
using UAV.Domain.UserStore.Interfaces;

namespace UAV.Domain.UserStore.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationContext _db;
        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;
        private readonly IClientManager _clientManager;

        public IdentityUnitOfWork(string connectionString)
        {
            _db = new ApplicationContext(connectionString);
            _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db));
            _roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db));
            _clientManager = new ClientManager(_db);
        }

        public ApplicationUserManager UserManager => _userManager;

        public IClientManager ClientManager => _clientManager;

        public ApplicationRoleManager RoleManager => _roleManager;

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
      

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _userManager.Dispose();
                _roleManager.Dispose();
                _clientManager.Dispose();
            }
            _disposed = true;
        }
    }
}

