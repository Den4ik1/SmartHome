using Infrastructure.Inerface;
using InfrastructureService.Context;
using InfrastructureService.Repository;
using Microsoft.EntityFrameworkCore;

using System.Configuration;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace DI.Models
{
    public class InfrastructureDevice : IModels
    {
        public void Registre(IUnityContainer container)
        {
            container.RegisterType<IDevice, DeviceRepository>(new HierarchicalLifetimeManager());

            var optionsBuilder = new DbContextOptionsBuilder<DeviceContext>();

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DeviceContext"].ConnectionString);
            using (var context = new DeviceContext(optionsBuilder.Options)) context.Database.EnsureCreated();
            container.RegisterType<DeviceContext>(new HierarchicalLifetimeManager(), new InjectionConstructor(optionsBuilder.Options));
        }

    }
}
