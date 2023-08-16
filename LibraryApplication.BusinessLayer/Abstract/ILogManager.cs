using LibraryApplication.BusinessLayer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface ILogManager<T>
    {
        public ServiceResult Insert(T obj);
    }
}
