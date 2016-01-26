using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAV.Domain.UserStore.EF;
using UAV.Domain.UserStore.Entities;
using UAV.Domain.UserStore.Interfaces;

namespace UAV.Domain.UserStore.Repositories
{
    class ClientManager : IClientManager
    {
        public ApplicationContext Database { get; set; }

        public ClientManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
    }
}
