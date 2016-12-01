using System.Collections.Generic;
using Project_BLL.ServiceModels;

namespace Project_BLL.Interfaces
{
    public interface IWebSiteService
    {
        HomeViewModel GetMainPageData();
        List<SelectlistItem> GetCities();
        List<SelectlistItem> GetCounties(int cityId);
        List<SelectlistItem> GetProviences(int countyId);
        List<NewAdvertisement> GetAdvertisements(QueryServiceModel model);
        void AddToNewster(string email, string ipAddres);
    }
}
