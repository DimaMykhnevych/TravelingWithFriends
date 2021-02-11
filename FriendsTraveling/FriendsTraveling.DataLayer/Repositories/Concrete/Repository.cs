using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TravelingDbContext Context;
        public Repository(TravelingDbContext context)
        {
            Context = context;
        }
        public async Task<TEntity> Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public async Task<TEntity> Insert(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public async Task Update(TEntity entity)
        {
            //Context.Entry(entity).State = EntityState.Modified;
            Context.Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
