using Microsoft.EntityFrameworkCore;
using ShopOnline.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories.Definition
{
    public class AbstractRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// Must write this ShopOnlineEventArgs class inside, because we need T variable.
        /// </summary>
        public class ShopOnlineEventArgs : EventArgs
        {
            public T Entity;

            public ShopOnlineEventArgs(T entity)
            {
                Entity = entity;
            }
        }

        public DbSet<T> DataSet;
        public ShopOnlineRepository Repository;
        public EventHandler<ShopOnlineEventArgs> onDelete;

        public AbstractRepository(ShopOnlineRepository repository)
        {
            DataSet = repository.DBContext.Set<T>();
            Repository = repository;
        }

    }
}
