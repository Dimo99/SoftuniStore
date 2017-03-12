using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Views.Games
{
    public class Game : IRenderable<GameDetailsViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation;
            string currentUser = ViewBag.GetUserName();
            if (currentUser != null)
            {
                navigation = File.ReadAllText(Constants.NavLogged);
            }
            else
            {
                navigation = File.ReadAllText(Constants.NavNotLogged);
            }
            string game = Model.ToString();
            string mainBody = string.Format(File.ReadAllText(Constants.GameDetails), game);
            string footer = File.ReadAllText(Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(mainBody);
            builder.Append(footer);

            return builder.ToString();
        }

        public GameDetailsViewModel Model { get; set; }
    }
}