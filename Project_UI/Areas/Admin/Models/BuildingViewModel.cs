using System.ComponentModel.DataAnnotations;

namespace Project_UI.Areas.Admin.Models
{
    public class BuildingViewModel:BaseViewModel
    {
        public int Size { get; set; }
        public int BAge { get; set; }
        public int FloorCount { get; set; }
        public int FloorFlatCount { get; set; }
        public string Takas { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kimden olduğunu seçmelisiniz!!!")]
        public int? KimdenId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kur seçmelisiniz!!!")]
        public int? KurlarId { get; set; }
    }
}