using HMSCore.Areas.Admin.Models.Countries;
using HMSCore.Areas.Admin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HMSCore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class CountriesController : Controller
    {
        private readonly ICountriesService countryService;

        public CountriesController(ICountriesService cService)
        {
            this.countryService = cService;
        }

        public IActionResult All([FromQuery] CountriesQueryModel query)
        {
            var countriesQuery = countryService.All(query);

            return this.View(countriesQuery);
        }

        public IActionResult Edit(string id)
        {
            var currentCountry = this.countryService.LoadCountry(id);

            return this.View(currentCountry);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCountryFormModel country)
        {
            if (!ModelState.IsValid)
            {
                return this.View(country);
            }

            await this.countryService.Edit(country);

            return this.RedirectToAction("All", "Countries");
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCountryFormModel country)
        {
            if (!ModelState.IsValid)
            {
                return this.View(country);
            }

            await this.countryService.Add(country);

            return this.RedirectToAction("All", "Countries");
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.countryService.Delete(id);

            return this.RedirectToAction("All", "Countries");
        }
    }
}