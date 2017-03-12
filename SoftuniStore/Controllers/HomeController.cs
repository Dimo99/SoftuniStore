using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.Services;
using SoftuniStore.Utilities;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            service = new HomeService();
        }
        public IActionResult<IEnumerable<GameViewModel>> Homepage(HttpSession session)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<GameViewModel> models = service.GetAllGames();
            return View(models);
        }

    }
}