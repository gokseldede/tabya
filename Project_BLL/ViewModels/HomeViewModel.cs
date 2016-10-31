using System.Collections.Generic;

namespace Project_BLL.ViewModels
{
    public class HomeViewModel
    {
        public List<NewAdvertisement> Advertisements { get; set; }
        public List<NewProject> Projects { get; set; }
        public List<SelectlistItem> Cities { get; set; }
    }

    public class NewProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
    }

    public class NewAdvertisement
    {
        public string Photo { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
        public string Address { get; set; }
        public int SquareMetre { get; set; }
        public int Id { get; set; }
    }

    public class SelectlistItem
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }

}
