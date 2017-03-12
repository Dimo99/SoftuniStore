using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SoftuniStore.Models;
using SoftuniStore.ViewModels;

namespace SoftuniStore.Services
{
    public class HomeService : Service
    {
        public IEnumerable<GameViewModel> GetAllGames()
        {
            //IList<GameViewModel> models = new List<GameViewModel>();
            //var entities = Context.Games.Entities;
            //foreach (var entity in entities)
            //{
            //    var model = new GameViewModel()
            //    {
            //        Description = entity.Description,
            //        ImageThumbnail = entity.ImageThumbnail,
            //        Id = entity.Id,
            //        Price = entity.Price,
            //        Size = entity.Size,
            //        Title = entity.Title
            //    };
            //    models.Add(model);
            //}
            //return models;
            return Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(Context.Games.Entities);
            //return Context.Games.Entities.Select(g => new GameViewModel()
            //{
            //    Description = g.Description,
            //    ImageThumbnail = g.ImageThumbnail,
            //    Id = g.Id,
            //    Price = g.Price,
            //    Size = g.Size,
            //    Title = g.Title
            //});
        }
    }
}