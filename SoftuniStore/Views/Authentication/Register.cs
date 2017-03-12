using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftuniStore.Views.Authentication
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.Register);
            string footer = File.ReadAllText(Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(register);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}