using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Models.AssignmentToCar;

namespace ZarzadzanieFirmaTransportowa.Services.AssignementCar
{
    public class AssignmentCarService : IAssignmentCarService
    {
        private readonly CarContext _context;

        public AssignmentCarService(CarContext context)
        {
            _context = context;
        }

        public void AssignementCar(int carId, int trailerId, int userId)
        {
            var car = _context.Car.FirstOrDefault(x => x.Id == carId);
            var trailer = _context.Trailer.FirstOrDefault(x => x.Id == trailerId);
            var user = _context.User.FirstOrDefault(x => x.Id == carId);

            if(car != null && trailer != null && user != null)
            {
                _context.AssignmentCar.Add(new AssignmentCarModel
                {
                    Car = car,
                    Trailer = trailer,
                    User = user,
                    AssignmentDate = DateTime.Now
                });
                _context.SaveChanges();
            }
        }

        public void DeleteAssignement(int id)
        {
            var assignmentCar = _context.AssignmentCar.FirstOrDefault(x => x.Id == id);

            if(assignmentCar != null)
            {
                _context.AssignmentCar.Remove(assignmentCar);
                _context.SaveChanges();
            }
        }

        public AssignmentCarModel GetAssignments(int id)
        {
            var assignmentCar = _context.AssignmentCar.FirstOrDefault(x => x.Id == id);
            return assignmentCar ?? new AssignmentCarModel();
        }

        public List<AssignmentCarModel> GetAssignments()
        {
            return _context.AssignmentCar.ToList();
        }
    }
}
