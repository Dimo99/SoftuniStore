using System.IO;
using System.Text;
using SimpleMVC.Interfaces;

namespace SoftuniStore.Views.Games
{
    public class Newgame : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavLogged);
            string newgame = File.ReadAllText(Constants.NewGame);
            string footer = File.ReadAllText(Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(newgame);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}