using Project_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project_UI.Areas.Admin.Controllers
{

    public class BaseController : Controller
    {
        public ProjectContext Database;
        public ProjectContext db = new ProjectContext();

        public BaseController()
        {
            Database = new ProjectContext();
        }

        #region Void tanımlama
        //Uzmanı projeye dahil etmek için bilgileri çekiliyor.
        public void GetExpert()
        {
            ViewData["Expert"] = Database.Experts.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetExpert(int ID)
        {
            ViewData["Expert"] = Database.Experts.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetSite()
        {
            ViewData["Site"] = Database.Site.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetSite(int ID)
        {
            ViewData["Site"] = Database.Site.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetIsınma()
        {
            ViewData["Isınma"] = Database.Isınmalar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
            });
        }
        public void GetIsınma(int ID)
        {
            ViewData["Isınma"] = Database.Isınmalar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetKimden()
        {
            ViewData["Kimden"] = Database.Kimden.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
            });
        }
        public void GetKimden(int ID)
        {
            ViewData["Kimden"] = Database.Kimden.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetStatus()
        {
            ViewData["Status"] = Database.Statues.Where(x => x.IsDelete == false).Select(x => new SelectListItem()
            {
                Text = x.Name.ToUpper(),
                Value = x.ID.ToString()
            });
        }
        public void GetStatus(int ID)
        {
            ViewData["Status"] = Database.Statues.Where(x => x.IsDelete == false).Select(x => new SelectListItem()
            {
                Text = x.Name.ToUpper(),
                Value = x.ID.ToString(),
                Selected = x.ID == ID
            });
        }
        public void GetProperties()
        {
            var _tags = Database.Propertiesis.Where(x => x.IsDelete == false);
            List<SelectListItem> _tag = Database.Propertiesis.Select(x => new SelectListItem()
            {
                //Value = x.ID.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            ViewBag.tags = _tag;

            // ViewBag.tags = new MultiSelectList(_tags, "ID", "Name");

        }
        public void GetSocialApps()
        {
            var _socials = Database.SocialApps.Where(x => x.IsDelete == false);
            List<SelectListItem> _social = Database.SocialApps.Select(x => new SelectListItem()
            {
                // Value = x.ID.ToString(),
                Text = x.Name.ToString()

            }).ToList();

            ViewBag.socials = _social;

        }
        public void GetSecurity()
        {
            var _securitys = Database.Security.Where(x => x.IsDelete == false);
            List<SelectListItem> _security = Database.Security.Select(x => new SelectListItem()
            {
                // Value = x.ID.ToString(),
                Text = x.Name.ToString()
            }).ToList();

            ViewBag.securitys = _security;

        }
        public void GetKredi()
        {
            ViewData["Kredi"] = Database.Krediler.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetKredi(int ID)
        {
            ViewData["Kredi"] = Database.Krediler.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetKullanım()
        {
            ViewData["Kullanım"] = Database.Kullanımlar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetKullanım(int ID)
        {
            ViewData["Kullanım"] = Database.Kullanımlar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetEsya()
        {
            ViewData["Esya"] = Database.Esyalar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetEsya(int ID)
        {
            ViewData["Esya"] = Database.Esyalar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetKur()
        {
            ViewData["Kur"] = Database.Kurlar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetKur(int ID)
        {
            ViewData["Kur"] = Database.Kurlar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }
        public void GetEmlak()
        {
            ViewData["Emlak"] = Database.EmlakTips.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString()

            });
        }
        public void GetEmlak(int ID)
        {
            ViewData["Emlak"] = Database.EmlakTips.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = ID.ToString(),
                Selected = x.ID == ID


            });
        }

        public void Proper()
        {
            var _propertiesis = Database.Propertiesis.Where(x => x.IsDelete == false);
            var _propert = Database.Propertiesis.Select(x => new
            {
                Text = x.Name,
                ID = x.ID.ToString()
            }).ToList();


            ViewBag.propertiesis = _propert;
        }
        public void GetProp()
        {
            ViewData["Properties"] = Database.Propertiesis.Where(x => x.IsDelete == false).Select(x => new SelectListItem()

            {
                Text = x.Name.ToUpper(),
                Value = x.ID.ToString(),


            });
        }
        public void GetProp(int ID)
        {
            ViewData["Properties"] = Database.Propertiesis.Where(x => x.IsDelete == false).Select(x => new SelectListItem()

            {
                Text = x.Name.ToUpper(),
                Value = x.ID.ToString(),
                Selected = x.ID == ID
            });
        }

        public void GetIl()
        {
            ViewData["Il"] = Database.Iller.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Ad,
                Value = x.ID.ToString(),


            });
        }
        public void GetIl(int ID)
        {
            ViewData["Il"] = Database.Iller.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Ad,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }

        public void GetImar()
        {
            ViewData["Imar"] = Database.Imar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),


            });
        }
        public void GetImar(int ID)
        {
            ViewData["Imar"] = Database.Imar.Where(x => x.IsDelete == false && x.IsActive == true).Select(x => new SelectListItem()

            {
                Text = x.Name,
                Value = x.ID.ToString(),
                Selected = x.ID == ID


            });
        }

        #endregion
    }
}