using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Repository
{
    public class LogRepository : ILogRepository<Log>
    {
        private MsSqlDatabaseContext _dbContext = new MsSqlDatabaseContext();
        private DbSet<Log> _objectSet;

        public LogRepository()
        {
            _objectSet = _dbContext.Set<Log>();
        }
        public int Insert(Log obj)
        {
            _objectSet.Add(obj);
            return Save();
        }
        private int Save()
        {
            return _dbContext.SaveChanges();
        }
    }
}
