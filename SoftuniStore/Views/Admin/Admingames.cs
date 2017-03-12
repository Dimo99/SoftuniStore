using System.Collections.Generic;
using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Views.Admin
{
    public class Admingames : IRenderable<IEnumerable<AdminGameViewModel>>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavLogged);
            StringBuilder gamesCollection = new StringBuilder();
            foreach (var vm in this.Model)
            {
                gamesCollection.Append(vm);
            }
            string mainBody = string.Format(File.ReadAllText(Constants.AdminGames), gamesCollection);
            string footer = File.ReadAllText(Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(mainBody);
            builder.Append(footer);

            return builder.ToString();
        }

        public IEnumerable<AdminGameViewModel> Model { get; set; }
    }
}