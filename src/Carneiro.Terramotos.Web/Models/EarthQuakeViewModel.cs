using System.Collections.Generic;

namespace Carneiro.Terramotos.Web.Models
{
    public class EarthQuakeListItemViewModel
    {
        public string Title { get; set; }
        public List<EarthQuakeItemViewModel> Items { get; internal set; }
    }

    public class EarthQuakeItemViewModel
    {
        public long Id { get; internal set; }
        public string Description { get; internal set; }
        public string Magnitude { get; internal set; }
    }

    public class EarthQuakeViewModel : EarthQuakeItemViewModel
    {
        public decimal Latitude { get; internal set; }
        public decimal Longitude { get; internal set; }
    }
}
