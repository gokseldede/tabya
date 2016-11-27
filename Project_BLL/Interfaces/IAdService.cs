using System.Collections.Generic;
using Project_BLL.ServiceModels;

namespace Project_BLL.Interfaces
{
    public interface IAdService : IStandartService<AdDetailServiceModel>
    {
        List<WorkplaceServiceModel> GetWorkPlaces();
        List<LandServiceModel> GetLands();
        List<BuildingServiceModel> GetBuildings();
    }
}