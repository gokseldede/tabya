﻿using Project_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BLL.ViewModels;
using Project_Entity;
using Project_DAL;

namespace Project_BLL.Implementation
{
    public class WebSiteService : IWebSiteService
    {
        private readonly IStandartService<Il> _ilService;
        private readonly IStandartService<Ilce> _ilcelerService;

        public WebSiteService()
        {
            _ilcelerService = new StandartService<Ilce>(new EfRepository<Ilce>());
            _ilService = new StandartService<Il>(new EfRepository<Il>());
        }
        public List<SelectlistItem> GetCities()
        {
            throw new NotImplementedException();
        }

        public List<SelectlistItem> GetCounties(int CityId)
        {
            return _ilcelerService.Get(x => x.IlID == CityId).Select(x => new SelectlistItem() { Id = x.ID, Value = x.Ad }).ToList();
        }

        public HomeViewModel GetMainPageData()
        {
            return new HomeViewModel()
            {

                Cities = _ilService.GetAll().Select(x => new SelectlistItem() { Id = x.ID, Value = x.Ad }).ToList(),
                Projects = new List<NewProject>()
                {
                    new NewProject()
                    {
                        Id=1,
                        Name="IKON",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="DUMANKAYA"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="METROPOL ISTANBUL",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="MERIDIAN ISTANBU",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="MERIDIAN ISTANBU",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                     new NewProject()
                    {
                        Id=1,
                        Name="IKON",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="DUMANKAYA"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="METROPOL ISTANBUL",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="MERIDIAN ISTANBU",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="MERIDIAN ISTANBU",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    },
                    new NewProject()
                    {

                        Id=1,
                        Name="MERIDIAN ISTANBU",
                        Address="Ataşehir",
                        Photo="Content/img/proje-img1.jpg",
                        Company="VARYAP"
                    }

                },
                Advertisements = new List<NewAdvertisement>()
                {
                    new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514.400M,
                        SquareMetre=250,
                        Status="SATILIK"
                    },
                     new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514,
                        SquareMetre=250,
                        Status="KİRALIK"
                    },
                      new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514,
                        SquareMetre=250,
                        Status="SATILIK"
                    },
                     new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514,
                        SquareMetre=250,
                        Status="KİRALIK"
                    },
                      new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514,
                        SquareMetre=250,
                        Status="SATILIK"
                    },
                     new NewAdvertisement()
                    {
                        Id=1,
                        Address="Kadıköy, İstanbul",
                        Photo="Content/img/ev1.jpg",
                        Currency="TL",
                        Price=514,
                        SquareMetre=250,
                        Status="KİRALIK"
                    }
                }
            };

        }
        
    }
}