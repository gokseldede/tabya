using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BLL.ViewModels;

namespace Project_BLL.Interfaces
{
    public interface IOptionService
    {
        List<SelectlistItem> GetExpertList();
        List<SelectlistItem> GetKimdenList();
        List<SelectlistItem> GetStatuslist();
        List<SelectlistItem> GetIsinmaList();
        List<SelectlistItem> GetKrediList();
        List<SelectlistItem> GetKurlarList();
        List<SelectlistItem> GetPropertiesList();
        List<SelectlistItem> GetSocialAppsList();
        List<SelectlistItem> GetSecurityList();
        List<SelectlistItem> GetIllerList();
        List<SelectlistItem> GetIlcelerList(int ilId);
        List<SelectlistItem> GetSemtList(int ilceId);
    }
}
