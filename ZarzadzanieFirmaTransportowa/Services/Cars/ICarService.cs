using ZarzadzanieFirmaTransportowa.Models.Cars;

namespace ZarzadzanieFirmaTransportowa.Services.Cars
{
    public interface ICarService
    {
        public List<CarModel> GetCar();
        public CarModel GetCar (int id);
        public void InsertCar(string Model, string Brand, int Power, double Distance, int YearOfProduction);
        public void UpdateCar(int id, string Model, string Brand, int Power, double Distance, int YearOfProduction);
        public void DeleteCar(int id);
    }
}
