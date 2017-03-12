using AutoMapper;
using SimpleHttpServer;
using SimpleMVC;
using SoftuniStore.BindingModels;
using SoftuniStore.Models;
using SoftuniStore.ViewModels;

namespace SoftuniStore
{
    class AppStart
    {
        static void Main()
        {
            ConfigureMapper();
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftuniStore");
        }

        private static void ConfigureMapper()
        {
            Mapper.Initialize(expresion =>
            {
                expresion.CreateMap<RegisterUserBindingModel, User>();
                expresion.CreateMap<Game, GameViewModel>();
                expresion.CreateMap<Game, GameDetailsViewModel>();
                expresion.CreateMap<Game, AdminGameViewModel>();
                expresion.CreateMap<AddGameBindingModel, Game>();
                expresion.CreateMap<Game, EditGameViewModel>();
                expresion.CreateMap<Game, DeleteGameViewModel>();
            });
        }
    }
}