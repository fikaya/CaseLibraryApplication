using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Models
{
    public class ServiceResult<T>
    {
        public ServiceResult()
        {
            Errors = new List<string>();
        }
        public bool IsError { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; }
        public void AddError(string errorMessage)
        {
            IsError = true;
            Errors.Add(errorMessage);
        }
    }
}
