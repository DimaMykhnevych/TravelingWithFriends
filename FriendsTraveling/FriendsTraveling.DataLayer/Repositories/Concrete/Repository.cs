using FriendsTraveling.DataLayer.DbContext;
using FriendsTraveling.DataLayer.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
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
            Context.Set<TEntity>().Update(entity);
            await Save();
        }

        public async Task Save()
        {
            await Context.SaveChangesAsync();
        }

    }
}
