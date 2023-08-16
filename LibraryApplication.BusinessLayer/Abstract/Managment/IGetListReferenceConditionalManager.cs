﻿using LibraryApplication.BusinessLayer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract.Managment
{
    public interface IGetListReferenceConditionalManager<T, U> where T : class where U : class
    {
        public ReturnValueServiceResult<List<T>> GetListReference(Expression<Func<U, bool>> where, params string[] referenceNames);
    }
}
