using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ioc.Core.Entities;

namespace Ioc.Data.Redis
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// get entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity GetEntity(long id);
        /// <summary>
        /// get all
        /// </summary>
        /// <returns></returns>
        IList<TEntity> GetAll();
        /// <summary>
        /// store entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity Store(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        void StoreAll(IList<TEntity> list);
    }
}
