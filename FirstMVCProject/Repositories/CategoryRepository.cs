using FirstMVCProject.Models;

namespace FirstMVCProject.Repositories
{
    public class CategoryRepository:GenericRepository<Category>
    {
        public List<Category> GetAllActive()
        {
          using var dbContext= new AppDbContext();
            return dbContext.Categories.Where(x => x.IsDeleted == false).ToList();
        }

    }

}
