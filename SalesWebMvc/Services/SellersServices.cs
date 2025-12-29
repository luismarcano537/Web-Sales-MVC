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

        public void Insert(Seller seller)
        {
            seller.Department = Context.Department.First();
            Context.Add(seller);
            Context.SaveChanges();
        }
    }
}
