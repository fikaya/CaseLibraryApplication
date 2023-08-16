using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.Concrete;
using LibraryApplication.DataLayer.Abstract.Repository;
using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Base;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.MsSql;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Repository;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Entities;
using LibraryApplication.WebApp.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddControllersWithViews(config => config.Filters.Add(typeof(ExceptionManagmentFilter)));

            //Normalde Presentation katmanýnýn DataLayer kýsmýna ulaþmamasý gerek. Þuan için böyle kalacak. Ýleride araþtýrýlýp bir yöntem bulunacak.

            services.AddTransient<IRepository<Book>, BaseRepository<Book, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<BookEditionNumber>, BaseRepository<BookEditionNumber, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<AuthorBook>, BaseRepository<AuthorBook, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<Author>, BaseRepository<Author, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<Reservation>, BaseRepository<Reservation, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<EditionNumber>, BaseRepository<EditionNumber, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<User>, BaseRepository<User, MsSqlDatabaseContext>>();
            services.AddTransient<IRepository<Publisher>, BaseRepository<Publisher, MsSqlDatabaseContext>>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookEditionNumberRepository, BookEditionNumberRepository>();
            services.AddTransient<IAuthorBookRepository, AuthorBookRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IReservationRepository, ReservationRepository>();
            services.AddTransient<IEditionNumberRepository, EditionNumberRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPublisherRepository, PublisherRepository>();
            services.AddTransient<ILogRepository<Log>, LogRepository>();

            services.AddTransient<ILogManager<Log>, LogManager>();
            services.AddTransient<IBookManager, BookManager>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<IReservationManager, ReservationManager>();
            services.AddTransient<IBookEditionNumberManager, BookEditionNumberManager>();
            services.AddTransient<IAuthorBookManager, AuthorBookManager>();
            services.AddTransient<IAuthorManager, AuthorManager>();
            services.AddTransient<IPublisherManager, PublisherManager>();
            services.AddTransient<IEditionNumberManager, EditionNumberManager>();

            //Configuration dosyasýndan Json tipindeki dosyamdan verileri okuyacaðým. Burada bir class yapýsý olarak direkt çekmek istediðim için aþaðýdaki gibi oluþturdum.nameof keywordü kullanmaktaki amaç ise magic string ifadelerden kurtulmaktýr.
            var appSetting = Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();

            //DatabaseContext üretiminde Dependency Inversion Prensibinine uygun olarak Dependency Injection Pattern ý kullandýðýmýz için sistem tarafýndan newlenerek bize sunulacak.Ondan dolayý herhangi bir þey göndermedik.
            var databaseInitializer = new DatabaseInitializer(appSetting);
            databaseInitializer.Seed();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Parametre olarak code üzerinden bir parametre alacak ve geriye bir View dönecek.
            app.UseStatusCodePagesWithReExecute("/ErrorPageManagment/ErrorPage", "?code={0}");

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
