using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Views.Admin
{
    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavLogged);
            string deletegame = string.Format(File.ReadAllText(Constants.DeleteGame), Model);
            string footer = File.ReadAllText(Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(deletegame);
            builder.Append(footer);
            return builder.ToString();
        }

        public DeleteGameViewModel Model { get; set; }
    }
}