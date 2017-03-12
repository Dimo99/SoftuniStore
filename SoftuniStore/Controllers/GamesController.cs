using System.Collections.Generic;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;
using SoftuniStore.Services;
using SoftuniStore.Utilities;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Controllers
{
    public class GamesController : Controller
    {
        private GamesService service;

        public GamesController()
        {
            service = new GamesService();
        }
        [HttpGet]
        public IActionResult<GameDetailsViewModel> Game(HttpSession session,int gameId)
        {
            AuthenticationManager.GetAuthenticatedUser(session.Id);
            var model = service.GetGame(gameId);
            return View(model);
        }

        [HttpPost]
        public IActionResult<GameDetailsViewModel> Game(HttpSession session, HttpResponse response,
            BuyGameBindingModel model)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,$"/authentication/login");
                return null;
            }
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            service.AddGameToUser(model, user);
            Redirect(response,"/user/games");
            return null;

        }
       
     }
}