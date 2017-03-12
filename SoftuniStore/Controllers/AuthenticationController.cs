using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;
using SoftuniStore.Services;
using SoftuniStore.Utilities;

namespace SoftuniStore.Controllers
{
    public class AuthenticationController : Controller
    {
        private AuthenticationService service;

        public AuthenticationController()
        {
            service = new AuthenticationService();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel lubm)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            if (service.IsLoginModelValid(lubm))
            {
                User user = service.GetUserFromLoginBind(lubm);
                service.Login(user,session.Id);
                Redirect(response,"/home/homepage");
                return null;
            }
            Redirect(response,"/authentication/login");
            return null;
        }
        [HttpGet]
        public IActionResult Login(HttpResponse response,HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel rubm,HttpResponse response, HttpSession session)
        {
            if (AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/home/homepage");
                return null;
            }
            if (service.IsRegisterModelValid(rubm))
            {
                User user = service.GetUserFromRegisterBind(rubm);
                service.RegisterUser(user);
                Redirect(response,"/home/homepage");
                return null;
            }
            Redirect(response, "/authentication/register");
            return null;
        }

        [HttpGet]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            if (!AuthenticationManager.IsAuthenticated(session.Id))
            {
                Redirect(response,"/authentication/login");
            }
            AuthenticationManager.Logout(response,session.Id);
            Redirect(response,"/home/homepage");
            return null;
        }
    }
}