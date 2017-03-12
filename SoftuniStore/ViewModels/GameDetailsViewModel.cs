using System;

namespace SoftuniStore.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Trailer { get; set; }
        public override string ToString()
        {
            return $"<h1 class=\"display-3\">{Title}</h1>\r\n                " +
                   "<br/>\r\n\r\n                " +
                   $"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{Trailer}\"" +
                   "frameborder=\"0\" allowfullscreen></iframe>\r\n\r\n                <br/>\r\n                " +
                   $"<br/>\r\n\r\n                <p>{Description}</p>\r\n\r\n                " +
                   $"<p><strong>Price</strong> - {Price}&euro;</p>\r\n                <p><strong>Size</strong> - {Size} GB</p>\r\n" +
                   $"               <p><strong>Release Date</strong> - {ReleaseDate}</p>\r\n\r\n                " +
                   "<a class=\"btn btn-outline-primary\" name=\"back\" href=\"/home/homepage\">Back</a>\r\n                " +
                   "<form  method=\"post\">\r\n                    " +
                   $"<input type=\"number\" name=\"id\" value=\"{Id}\" hidden=\"hidden\" />\r\n                    " +
                   "<br/>\r\n                    <input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />\r\n" +
                   "                </form>\r\n                <br/>\r\n                <br/>";
        }
    }
}