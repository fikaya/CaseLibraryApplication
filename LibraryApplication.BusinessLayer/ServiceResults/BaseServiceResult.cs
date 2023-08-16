using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.ServiceResults
{
    public class BaseServiceResult
    {
        public BaseServiceResult()
        {
            Errors = new List<string>();
        }
        public bool IsError { get; set; }
        public List<string> Errors { get; }
        public void AddError(string errorMessage)
        {
            IsError = true;
            Errors.Add(errorMessage);
        }
    }
}
