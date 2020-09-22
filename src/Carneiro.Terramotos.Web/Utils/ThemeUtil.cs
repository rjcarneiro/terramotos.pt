using System.Collections.Generic;
using System.Linq;
using Carneiro.Terramotos.Web.Options;
using Microsoft.Extensions.Options;

namespace Carneiro.Terramotos.Web.Utils
{
    public class ThemeUtil
    {
        public List<ThemeItemOptions> Themes { get; }

        public ThemeUtil(IOptions<ThemeOptions> options)
        {
            Themes = options.Value.Themes;
        }

        public Dictionary<string, ThemeItemOptions> ThemesIntoDictionary => Themes.ToDictionary(t => t.Code, t => t);
    }
}