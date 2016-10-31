using Project_BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BLL.Interfaces
{
    public interface IWebSiteService
    {
        HomeViewModel GetMainPageData();
        List<SelectlistItem> GetCities();
        List<SelectlistItem> GetCounties(int CityId);
    }
}
