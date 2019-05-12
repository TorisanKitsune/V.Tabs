using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V.Tabs.Wpf.Utilities
{
    public class RegionAttribute : Attribute
    {
        public RegionType Region { get; private set; }

        public RegionAttribute(RegionType region) => Region = region;
    }
}
