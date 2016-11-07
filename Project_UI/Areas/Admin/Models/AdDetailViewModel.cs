using System.ComponentModel.DataAnnotations;

namespace Project_UI.Areas.Admin.Models
{
    public class AdDetailViewModel:BaseViewModel
    {

        public int RoomCount { get; set; }
        public int Size { get; set; }
        [DataType(DataType.Currency)]
        public decimal Dues { get; set; }
        public int FloorCount { get; set; }
        public int FlatFloor { get; set; }
        public int BAge { get; set; }
        public int BathroomCount { get; set; }

    }
}