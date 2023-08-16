using LibraryApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.ServiceResults
{
    public class ServiceResultSetting<T>
    {
        protected readonly ServiceResult _serviceResult = new ServiceResult();
        protected ReturnValueServiceResult<T> _returnValueServiceResultFind = new ReturnValueServiceResult<T>();
        protected readonly
            ReturnValueServiceResult<List<T>> _returnValueServiceResultList = new ReturnValueServiceResult<List<T>>();
        protected readonly
            ReturnValueServiceResult<IEnumerable<T>> _returnValueServiceIEnumerable = new ReturnValueServiceResult<IEnumerable<T>>();
        protected readonly
           ReturnValueServiceResult<IQueryable<T>> _returnValueServiceIQueryable = new ReturnValueServiceResult<IQueryable<T>>();
    }
}
