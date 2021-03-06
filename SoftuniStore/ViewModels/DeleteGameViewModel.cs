﻿namespace SoftuniStore.ViewModels
{
    public class DeleteGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public override string ToString()
        {
            return "<div class=\"text-center\"><h1 class=\"display-4\">Delete Game</h1></div>\r\n" +
                   "                <br/>\r\n                <form method=\"post\" id=\"new-game-form\">\r\n" +
                   $"                    <input type=\"type\" hidden=\"hidden\" name=\"id\" value=\"{Id}\" />\r\n\r\n" +
                   "                    <div class=\"form-group row\">\r\n                        " +
                   "<label for=\"name\" class=\"form-control-label\">Title</label>\r\n" +
                   "                        <input type=\"text\" maxlength=\"100\" minlength=\"4\" id=\"name\" class=\"form-control\"\r\n" +
                   $"                               placeholder=\"Enter Game Name\" name=\"title\" value=\"{Title}\" disabled/>\r\n" +
                   "                    </div>\r\n\r\n                    " +
                   "<input type=\"submit\" id=\"btn-edit-game\" class=\"btn btn-outline-danger btn-lg btn-block\"\r\n" +
                   "                           value=\"Delete Game\"/>\r\n                </form>\r\n                <br/>";
        }
    }
}