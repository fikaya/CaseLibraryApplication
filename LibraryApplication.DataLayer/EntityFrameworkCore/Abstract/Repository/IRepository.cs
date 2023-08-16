using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.Abstract.Repository
{
   public interface IRepository<T>
    {
        //T tipinde bir liste dmönüşü sağlayacağım.
        List<T> List();
        //T tipinde bir liste dönüşü sağlayacağım.Ancak bir koşula göre dönüş sağlayacağım.
        List<T> List(Expression<Func<T, bool>> where);
        //T tipinde bir IQueryable dönüşü sağlayacağım.Çünkü bu sorguyu direkt çalıştırmadan üstüne başka şeyler ekleyerek çalıştırmak isteyebiliriz.IQueryable da tüm işlemler Sql de gerçekleşir.
        IQueryable<T> ListQueryable();
        //T tipinde bir IEnumerable dönüşü sağlayacağım.Çünkü bu sorguyu direkt çalıştırmadan üstüne başka şeyler ekleyerek çalıştırmak isteyebiliriz.IQueryable da tüm işlemler projenini belleğinde gerçekleşir. Yani tüm verileri içeriye çekerek burada filtreleme yapılır.
        IEnumerable<T> ListEnumerable();
        //Eager Loading işlemlerinde ilgili Navigation Property isimlerini yazarak bir join işlemi yapmış oluruz.
        List<T> ListCollection(params string[] collectionNames);
        //Eager Loading işlemlerinde ilgili Navigation Property isimlerini yazarak bir join işlemi yapmış oluruz.Bunları şart belirterek çekmek istediğim için böyle yaptım.
        List<T> ListCollection(Expression<Func<T, bool>> where, params string[] collectionNames);
        //Eager Loading işlemlerinde ilgili Navigation Property isimlerini yazarak bir join işlemi yapmış oluruz.
        List<T> ListReference(params string[] referenceNames);
        //Eager Loading işlemlerinde ilgili Navigation Property isimlerini yazarak bir join işlemi yapmış oluruz.Bunları şart belirterek çekmek istediğim için böyle yaptım.
        List<T> ListReference(Expression<Func<T, bool>> where, params string[] referenceNames);
        //İlgili Entity değerini bulmak için kullanırız.
        T Find(Expression<Func<T, bool>> where);
        //Crud işlemlerinde kayıtlar olmuş ise 0 olmamış ise 1 döner.
        int Insert(T obj);
        int Update(T obj);
        int Delete(T obj);
    }
}
