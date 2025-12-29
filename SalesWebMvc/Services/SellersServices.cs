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
            Context.Add(seller);
            Context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return Context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id)
        {
            var obj = Context.Seller.Find(id);
            Context.Seller.Remove(obj);
            Context.SaveChanges();
        }
    }
}
