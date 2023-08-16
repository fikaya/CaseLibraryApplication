using LibraryApplication.BusinessLayer.ServiceResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract.Managment
{
    public interface IGetListCollectionManager<T> where T : class
    {
        public ReturnValueServiceResult<List<T>> GetListCollection(params string[] collectionNames);
    }
}
