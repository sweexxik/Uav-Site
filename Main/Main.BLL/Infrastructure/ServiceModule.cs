using Ninject.Modules;
using UAV.Domain.Interfaces;
using UAV.Domain.Repositories;

namespace Main.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string _connectionString;

        public ServiceModule(string connection)
        {
            _connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<EfUnitOfWork>().WithConstructorArgument(_connectionString);
        }
    }
}
