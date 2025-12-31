using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SalesWebMvc.Services
{
    public class DepartmentsService
    {
        private readonly SalesWebMvcContext Context;

        public DepartmentsService(SalesWebMvcContext context)
        {
            Context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await Context.Department.OrderBy(d => d.Name).ToListAsync();
        }
    }
}
