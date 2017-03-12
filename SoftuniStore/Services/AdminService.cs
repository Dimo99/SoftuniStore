using System.Collections.Generic;
using AutoMapper;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Services
{
    public class AdminService : Service
    {
        public IEnumerable<AdminGameViewModel> GetAdminGames()
        {
            return Mapper.Map<IEnumerable<Game>, IEnumerable<AdminGameViewModel>>(Context.Games.Entities);
        }

        public void AddGame(Game game)
        {
            Context.Games.Add(game);
            Context.SaveChanges();
        }

        public bool IsAddGameModelValid(AddGameBindingModel agbm)
        {

            if (!char.IsUpper(agbm.Title[0]) || (agbm.Title.Length < 3 && agbm.Title.Length > 100))
            {
                return false;
            }
            if (agbm.Price <= 0)
            {
                return false;
            }
            if (agbm.Size <= 0)
            {
                return false;
            }
            if (agbm.Trailer.Length < 11)
            {
                return false;
            }
            if (!agbm.ImageThumbnail.StartsWith("http://") && !agbm.ImageThumbnail.StartsWith("https://"))
            {
                return false;
            }
            if (agbm.Description.Length < 20)
            {
                return false;
            }
            return true;
        }

        public bool IsEditBindingModelValid(EditGameBindingModel edit)
        {
            if (!char.IsUpper(edit.Title[0]) || (edit.Title.Length < 3 && edit.Title.Length > 100))
            {
                return false;
            }
            if (edit.Price <= 0)
            {
                return false;
            }
            if (edit.Size <= 0)
            {
                return false;
            }
            if (edit.Trailer.Length < 11)
            {
                return false;
            }
            if (!edit.ImageThumbnail.StartsWith("http://") && !edit.ImageThumbnail.StartsWith("https://"))
            {
                return false;
            }
            if (edit.Description.Length < 20)
            {
                return false;
            }
            return true;
        }
        public void EditGame(EditGameBindingModel edit)
        {
            Game game = Context.Games.Find(edit.Id);
            game.Title = edit.Title;
            game.Description = edit.Description;
            game.ImageThumbnail = edit.ImageThumbnail;
            game.Price = edit.Price;
            game.Size = edit.Size;
            game.Trailer = edit.Trailer;
            Context.SaveChanges();
        }
        public Game GetGameFromAddGameModel(AddGameBindingModel agbm)
        {
            return Mapper.Map<AddGameBindingModel, Game>(agbm);
        }

        public EditGameViewModel GetEditViewModel(int gameId)
        {
            return Mapper.Map<Game, EditGameViewModel>(Context.Games.Find(gameId));
        }

        public DeleteGameViewModel GetDeleteViewModel(int gameId)
        {
            return Mapper.Map<Game, DeleteGameViewModel>(Context.Games.Find(gameId));
        }

        public void Delete(DeleteGameBindingModel delete)
        {
            var game = Context.Games.Find(delete.Id);
            Context.Games.Remove(game);
            Context.SaveChanges();
        }
    }
}