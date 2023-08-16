using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Filters
{
    public class ExceptionManagmentFilter : IExceptionFilter
    {
        private readonly ILogManager<Log> _logManager;
        public ExceptionManagmentFilter(ILogManager<Log> logManager)
        {
            _logManager = logManager;
        }
        public void OnException(ExceptionContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.RouteValues["controller"];
            string action = filterContext.ActionDescriptor.RouteValues["action"];
            //İsteğin atıldığı adresi bana verecek.
            string path = filterContext.HttpContext.Request.Path.Value;

            string userName = "Bilinmiyor.";

            _logManager.Insert
              (
                          new Log()
                          {
                              UserName = userName,
                              ActionName = action,
                              ControllerName = controller,
                              Path = path,
                              Date = DateTime.Now,
                              Description = "Error:" + filterContext.Exception.Message
                          }
             );

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/ErrorPageManagment/ErrorPage?code=500");
        }
    }
}
