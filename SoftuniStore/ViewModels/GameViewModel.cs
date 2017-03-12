namespace SoftuniStore.ViewModels
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal Size { get; set; }
        public string ImageThumbnail { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            if (Description.Length > 300)
            {
                return "<div class=\"card col-4 thumbnail\">\r\n\r\n                        " +
                       "<img class=\"card-image-top img-fluid img-thumbnail\" " +
                       $"src=\"{ImageThumbnail}\">\r\n\r\n" +
                       $"<div class=\"card-block\">\r\n<h4 class=\"card-title\">{Title}</h4>\r\n" +
                       $"<p class=\"card-text\"><strong>Price</strong> - {Price}&euro;</p>\r\n<p class=\"card-text\"><strong>Size</strong> - {Size} GB</p>\r\n                            " +
                       $"<p class=\"card-text\">{Description.Substring(0, 300)}</p>\r\n</div>\r\n\r\n" +
                       "<div class=\"card-footer\">\r\n" +
                       $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/games/game?gameId={Id}\">Info</a>\r\n</div></div>";
            }
            else
            {
                return "<div class=\"card col-4 thumbnail\">\r\n\r\n                        " +
                       "<img class=\"card-image-top img-fluid img-thumbnail\" " +
                       $"src=\"{ImageThumbnail}\">\r\n\r\n" +
                       $"<div class=\"card-block\">\r\n<h4 class=\"card-title\">{Title}</h4>\r\n" +
                       $"<p class=\"card-text\"><strong>Price</strong> - {Price}&euro;</p>\r\n<p class=\"card-text\"><strong>Size</strong> - {Size} GB</p>\r\n                            " +
                       $"<p class=\"card-text\">{Description.Substring(0, Description.Length)}</p>\r\n</div>\r\n\r\n" +
                       "<div class=\"card-footer\">\r\n" +
                       $"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/games/game?gameId={Id}\">Info</a>\r\n</div></div>";
            }
        }
    }
}