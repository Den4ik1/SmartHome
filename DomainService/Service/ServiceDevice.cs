using System.Collections.Generic;
using System.Linq;
using Domain.Interface;
using Domain.Model;
using DomainService.Mappers;
using Infrastructure.Inerface;

namespace DomainService.Service
{
    public class ServiceDevice : IDomainDevice
    {
        private readonly IDevice _device;

        public ServiceDevice(IDevice device)
        {
            _device = device;
        }

        public IList<DomainDevice> GetAllDomain()
        {
            var rez = _device.GetAll();
            return rez.Select(_ => _.ConvertToDomain()).ToList();
        }
    }
}
