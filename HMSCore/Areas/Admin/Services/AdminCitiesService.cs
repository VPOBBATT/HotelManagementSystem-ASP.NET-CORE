using DataLayer;
using DataLayer.Models;
using HMSCore.Areas.Admin.Models.Cities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HMSCore.Areas.Admin.Services
{
    public class AdminCitiesService : IAdminCitiesService
    {
        private readonly HotelManagementDbContext db;

        public AdminCitiesService(HotelManagementDbContext dBase)
        {
            this.db = dBase;
        }

        public async Task Add(AddCityFormModel city)
        {
            var newCity = new City
            {
                CountryId = city.CountryId,
                Name = city.Name,
                PostalCode = city.PostalCode
            };

            await this.db.Cities.AddAsync(newCity);
            await this.db.SaveChangesAsync();
        }

        public CitiesQueryModel All(CitiesQueryModel query)
        {
            var citiesQueryDb = this.db
                .Cities
                .Where(c => c.Deleted == false)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                citiesQueryDb = citiesQueryDb
                               .Where(c => c.Name.ToLower().Contains(query.Search.ToLower()) ||
                               c.Country.Name.ToLower().Contains(query.Search.ToLower()));
            }

            var tPages = (int)Math.Ceiling((double)citiesQueryDb.Count() / query.ItemsPerPage);

            if (query.CurrentPage > tPages)
            {
                query.CurrentPage = tPages;
            }

            if (query.CurrentPage <= 0)
            {
                query.CurrentPage = 1;
            }

            var allCities = citiesQueryDb
                .OrderBy(c => c.Name)
                .Skip((query.CurrentPage - 1) * query.ItemsPerPage)
                .Take(query.ItemsPerPage)
                .Select(c => new CitiesViewModel
                {
                    Country = c.Country.Name,
                    Name = c.Name,
                    Id = c.Id
                })
                .ToList();

            var cQueryModel = new CitiesQueryModel
            {
                Cities = allCities,
                CurrentPage = query.CurrentPage,
                NextPage = query.NextPage,
                PreviousPage = query.PreviousPage,
                Search = query.Search,
                TotalPages = tPages
            };

            return cQueryModel;
        }

        public async Task Edit(EditCityFormModel city)
        {
            var curCity = this.db
                .Cities
                .FirstOrDefault(c => c.Id == city.Id);

            curCity.Name = city.Name;
            curCity.PostalCode = city.PostalCode;

            this.db.Update(curCity);
            await this.db.SaveChangesAsync();
        }

        public bool IsCityExistForEdit(string name, string id)
        {
            return this.db
                .Cities
                .Where(c => c.Id != id)
                .Any(c => c.Deleted == false && c.Name == name);
        }

        public bool IsCityExistForAdd(string name)
        {
            return this.db
                .Cities
                .Any(c => c.Deleted == false && c.Name == name);
        }

        public AddCityFormModel LoadCountries()
        {
            var allCountries = this.db
                .Countries
                .Where(c => c.Deleted == false)
                .Select(c => new SelectListItem
                {
                    Value = c.Id,
                    Text = c.Name
                })
                .ToList();

            var cityFormModel = new AddCityFormModel
            {
                Countries = allCountries
            };

            return cityFormModel;
        }

        public EditCityFormModel LoadCity(string id)
        {
            return this.db
                .Cities
                .Where(c => c.Id == id)
                .Select(c => new EditCityFormModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    PostalCode = c.PostalCode
                })
                .FirstOrDefault();
        }

        public async Task Delete(string id)
        {
            var city = this.db
                .Cities
                .Where(c => c.Id == id)
                .FirstOrDefault();

            city.Deleted = true;

            this.db.Cities.Update(city);
            await this.db.SaveChangesAsync();
        }
    }
}