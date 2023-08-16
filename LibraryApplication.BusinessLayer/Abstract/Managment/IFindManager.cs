using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract.Managment
{
    public interface IFindManager<T, U> where T : class where U : class
    {
        public ReturnValueServiceResult<T> Find(Expression<Func<U, bool>> where);
     }
}
