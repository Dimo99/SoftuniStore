namespace SoftuniStore.ViewModels
{
    public class AdminGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
        {
            return "<tr>\r\n                        " +
                   $"<td>{Title}</td>\r\n" +
                   $"                        <td>{Size} GB</td>\r\n" +
                   $"                        <td>{Price} &euro;</td>\r\n" +
                   "                        <td>\r\n" +
                   $"                            <a href=\"/admin/edit?gameId={Id}\" class=\"btn btn-warning btn-sm\">Edit</a>\r\n" +
                   $"                            <a href=\"/admin/delete?gameId={Id}\" class=\"btn btn-danger btn-sm\">Delete</a>\r\n" +
                   "                        </td>\r\n" +
                   "                    </tr>";
        }
    }
}