using SoftuniStore.Data;

namespace SoftuniStore.Services
{
    public abstract class Service
    {
        protected UnitOfWork Context;

        public Service()
        {
            this.Context = new UnitOfWork();
        }
    }
}