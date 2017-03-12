using System.IO;
using System.Text;
using SimpleMVC.Interfaces.Generic;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Views.Admin
{
    public class Edit : IRenderable<EditGameViewModel>
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Header);
            string navigation = File.ReadAllText(Constants.NavLogged);
            string editgame = string.Format(File.ReadAllText(Constants.EditGame),Model);
            string footer = File.ReadAllText(Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(editgame);
            builder.Append(footer);
            return builder.ToString();
        }

        public EditGameViewModel Model { get; set; }
    }
}