using System.Collections.Generic;

namespace Carneiro.Terramotos.Web.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<EarthQuakeListItemViewModel> Items { get; internal set; }
        public List<EarthQuakeViewModel> Maps { get; internal set; }
    }
}