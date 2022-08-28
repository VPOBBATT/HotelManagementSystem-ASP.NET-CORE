using HMSCore.Areas.Admin.Models.Company;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HMSCore.Areas.Admin.Services
{
    public interface ICompanyService
    {
        CompanyFormModel CompanyInfo();

        CompanyFormModel GetCountries(CompanyFormModel company);

        CompanyFormModel GetCities(CompanyFormModel company);

        Task Update(CompanyFormModel company);
    }
}