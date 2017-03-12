namespace SoftuniStore.ViewModels
{
    public class EditGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageThumbnail { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public string Trailer { get; set; }
        public override string ToString()
        {
            return "<div class=\"text-center\"><h1 class=\"display-3\">Edit Game</h1></div>\r\n" +
                   "                <br/>\r\n                " +
                   "<form method=\"post\" id=\"new-game-form\">\r\n" +
                   $"                    <input type=\"type\" name=\"Id\" hidden=\"hidden\" value=\"{Id}\" />\r\n\r\n" +
                   "                    <div class=\"form-group row\">\r\n                        " +
                   "<label for=\"name\" class=\"form-control-label\">Title</label>\r\n" +
                   "                        <input type=\"text\" name=\"Title\" maxlength=\"100\" minlength=\"4\" id=\"name\" class=\"form-control\"\r\n" +
                   $"                               placeholder=\"Enter Game Name\" value=\"{Title}\"/>\r\n" +
                   "                    </div>\r\n\r\n                    <div class=\"form-group row\">\r\n" +
                   "                        <label for=\"desc\" class=\"form-control-label\">Description</label>\r\n" +
                   "                        <textarea id=\"desc\" name=\"Description\" class=\"form-control\"\r\n " +
                   $"placeholder=\"Enter Game Description\" minlength=\"30\">{Description}</textarea>\r\n" +
                   "                    </div>\r\n\r\n                    <div class=\"form-group row\">\r\n" +
                   "                        <label for=\"thumbnail\" class=\"form-control-label\">Thumbnail</label>\r\n" +
                   "                        <input type=\"url\" name=\"ImageThumbnail\" id=\"thumbnail\" class=\"form-control\"\r\n" +
                   "                               placeholder=\"Enter URL to Image\"\r\n" +
                   $"                               value=\"{ImageThumbnail}\"/>\r\n" +
                   "                    </div>\r\n\r\n                    <div class=\"form-group row\">\r\n" +
                   "                        <label for=\"price\" class=\"form-control-label\">Price</label>\r\n" +
                   "                        <div class=\"input-group\">\r\n\r\n" +
                   "                            <input placeholder=\"Enter Prize\" name=\"Price\" type=\"text\" step=\"0.01\" min=\"0\" id=\"price\" class=\"form-control\"\r\n" +
                   $"                                    value=\"{Price}\"/>\r\n" +
                   "                            <span class=\"input-group-addon\"\r\n" +
                   "                                  id=\"addon2\">&euro;</span>\r\n" +
                   "                        </div>\r\n                    </div>\r\n\r\n" +
                   "                    <div class=\"form-group row\">\r\n" +
                   "                        <label for=\"size\" class=\"form-control-label\">Size</label>\r\n" +
                   "                        <div class=\"input-group\">\r\n\r\n" +
                   "                            <input type=\"text\" name=\"Size\" step=\"0.1\" min=\"0\" id=\"size\" class=\"form-control\"\r\n" +
                   $"                                   placeholder=\"Enter Size\" value=\"{Size}\"/>\r\n" +
                   "                            <span class=\"input-group-addon\"\r\n" +
                   "                                  id=\"addon3\">GB</span>\r\n" +
                   "                        </div>\r\n                    </div>\r\n\r\n" +
                   "                    <div class=\"form-group row\">\r\n                        " +
                   "<label for=\"video\" class=\"form-control-label\">YouTube Video URL</label>\r\n                        " +
                   "<div class=\"input-group\">\r\n                            <span class=\"input-group-addon\"\r\n" +
                   "                                  id=\"addon\">https://www.youtube.com/watch?v=</span>\r\n" +
                   "                            <input type=\"text\" name=\"Trailer\" class=\"form-control\" id=\"video\"\r\n" +
                   $"                                   value=\"{Trailer}\"/>\r\n                        </div>\r\n" +
                   "                    </div>\r\n                    " +
                   "<input type=\"submit\" id=\"btn-edit-game\" class=\"btn btn-outline-warning btn-lg btn-block\"\r\n" +
                   "                           value=\"Edit Game\"/>\r\n                </form>\r\n                <br/>";
        }
    }
}