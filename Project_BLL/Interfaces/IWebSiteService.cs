using Project_BLL.ViewModels;
using System.Collections.Generic;

namespace Project_BLL.Interfaces
{
    public interface IWebSiteService
    {
        HomeViewModel GetMainPageData();
        List<SelectlistItem> GetCities();
        List<SelectlistItem> GetCounties(int cityId);
    }
}
