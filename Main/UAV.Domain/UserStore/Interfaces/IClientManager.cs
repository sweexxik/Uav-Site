using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAV.Domain.UserStore.Entities;

namespace UAV.Domain.UserStore.Interfaces
{
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
    }
}
