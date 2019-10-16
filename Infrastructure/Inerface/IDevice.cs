using Infrastructure.Model;
using System.Collections.Generic;

namespace Infrastructure.Inerface
{
    public interface IDevice
    {
        IList<Device> GetAll();
    }
}
