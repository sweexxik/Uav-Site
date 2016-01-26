using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Main.BLL.Interfaces;
using Main.BLL.Services;
using Ninject;

namespace Main.WEB.Infrastructure
{
    class NinjectDependencuResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencuResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IUavService>().To<UavService>();
            kernel.Bind<IPayloadService>().To<PayloadService>();
            kernel.Bind<IGcuTypeService>().To<GcuTypeService>();
            kernel.Bind<IAdminService>().To<AdminService>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.Get(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}
