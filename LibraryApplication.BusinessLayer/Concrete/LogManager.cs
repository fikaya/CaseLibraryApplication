using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Concrete
{
   public class LogManager : ServiceResultSetting<Log>, ILogManager<Log>
    {
        private readonly ILogRepository<Log> _repository;
        public LogManager(ILogRepository<Log> logRepository)
        {
            _repository = logRepository;
        }
        public ServiceResult Insert(Log obj)
        {
            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(obj);
            }
            catch (Exception ex)
            {
                _serviceResult.AddError(ex.Message);
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kayıt Yapılamadı.");

            return _serviceResult;
        }
    }
}
