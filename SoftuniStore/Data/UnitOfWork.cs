using SoftuniStore.Data.Interfaces;
using SoftuniStore.Data.Repository;
using SoftuniStore.Models;

namespace SoftuniStore.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private SoftuniStoreContext context;
        private Repository<User> users;
        private Repository<Login> logins;
        private Repository<Game> games;
        public Repository<User> Users => users??(users = new Repository<User>(context.Users));
        public Repository<Login> Logins => logins??(logins = new Repository<Login>(context.Logins));
        public Repository<Game> Games => games ?? (games = new Repository<Game>(context.Games));
        public UnitOfWork()
        {
            this.context = Data.Context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}