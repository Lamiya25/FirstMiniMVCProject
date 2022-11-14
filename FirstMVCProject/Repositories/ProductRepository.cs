using FirstMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repositories
{
    public class ProductRepository:GenericRepository<Product>
    {

        public List<Product> GetAllActive()
        {
            using var dbContext = new AppDbContext();
            return dbContext.Products.Include(x=>x.Category).Where(x => x.IsDeleted == false).ToList();
        }
    }
}
