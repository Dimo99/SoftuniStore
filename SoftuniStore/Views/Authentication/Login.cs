using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftuniStore.Views.Authentication
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavNotLogged);
            string login = File.ReadAllText(Constants.Login);
            string footer = File.ReadAllText(Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(login);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}