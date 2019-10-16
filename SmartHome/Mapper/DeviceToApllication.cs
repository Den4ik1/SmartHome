using Domain.Model;
using SmartHome.Models;

namespace SmartHome.Mapper
{
    public static class DeviceToApllication
    {
        public static DeviceAPI ConvertToAPI(this DomainDevice domainDevice)
        {
            return new DeviceAPI()
            {
                ID = domainDevice.ID,
                Type = domainDevice.Type,
                Condition = domainDevice.Condition,
                Value = domainDevice.Value,
                Information = domainDevice.Information
            };
        }
    }
}