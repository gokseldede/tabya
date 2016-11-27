using System.ComponentModel.DataAnnotations;

namespace Project_UI.Areas.Admin.Models
{
    public class LandViewModel : BaseViewModel
    {
        public int Size { get; set; }
        public int PriceForM2 { get; set; }
        public int AdaNo { get; set; }
        public int ParselNo { get; set; }
        public int PaftaNo { get; set; }
        public string Emsal { get; set; }
        public string Gabari { get; set; }
        public string TapuDurumu { get; set; }
        public string KatKarsiligi { get; set; }
        public string Takas { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kredi Tipi seçmelisiniz!!!")]
        public int? KrediId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kimden olduğunu seçmelisiniz!!!")]
        public int? KimdenId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Kur seçmelisiniz!!!")]
        public int? KurlarId { get; set; }
    }
}