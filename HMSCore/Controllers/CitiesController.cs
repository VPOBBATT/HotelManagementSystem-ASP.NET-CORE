﻿using HMSCore.Models.Cities;
using HMSCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HMSCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICitiesService cityService;

        public CitiesController(ICitiesService cService)
        {
            this.cityService = cService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CitiesViewModel>> Cities(string countryId)
        {
            return cityService.GetCities(countryId).ToList();
        }
    }
}