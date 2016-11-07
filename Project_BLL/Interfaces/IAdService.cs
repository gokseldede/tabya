using System.Collections.Generic;
using Project_BLL.ServiceModels;
using Project_Entity;

namespace Project_BLL.Interfaces
{
    public interface IAdService : IStandartService<AdDetailServiceModel>
    {
        //TODO: Workplace,land and building servis modellerini geriye dön

        List<WorkplaceServiceModel> GetWorkPlaces();
        List<LandServiceModel> GetLands();
        List<BuildingServiceModel> GetBuildings();
    }
}