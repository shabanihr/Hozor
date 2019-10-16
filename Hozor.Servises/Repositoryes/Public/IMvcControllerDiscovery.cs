using System;
using System.Collections.Generic;
using System.Text;
using Hozor.DomainClasses.Public;

namespace Hozor.Servises.Repositoryes.Public
{
    public interface IMvcControllerDiscovery
    {
        IEnumerable<CMvcControllerInfo> GetControllers();
    }
}
