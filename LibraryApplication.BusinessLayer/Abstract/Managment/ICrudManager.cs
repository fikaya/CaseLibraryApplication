using LibraryApplication.BusinessLayer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface ICrudManager<T> where T : class
    {
       public ServiceResult Insert(T obj);
        public ServiceResult Update(T obj);
        public ServiceResult Delete(T obj);
    }
}
