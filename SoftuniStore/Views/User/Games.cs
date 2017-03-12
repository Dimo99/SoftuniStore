using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Views.User
{
    public class Games : IRenderable<IEnumerable<GameViewModel>>
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
            StringBuilder gamesCollection = new StringBuilder();
            int counter = 0;
            gamesCollection.Append("<div class=\"card-group\">");
            foreach (var vm in this.Model)
            {
                if (counter % 3 == 0)
                {
                    gamesCollection.Append("</div>");
                    gamesCollection.Append("<div class=\"card-group\">");
                }
                counter++;
                gamesCollection.Append(vm);
            }
            gamesCollection.Append("</div>");
            string mainBody = string.Format(File.ReadAllText(Constants.Home), gamesCollection);
            string footer = File.ReadAllText(Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(mainBody);
            builder.Append(footer);

            return builder.ToString();
        }

        public IEnumerable<GameViewModel> Model { get; set; }
    }
}