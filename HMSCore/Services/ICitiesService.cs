using HMSCore.Models.Cities;
using System.Collections.Generic;

namespace HMSCore.Services
{
    public interface ICitiesService
    {
        IEnumerable<CitiesViewModel> GetCities(string countryId);
    }
}
