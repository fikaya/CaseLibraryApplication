using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.MsSql
{
    public class DatabaseInitializer
    {
        private AppSetting _appSetting;
        private MsSqlDatabaseContext _databaseContext = new MsSqlDatabaseContext();
        public DatabaseInitializer(AppSetting appSetting)
        {
            _appSetting = appSetting;
        }
        public void Seed()
        {
            if (_databaseContext.Admins.Any(x => x.UserName == _appSetting.AdminUserName) == false)
            {
                //Proje her çalıştığında aynı kişinin tekrar tekrar eklenmemesi için Any ile kontrol yaptık.
                _databaseContext.Add(
                    new Admin()
                    {
                        UserName = _appSetting.AdminUserName,
                        Password = _appSetting.AdminPassword,
                        AdminEMail = _appSetting.AdminEMail,
                    }
                    );
            }
            if (_databaseContext.Authors.Any() == false && _databaseContext.Publishers.Any() == false)
            {
                //Proje her çalıştığında aynı kişinin tekrar tekrar eklenmemesi için Any ile kontrol yaptık.
                for (int i = 0; i < 10; i++)
                {
                    _databaseContext.Add(
                new Author()
                {
                    AuthorName = MFramework.Services.FakeData.NameData.GetFirstName(),
                    AuthorSurname = MFramework.Services.FakeData.NameData.GetSurname(),
                }
                );
                }

                for (int i = 0; i < 10; i++)
                {
                    _databaseContext.Add(
                new Publisher()
                {
                    PublisherName = MFramework.Services.FakeData.NameData.GetCompanyName(),
                }
                );
                }
            }
            _databaseContext.SaveChanges();
            if (_databaseContext.EditionNumbers.Any() == false)
            {
                for (int i = 1; i < 1000; i++)
                {
                    _databaseContext.Add(
                   new EditionNumber()
                   {
                       EditionNumberBook = i + ".Basım"
                   });
                }
            }
            _databaseContext.SaveChanges();
        }
    }
}
