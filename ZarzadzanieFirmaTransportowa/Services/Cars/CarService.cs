using ZarzadzanieFirmaTransportowa.Context;
using ZarzadzanieFirmaTransportowa.Models.Cars;

namespace ZarzadzanieFirmaTransportowa.Services.Cars
{
    public class CarService : ICarService
    {
        private readonly CarContext _context;

        public CarService(CarContext context)
        {
            _context = context;
        }

        public void DeleteCar(int id)
        {
            var car = _context.Car.FirstOrDefault(x => x.Id == id);
            if (car != null)
            {
                _context.Car.Remove(car);
                _context.SaveChangesAsync();
            }
        }

        public List<CarModel> GetCar()
        {
            return _context.Car.ToList();
        }

        public CarModel GetCar(int id)
        {
            var car = _context.Car.FirstOrDefault(x => x.Id == id);
            return car ?? new CarModel();
        }

        public void InsertCar(string Model, string Brand, int Power, double Distance, int YearOfProduction)
        {
            var lastId = _context.Car.OrderByDescending(x => x.Id).FirstOrDefault()?.Id;
            if(lastId != null)
            {
                _context.Car.Add(new CarModel()
                {
                    Id = (int)  lastId + 1,
                    Model = Model,
                    Brand = Brand,
                    Power = Power,
                    Distance = Distance,
                    YearOfProduction = YearOfProduction
                });
                _context.SaveChanges();
            }
        }

        public void UpdateCar(int id, string Model, string Brand, int Power, double Distance, int YearOfProduction)
        {
            var car = _context.Car.FirstOrDefault(x => x.Id == id);
            if(car != null)
            {
                car.Model = Model;
                car.Brand = Brand;
                car.Power = Power;
                car.Distance = Distance;
                car.YearOfProduction = YearOfProduction;
                _context.SaveChanges();
            }
        }
    }
}
