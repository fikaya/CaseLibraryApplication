using LibraryApplication.BusinessLayer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface IGetListConditionalManager<T, U> where T : class where U : class
    {
      public ReturnValueServiceResult<List<T>> GetList(Expression<Func<U, bool>> where);
    }
}
