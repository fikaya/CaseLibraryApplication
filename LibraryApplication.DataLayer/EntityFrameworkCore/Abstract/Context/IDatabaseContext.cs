using LibraryApplication.Entities;
using LibraryApplication.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.ContextAbstract
{
   public interface IDatabaseContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorBook> AuthorBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<BookEditionNumber> BookEditionNumbers { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<EditionNumber> EditionNumbers { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
