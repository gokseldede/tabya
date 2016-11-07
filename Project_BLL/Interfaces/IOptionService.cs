using System.Collections.Generic;
using Project_BLL.ServiceModels;

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
        List<SelectlistItem> GetImarList();
        List<SelectlistItem> GetEmlakTipList();
        List<SelectlistItem> GetEsyaList();
        List<SelectlistItem> GetSiteList();
        List<SelectlistItem> GetKullanimList();
    }
}
