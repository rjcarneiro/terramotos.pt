using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carneiro.Terramotos.Web.Data;
using Carneiro.Terramotos.Web.Extensions;
using Carneiro.Terramotos.Web.Models;
using Carneiro.Terramotos.Web.Models.Home;
using Carneiro.Terramotos.Web.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Carneiro.Terramotos.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly EarthQuakeDbContext _dbContext;

        public HomeController(EarthQuakeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var items = new List<EarthQuakeListItemViewModel>();

            // list ones
            foreach (string location in LocationUtil.All)
            {
                List<EarthQuakeItemViewModel> earthQuakes = await _dbContext.EarthQuakes
                .Where(t => t.Location.Code == location)
                .OrderByDescending(t => t.CreateDate)
                .Take(5)
                .Select(t => new EarthQuakeItemViewModel
                {
                    Id = t.Id,
                    Description = t.Obs,
                    Magnitude = t.Magnitud.ToMagnitude()
                })
                .ToListAsync();

                items.Add(new EarthQuakeListItemViewModel
                {
                    Title = location,
                    Items = earthQuakes
                });
            }

            // maps ones
            List<EarthQuakeViewModel> lastEarthQuakes = await _dbContext.EarthQuakes
                .OrderByDescending(t => t.CreateDate)
                .Take(30)
                .Select(t => new EarthQuakeViewModel
                {
                    Id = t.Id,
                    Description = t.Obs,
                    Latitude = t.Latitude,
                    Longitude = t.Longitude,
                    Magnitude = t.Magnitud.ToMagnitude()
                })
                .ToListAsync();


            return View(new HomeIndexViewModel
            {
                Maps = lastEarthQuakes,
                Items = items
            });
        }

        public IActionResult Privacy() => View();
    }
}