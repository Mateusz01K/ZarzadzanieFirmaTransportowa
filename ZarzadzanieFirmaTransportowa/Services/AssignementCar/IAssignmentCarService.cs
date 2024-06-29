using ZarzadzanieFirmaTransportowa.Models.AssignmentToCar;

namespace ZarzadzanieFirmaTransportowa.Services.AssignementCar
{
    public interface IAssignmentCarService
    {
        public void AssignementCar(int carId, int trailerId, int userId);

        public AssignmentCarModel GetAssignments(int id);
        public List<AssignmentCarModel> GetAssignments();
        public void DeleteAssignement(int id);
    }
}
