using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Services
{
    public class SellersServices
    {
        private readonly SalesWebMvcContext Context;

        public SellersServices(SalesWebMvcContext context)
        {
            Context = context;
        }

        public List<Seller> FindAll()
        {
            return Context.Seller.ToList();
        }
    }
}
