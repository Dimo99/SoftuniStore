using System.Text.RegularExpressions;
using AutoMapper;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;

namespace SoftuniStore.Services
{
    public class AuthenticationService : Service
    {
        public void RegisterUser(User user)
        {
            if (!Context.Users.Any(u => true))
            {
                user.IsAdministrator = true;
            }
            this.Context.Users.Add(user);
            Context.SaveChanges();
        }

        public bool IsLoginModelValid(LoginUserBindingModel lubm)
        {
            return Context.Users.Any(u => u.Email == lubm.Email && u.Password == lubm.Password);
        }

        public User GetUserFromLoginBind(LoginUserBindingModel lubm)
        {
            return Context.Users.FirstOrDefault(u => u.Email == lubm.Email && u.Password ==lubm.Password);
        }
        public bool IsRegisterModelValid(RegisterUserBindingModel rubm)
        {
            Regex passwordRegex = new Regex(@"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}");
            if (!rubm.Email.Contains("@") || IsUserEmailUnique(rubm.Email))
            {
                return false;
            }
            if (!passwordRegex.IsMatch(rubm.Password))
            {
                return false;
            }
            if (rubm.ConfirmPassword != rubm.Password)
            {
                return false;
            }
            if (string.IsNullOrEmpty(rubm.FullName))
            {
                return false;
            }
            return true;
        }

        private bool IsUserEmailUnique(string rubmEmail)
        {
            return Context.Users.Any(u => u.Email == rubmEmail);
        }

        public void Login(User user,string sessionId)
        {
            var login = new Login()
            {
                IsActive = true,
                SessionId = sessionId,
                User = user
            };
            Context.Logins.Add(login);
            Context.SaveChanges();
        }
        public User GetUserFromRegisterBind(RegisterUserBindingModel rubm)
        {
            return Mapper.Map<RegisterUserBindingModel, User>(rubm);
        }
    }
}