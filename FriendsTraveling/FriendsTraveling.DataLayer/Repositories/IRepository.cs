﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsTraveling.DataLayer.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();

        Task Insert(TEntity entity);

        Task Delete(TEntity entity);

        Task Update(TEntity entity);

        Task Save();


    }
}