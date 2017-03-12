using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.Models;
using SoftuniStore.Services;
using SoftuniStore.Utilities;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Controllers
{
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            service = new UserService();
        }
        public IActionResult<IEnumerable<GameViewModel>> Games(HttpSession session,HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            IEnumerable<GameViewModel> viewModels = service.GetGamesForUser(user);
            return View(viewModels);

        }
    }
}