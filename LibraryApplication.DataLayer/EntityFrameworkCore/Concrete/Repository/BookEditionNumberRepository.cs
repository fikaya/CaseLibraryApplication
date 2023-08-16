using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Base;
using LibraryApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Repository
{
    public class BookEditionNumberRepository :
        BaseRepository<BookEditionNumber, MsSqlDatabaseContext>, IBookEditionNumberRepository
    {

    }
}
