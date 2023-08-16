using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.ServiceResults
{
    public class ReturnValueServiceResult<T>:BaseServiceResult
    {
        public T Data { get; set; }
    }
}
