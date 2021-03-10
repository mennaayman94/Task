using BackEnd.Models;
using BackEnd.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackEnd.RepositoryImp
{
    //Implementation of Irepository
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly QualityStandardEntities DB;
        public Repository(QualityStandardEntities db)
        {
            DB = db;
            DbSet = DB.Set<TEntity>();
        }
        public TEntity Add(TEntity entity)
        {
            var ent = DB.Set<TEntity>().Add(entity);
            DB.SaveChanges();
            return ent;

        }

        public void Edit(TEntity entity)
        {

            DB.Entry(entity).State = EntityState.Modified;
            DB.SaveChanges();


        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public TEntity GetById(int id)
        {
            var result = DB.Set<TEntity>().Find(id);
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public  void Remove(TEntity entity)
        {
            
                DB.Set<TEntity>().Remove(entity);

                DB.SaveChanges();

            
            


        }
    }
}