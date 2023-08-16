﻿using LibraryApplication.DataLayer.Abstract.Repository;
using LibraryApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository
{
    public interface ILogRepository<T>
    {
        int Insert(T obj);
    }
}
