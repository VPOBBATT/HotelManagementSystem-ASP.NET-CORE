using HMSCore.Models.Guests;
using HMSCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HMSCore.Controllers
{
    [Authorize]
    public class GuestsController : Controller
    {
        private readonly IGuestsService guestService;

        public GuestsController(IGuestsService gService)
        {
            this.guestService = gService;
        }

        public async Task<IActionResult> Delete(string id)
        {
            await this.guestService.Delete(id);

            return this.RedirectToAction("All", "Guests");
        }

        public IActionResult Details(string id)
        {
            var currentClient = this.guestService.Details(id);

            return this.View(currentClient);
        }

        public IActionResult All([FromQuery] ListGuestsQueryModel query)
        {
            var guests = this.guestService.GetGuests(query);

            return this.View(guests);
        }

        public IActionResult Add()
        {
            var cityAndCountries = new AddCustomerFormModel
            {
                Countries = this.guestService.GetCountries(),
                Ranks = this.guestService.GetRanks()
            };

            foreach (var rank in cityAndCountries.Ranks)
            {
                if (rank.Text == "Regular")
                {
                    cityAndCountries.RankId = rank.Value;
                }
            }

            return this.View(cityAndCountries);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCustomerFormModel customer)
        {
            if (!ModelState.IsValid)
            {

                customer.Countries = this.guestService.GetCountries();
                customer.Ranks = this.guestService.GetRanks();

                return this.View(customer);
            }

            await this.guestService.Add(customer);

            return RedirectToAction("All", "Guests");
        }

        public IActionResult Edit(string id)
        {
            var guest = this.guestService.GetGuest(id);

            return this.View(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditGuestFormModel guest)
        {
            if (!ModelState.IsValid)
            {
                guest.Countries = this.guestService.GetCountries();
                guest.Ranks = this.guestService.GetRanks();

                return this.View(guest);
            }

            await this.guestService.Edit(guest);

            return this.RedirectToAction("All", "Guests");
        }

    }
}
