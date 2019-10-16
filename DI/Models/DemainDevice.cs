﻿using Domain.Interface;
using DomainService.Service;
using Unity;
using Unity.Lifetime;

namespace DI.Models
{
    public class DemainDevice : IModels
    {
        public void Registre(IUnityContainer container)
        {
            container.RegisterType<IDomainDevice, ServiceDevice>(new HierarchicalLifetimeManager());
        }

    }
}
