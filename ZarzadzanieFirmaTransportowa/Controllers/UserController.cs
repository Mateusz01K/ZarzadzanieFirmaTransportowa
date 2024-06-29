using Microsoft.AspNetCore.Mvc;
using ZarzadzanieFirmaTransportowa.Models.Cars;
using ZarzadzanieFirmaTransportowa.Models.Users;
using ZarzadzanieFirmaTransportowa.Services.User;

namespace ZarzadzanieFirmaTransportowa.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult InsertNewUser()
        {
            return View();
        }


        public IActionResult InsertUser(string Name, string LastName, string Email)
        {
            if (string.IsNullOrEmpty(Name) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(Email))
            {
                TempData["message"] = "Popraw dane.";
                return RedirectToAction("Index");
            }
            _userService.InsertUser(Name, LastName, Email);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult DeleteThisUser(int id)
        {
            if (id != 0)
            {
                _userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }

        public IActionResult UpDateUser()
        {
            var model = new UserViewModel()
            {
                Users = _userService.GetUser()
            };
            return View(model);
        }

        public IActionResult UpDateThisUser(int id, string Name, string LastName, string Email)
        {
            var items = _userService.GetUser().Count();
            if (id != 0 && Name != "" && LastName != "" && Email != "")
            {
                _userService.Updateuser(id, Name, LastName, Email);
                return RedirectToAction("Index");
            }
            TempData["message"] = "Popraw dane.";
            return RedirectToAction("Index");
        }
    }
}
