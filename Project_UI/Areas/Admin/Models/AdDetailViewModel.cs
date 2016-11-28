using System.ComponentModel.DataAnnotations;

namespace Project_UI.Areas.Admin.Models
{
    public class AdDetailViewModel:BaseViewModel
    {

        public string RoomCount { get; set; }
        public int Size { get; set; }
        public int Dues { get; set; }
        public int FloorCount { get; set; }
        public int FlatFloor { get; set; }
        public int BAge { get; set; }
        public int BathroomCount { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kredi Tipi seçmelisiniz!!!")]
        public int? KrediId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Isınma Tipi seçmelisiniz!!!")]
        public int? IsinmaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kimden olduğunu seçmelisiniz!!!")]
        public int? KimdenId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kur seçmelisiniz!!!")]
        public int? KurlarId { get; set; }
    }
}