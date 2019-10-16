using System;
using System.Collections.Generic;
using System.Text;

namespace Hozor.DomainClasses.Public
{
    public class CMvcActionInfo
    {
        public string Id => $"{ControllerId}:{Name}";

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string ControllerId { get; set; }
    }
}
