using Domain.Model;
using Infrastructure.Model;

namespace DomainService.Mappers
{
    public static class DeviceToDomain
    {
        public static DomainDevice ConvertToDomain(this Device device)
        {
            return new DomainDevice()
            {
                ID = device.ID,
                Type = device.Type,
                Condition = device.Condition,
                Value = device.Value,
                Information = device.Information
            };
        }
    }
}
