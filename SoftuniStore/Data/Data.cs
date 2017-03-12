namespace SoftuniStore.Data
{
    public class Data
    {
        private static SoftuniStoreContext context;
        public static SoftuniStoreContext Context => context ?? (context = new SoftuniStoreContext());
    }
}