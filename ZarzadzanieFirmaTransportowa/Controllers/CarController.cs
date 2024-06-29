using Microsoft.AspNetCore.Mvc;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Services.Cars;

namespace ZarzadzanieFirmaTransportowa.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        public CarController(ILogger<CarController> logger, ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var model = new CarViewModel()
            {
                Car = _carService.GetCar()
            };
            return View(model);
        }

        public IActionResult InsertNewCar()
        {
            return View();
        }


        public IActionResult InsertCar(string Model, string Brand, int Power, double Distance, int YearOfProduction)
        {
            if(string.IsNullOrEmpty(Model) && string.IsNullOrEmpty(Brand) && Power == 0 && Distance == 0 && YearOfProduction == 0)
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _carService.InsertCar(Model, Brand, Power, Distance, YearOfProduction);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCar()
        {
            var model = new CarViewModel()
            {
                Car = _carService.GetCar()
            };
            return View(model);
        }

        public IActionResult DeleteThisCar(int id)
        {
            if(id!=0)
            {
                _carService.DeleteCar(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCar()
        {
            var model = new CarViewModel()
            {
                Car = _carService.GetCar()
            };
            return View(model);
        }

        public IActionResult UpdateThisCar(int id, string Model, string Brand, int Power, double Distance, int YearOfProduction)
        {
            var items = _carService.GetCar().Count();
            if(id != 0 && !string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Brand) && Power != 0 && Distance != 0 && YearOfProduction != 0)
            {
                _carService.UpdateCar(id, Model, Brand, Power, Distance, YearOfProduction);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
