using System;
using System.Collections.Generic;
using System.Text;

namespace Hozor.DomainClasses.Public
{
    public class CMvcControllerInfo
    {
        public string Id => $"{AreaName}:{Name}";

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string AreaName { get; set; }

        public IEnumerable<CMvcActionInfo> Actions { get; set; }
    }
}
