using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;
using ZarzadzanieFirmaTransportowa.Models.Users;

namespace ZarzadzanieFirmaTransportowa.Models.AssignmentToCar
{
    public class AssignmentCarViewModel
    {
        public AssignmentCarViewModel() { }

        public List<AssignmentCarModel> AssignmentCar { get; set; }
        public List<CarModel> Cars { get; internal set; }
        public List<TrailerModel> Trailers { get; internal set; }
        public List<UserModel> Users { get; internal set; }
    }
}
