using System.Collections.Generic;
using Carneiro.Terramotos.Web.Utils;

namespace Carneiro.Terramotos.Web.Helpers
{
    public static class LocationHelper
    {
        public static Dictionary<string, string> Locations => new Dictionary<string, string>
        {
            { LocationUtil.Azores, "Açores" },
            { LocationUtil.Portugal, "Portugal" },
            { LocationUtil.World, "Mundo" }
        };
    }
}
