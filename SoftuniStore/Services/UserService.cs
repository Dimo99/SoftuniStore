using System.Collections.Generic;
using AutoMapper;
using SoftuniStore.Models;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Services
{
    public class UserService : Service
    {
        public IEnumerable<GameViewModel> GetGamesForUser(User user)
        {
            return Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(user.Games);
        }
    }
}