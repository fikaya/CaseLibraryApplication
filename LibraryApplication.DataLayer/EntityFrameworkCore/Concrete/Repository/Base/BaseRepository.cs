using LibraryApplication.DataLayer.Abstract.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Base
{
    public class BaseRepository<T, U> : IRepository<T>
        where T : class
        where U : DbContext, new()
    {
        private U _dbContext = new U();
        private DbSet<T> _objectSet;
        public BaseRepository()
        {
            //Set<T>() metodunun generic parametresine kullanıcı int gibi bir değer göndermemeli. Buraya sadece entity isimlerim gelmeli.Onun için bir constraint uygulayacağım. where T:Class diyerek bir kısıtlama getirdim.
            //Burada sonuç olarak Set<T>() metodundan bir DbSet<T> dönecek.
            //Burada User,Author gibi tabloları elde edeceğim.
            _objectSet = _dbContext.Set<T>();
        }

        #region Crud
        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public int Update(T obj)
        {
            if (_dbContext.Entry(obj).State == EntityState.Detached) //Concurrency için 
            {
                _objectSet.Attach(obj);
            }
            _dbContext.Entry(obj).State = EntityState.Modified;

            return Save();
        }
        private int Save()
        {
            return _dbContext.SaveChanges();
        }
        #endregion

        #region Tekil Kayit Bulma
        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
        #endregion

        #region Çoklu Kayit Bulma
        public List<T> List()
        {
            return _objectSet.ToList();
        }
        public List<T> List(Expression<Func<T, bool>> where)
        {
            var list = _objectSet.Where(where).ToList();
            return list;
        }
        #endregion     
        //Devam Ettirilecek Sorgu(Exe:Order By)

        #region 
        public IEnumerable<T> ListEnumerable()
        {
            return _objectSet.AsEnumerable();
        }
        public IQueryable<T> ListQueryable()
        {
            return _objectSet.AsQueryable();
        }
        #endregion

        #region EagerLoading
        public List<T> ListCollection(params string[] collectionNames)
        {
            List<T> list = List();

            foreach (var item in list)
            {
                for (int i = 0; i < collectionNames.Length; i++)
                {
                    _dbContext.Entry(item).Collection(collectionNames[i]).Load();
                }
            }
            return list;
        }

        public List<T> ListCollection(Expression<Func<T, bool>> where, params string[] collectionNames)
        {
            List<T> list;

            if (where != null)
                list = List(where);
            else
                list = List();

            foreach (var item in list)
            {
                for (int i = 0; i < collectionNames.Length; i++)
                {
                    _dbContext.Entry(item).Collection(collectionNames[i]).Load();
                }
            }
            return list;
        }

        public List<T> ListReference(params string[] referenceNames)
        {
            List<T> list = List();

            foreach (var item in list)
            {
                for (int i = 0; i < referenceNames.Length; i++)
                {
                    _dbContext.Entry(item).Reference(referenceNames[i]).Load();
                }
            }
            return list;
        }

        public List<T> ListReference(Expression<Func<T, bool>> where, params string[] referenceNames)
        {
            List<T> list;

            if (where != null)
                list = List(where);
            else
                list = List();

            foreach (var item in list)
            {
                for (int i = 0; i < referenceNames.Length; i++)
                {
                    _dbContext.Entry(item).Reference(referenceNames[i]).Load();
                }
            }
            return list;
        }
        #endregion

    }
}
