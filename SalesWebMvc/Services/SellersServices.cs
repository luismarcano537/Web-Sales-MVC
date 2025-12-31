using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SalesWebMvc.Services.Exceptions;

namespace SalesWebMvc.Services
{
    public class SellersServices
    {
        private readonly SalesWebMvcContext Context;

        public SellersServices(SalesWebMvcContext context)
        {
            Context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await Context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller seller)
        {
            Context.Add(seller);
            await Context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await Context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var obj = await Context.Seller.FindAsync(id);
                Context.Seller.Remove(obj);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException(e.Message);
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await Context.Seller.AnyAsync(x => x.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }

            try
            {
                Context.Update(seller);
                await Context.SaveChangesAsync();
            }
            catch (DbConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
