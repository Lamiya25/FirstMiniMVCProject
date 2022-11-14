using FirstMVCProject.Models;

namespace FirstMVCProject.Repositories
{
    public class GenericRepository<T> where T : class

    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }


        public void Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            dbContext.Set<T>().Update(entity);
            dbContext.SaveChanges();

        }
        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }

      

   
}
}
