using System.Collections.Generic;

namespace SoftuniStore.Models
{
    public class User
    {
        public User()
        {
            Games = new List<Game>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public bool IsAdministrator { get; set; }
    }
}