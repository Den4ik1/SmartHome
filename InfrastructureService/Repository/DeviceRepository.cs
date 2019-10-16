using Infrastructure.Inerface;
using Infrastructure.Model;
using InfrastructureService.Context;
using System.Collections.Generic;
using System.Linq;

namespace InfrastructureService.Repository
{
    public class DeviceRepository : IDevice
    {
        private readonly DeviceContext _context;

        public DeviceRepository(DeviceContext context)
        {
            _context = context;
        }

        public IList<Device> GetAll()
        {
            return _context.Device.ToList();
        }
    }
}
