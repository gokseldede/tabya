﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BLL.Interfaces;
using Project_BLL.ViewModels;
using Project_DAL;
using Project_Entity;

namespace Project_BLL.Implementation
{
    public class OptionsService : IOptionService
    {
        private readonly IRepository<Kimden> _kimdensRepository;
        private readonly IRepository<Status> _statussRepository;
        private readonly IRepository<Isinma> _isinmasRepository;
        private readonly IRepository<Kredi> _kredisRepository;
        private readonly IRepository<Kurlar> _kurlarsRepository;
        private readonly IRepository<Properties> _propertiesRepository;
        private readonly IRepository<SocialApps> _socialAppsRepository;
        private readonly IRepository<Securitys> _securityiesRepository;
        private readonly IRepository<Expert> _expertRepository;
        private readonly IRepository<Il> _ilRepository;
        private readonly IRepository<Ilce> _ilceRepository;
        private readonly IRepository<Semt> _semtRepository;

        public OptionsService()
        {
            _socialAppsRepository = new EfRepositoryForEntityBase<SocialApps>();
            _statussRepository = new EfRepositoryForEntityBase<Status>();
            _isinmasRepository = new EfRepositoryForEntityBase<Isinma>();
            _kimdensRepository = new EfRepositoryForEntityBase<Kimden>();
            _kredisRepository = new EfRepositoryForEntityBase<Kredi>();
            _kurlarsRepository = new EfRepositoryForEntityBase<Kurlar>();
            _propertiesRepository = new EfRepositoryForEntityBase<Properties>();
            _securityiesRepository = new EfRepositoryForEntityBase<Securitys>();
            _expertRepository = new EfRepositoryForEntityBase<Expert>();
            _ilRepository = new EfRepositoryForEntityBase<Il>();
            _ilceRepository = new EfRepositoryForEntityBase<Ilce>();
            _semtRepository=new EfRepositoryForEntityBase<Semt>();
        }

        public List<SelectlistItem> GetExpertList()
        {
            return _expertRepository.Table.Where(x => x.IsActive).Select(x => new SelectlistItem { Id = x.ID, Value = x.Name }).ToList();
        }

        public List<SelectlistItem> GetKimdenList()
        {
            return _kimdensRepository.Table.Where(x => x.IsActive)
                 .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                 .ToList();
        }

        public List<SelectlistItem> GetStatuslist()
        {
            return _statussRepository.Table.Where(x => x.IsActive)
                         .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                         .ToList();
        }

        public List<SelectlistItem> GetIsinmaList()
        {
            return _isinmasRepository.Table.Where(x => x.IsActive)
                        .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                        .ToList();
        }

        public List<SelectlistItem> GetKrediList()
        {
            return _kredisRepository.Table.Where(x => x.IsActive)
                .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                .ToList();
        }

        public List<SelectlistItem> GetKurlarList()
        {
            return _kurlarsRepository.Table.Where(x => x.IsActive)
                .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                .ToList();
        }

        public List<SelectlistItem> GetPropertiesList()
        {
            return _propertiesRepository.Table.Where(x => x.IsActive)
                        .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                        .ToList();
        }

        public List<SelectlistItem> GetSocialAppsList()
        {
            return _socialAppsRepository.Table.Where(x => x.IsActive)
                .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                .ToList();
        }

        public List<SelectlistItem> GetSecurityList()
        {
            return _securityiesRepository.Table.Where(x => x.IsActive)
                        .Select(y => new SelectlistItem { Id = y.ID, Value = y.Name })
                        .ToList();
        }

        public List<SelectlistItem> GetIllerList()
        {
            return _ilRepository.Table.Where(x => x.IsActive)
                        .Select(y => new SelectlistItem { Id = y.ID, Value = y.Ad })
                        .ToList();
        }

        public List<SelectlistItem> GetIlcelerList(int ilId)
        {
            return _ilceRepository.Table.Where(x => x.IsActive && x.IlID == ilId)
                         .Select(y => new SelectlistItem { Id = y.ID, Value = y.Ad })
                         .ToList();
        }

        public List<SelectlistItem> GetSemtList(int ilceId)
        {
            return _semtRepository.Table.Where(x => x.IsActive & x.IlceID==ilceId)
                        .Select(y => new SelectlistItem { Id = y.ID, Value = y.Ad })
                        .ToList();
        }
    }
}
