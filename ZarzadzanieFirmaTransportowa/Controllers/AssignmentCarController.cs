using Microsoft.AspNetCore.Mvc;
using ZarzadzanieFirmaTransportowa.Models.AssignmentToCar;
using ZarzadzanieFirmaTransportowa.Services.AssignementCar;
using ZarzadzanieFirmaTransportowa.Services.Cars;
using ZarzadzanieFirmaTransportowa.Services.Trailer;
using ZarzadzanieFirmaTransportowa.Services.User;

namespace ZarzadzanieFirmaTransportowa.Controllers
{
    public class AssignmentCarController : Controller
    {
        private readonly IAssignmentCarService _assignmentCarService;
        private readonly ICarService _carService;
        private readonly ITrailerService _trailerService;
        private readonly IUserService _userService;

        public AssignmentCarController(IAssignmentCarService assignmentCarService, ICarService carService, ITrailerService trailerService, IUserService userService)
        {
            _assignmentCarService = assignmentCarService;
            _carService = carService;
            _trailerService = trailerService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new AssignmentCarViewModel()
            {
                Cars = _carService.GetCar(),
                Trailers = _trailerService.GetTrailer(),
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var model = new AssignmentCarViewModel()
            {
                Cars = _carService.GetCar(),
                Trailers = _trailerService.GetTrailer(),
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult DeleteAssignment()
        {
            var model = new AssignmentCarViewModel()
            {
                Cars = _carService.GetCar(),
                Trailers = _trailerService.GetTrailer(),
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult DeleteThisAssignment(int id)
        {
            var items = _assignmentCarService.GetAssignments().Count();
            if(id != 0)
            {
                _assignmentCarService.DeleteAssignement(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
