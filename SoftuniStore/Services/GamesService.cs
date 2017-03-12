using System;
using System.Collections.Generic;
using AutoMapper;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Services
{
    public class GamesService : Service
    {
        public GameDetailsViewModel GetGame(int gameId)
        {
            return Mapper.Map<Game, GameDetailsViewModel>(Context.Games.Find(gameId));
        }
        
        public void AddGameToUser(BuyGameBindingModel model, User user)
        {
            Game game = Context.Games.Find(model.Id);
            user.Games.Add(game);
            Context.SaveChanges();
        }
    }
}