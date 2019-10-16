using Domain.Model;
using System.Collections.Generic;

namespace Domain.Interface
{
    public interface IDomainDevice
    {
        IList<DomainDevice> GetAllDomain();
    }
}