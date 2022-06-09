using ripo_using_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace crud_using_ripository_pattern.DAL
{

    public class Ripository<T> : IAllRipository<T> where T : class
    {
        private mydbContext context;
        private DbSet<T> dbentity;


        public Ripository()
        {
            context = new mydbContext();
            dbentity = context.Set<T>();
        }

        public IEnumerable<T> All()
        {
            return context.Set<T>().ToList();
        }

        public void DeleteModel(int id)
        {
            T Model = dbentity.Find(id);
            dbentity.Remove(Model);
        }

        public T getModel(int modelid)
        {
            return dbentity.Find(modelid);
        }

        public void InsertModel(T model)
        {
            dbentity.Add(model);
        }

        public void save()
        {
            context.SaveChanges();
        }

        public IQueryable<T> spexecution(string SpName, params object[] parameters)
        {
            return context.Set<T>().FromSqlRaw(SpName, parameters);
        }
        public void UpdateModel(T model)
        {
            context.Entry(model).State = EntityState.Modified;
        }


    }
}