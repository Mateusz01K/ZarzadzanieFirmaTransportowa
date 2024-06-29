using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;
using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa.Models.AssignmentToCar
{
    public class AssignmentCarModel
    {
        public AssignmentCarModel() { }
        public int Id { get; set; }
        public int CarId { get; set; }
        public CarModel Car { get; set; }
        public int TrailerId { get; set; }
        public TrailerModel Trailer { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime AssignmentDate { get; set; }
    }
}
