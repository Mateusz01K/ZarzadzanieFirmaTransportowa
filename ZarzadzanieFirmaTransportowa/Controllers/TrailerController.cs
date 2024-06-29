using Microsoft.AspNetCore.Mvc;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Trailers;
using ZarzadzanieFirmaTransportowa.Services.Trailer;

namespace ZarzadzanieFirmaTransportowa.Controllers
{
    public class TrailerController : Controller
    {
        private readonly ITrailerService _trailerService;
        public TrailerController(ILogger<TrailerController> logger, ITrailerService trailerService)
        {
            _trailerService = trailerService;
        }

        public IActionResult Index()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult InsertNewTrailer()
        {
            return View();
        }


        public IActionResult InsertCar(string Name, string Description, string Type, int MaxLoad, int YearOfProduction)
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(Description) && string.IsNullOrEmpty(Type) && MaxLoad == 0 && YearOfProduction == 0)
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _trailerService.InsertTrailer(Name, Description, Type, MaxLoad, YearOfProduction);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTrailer()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult DeleteThisTrailer(int id)
        {
            if (id != 0)
            {
                _trailerService.DeleteTrailer(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult UpdateTrailer()
        {
            var model = new TrailerViewModel()
            {
                Trailers = _trailerService.GetTrailer()
            };
            return View(model);
        }

        public IActionResult UpdateThisTrailer(int id, string Name, string Description, string Type, int MaxLoad, int YearOfProduction)
        {
            var items = _trailerService.GetTrailer().Count();
            if (id != 0 && Name != "" && Type != "" && MaxLoad != 0 && YearOfProduction != 0)
            {
                _trailerService.UpdateTrailer(id, Name, Description, Type, MaxLoad, YearOfProduction);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
