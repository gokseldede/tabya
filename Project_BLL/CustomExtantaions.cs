﻿using System.Linq;
using Project_BLL.ServiceModels;
using Project_Entity;

namespace Project_BLL
{
    internal static class CustomExtantaions
    {
        public static Project ToProject(this ProjectServiceModel model)
        {
            Project project = new Project()
            {
                ID = model.Id,
                IsActive = model.IsActive,
                Vitrin = model.IsInVitrin,
                DeliveryDate = model.ProjectDeliveryDate,
                Description = model.Description,
                ExpertID = model.ExpertId,
                HouseN = model.FlatCount.ToString(),
                ImagePath = model.ThumbPath,
                Name = model.Name,
                PriceList = model.PriceList,
                ProjectA = model.ProjectArea.ToString("F2"),
                SSubName = model.ProjectLocation,
                SubName = model.ProjectFirm,
                Video = model.ProjectPromotionVideo,
                ProjectFiles = model.ProjectFileDetails.Select(x => new ProjectFile() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList()
            };

            return project;
        }

        public static ProjectServiceModel ToProjectServiceModel(this Project data)
        {
            var vm = new ProjectServiceModel()
            {
                Id = data.ID,
                IsActive = data.IsActive,
                ThumbPath = data.ImagePath,
                CreatedDateTime = data.CreatedDate,
                Name = data.Name,
                FlatCount = int.Parse(data.HouseN),
                ExpertId = data.ExpertID,
                IsInVitrin = data.Vitrin,
                ProjectArea = decimal.Parse(data.ProjectA),
                Description = data.Description,
                UpdatedDateTime = data.UpdatedDate,
                PriceList = data.PriceList,
                ProjectDeliveryDate = data.DeliveryDate,
                ProjectFileDetails = data.ProjectFiles.Select(x => new FileDetailServiceModel() { Id = x.Id, Extension = x.Extension, FileName = x.FileName }).ToList(),
                ProjectFirm = data.SubName,
                ProjectLocation = data.SSubName,
                ProjectPromotionVideo = data.Video
            };

            return vm;
        }
    }
}
