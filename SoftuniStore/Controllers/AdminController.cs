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
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            service = new AdminService();
        }

        private bool IsAuthenticatedAsAdmin(HttpSession session)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                return false;
            }
            User user = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (!user.IsAdministrator)
            {
                return false;
            }
            return true;
        }
        [HttpGet]
        public IActionResult<IEnumerable<AdminGameViewModel>> Admingames(HttpSession session, HttpResponse response)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            IEnumerable<AdminGameViewModel> games = service.GetAdminGames();
            return View(games);
        }

        [HttpGet]
        public IActionResult Newgame(HttpSession session, HttpResponse response)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Newgame(AddGameBindingModel agbm, HttpResponse response, HttpSession session)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            if (!service.IsAddGameModelValid(agbm))
            {
                Redirect(response, "/admin/newgame");
                return null;
            }
            Game game = service.GetGameFromAddGameModel(agbm);
            service.AddGame(game);
            Redirect(response, "/admin/admingames");
            return null;
        }

        [HttpGet]
        public IActionResult<EditGameViewModel> Edit(int gameId, HttpResponse response, HttpSession session)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            EditGameViewModel viewModel = service.GetEditViewModel(gameId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<EditGameViewModel> Edit(EditGameBindingModel edit, HttpResponse response, HttpSession session)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            if (!service.IsEditBindingModelValid(edit))
            {
                Redirect(response, $"/admin/edit?gameId={edit.Id}");
                return null;
            }
            service.EditGame(edit);
            Redirect(response, "/admin/admingames");
            return null;
        }
        [HttpGet]
        public IActionResult<DeleteGameViewModel> Delete(HttpResponse response, HttpSession session, int gameId)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            DeleteGameViewModel viewModel = service.GetDeleteViewModel(gameId);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult<DeleteGameViewModel> Delete(HttpResponse response, HttpSession session,
            DeleteGameBindingModel delete)
        {
            if (!IsAuthenticatedAsAdmin(session))
            {
                Redirect(response, "/home/homepage");
                return null;
            }
            service.Delete(delete);
            Redirect(response, "/admin/admingames");
            return null;
        }
    }
}