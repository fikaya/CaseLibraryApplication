using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using LibraryApplication.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Controllers
{
    public class ReservationController : Controller
    {
        IUserManager _userManager;
        IBookManager _bookManager;
        IBookEditionNumberManager _bookEditionNumberManager;
        IReservationManager _reservationManager;
        public ReservationController(IUserManager userManager, IBookEditionNumberManager bookEditionManager, IReservationManager reservationManager, IBookManager bookManager)
        {
            _bookManager = bookManager;
            _userManager = userManager;
            _bookEditionNumberManager = bookEditionManager;
            _reservationManager = reservationManager;
        }
        public IActionResult Index()
        {
            var reservations = _reservationManager.GetListReference(nameof(BookEditionNumber),nameof(LibraryApplication.Entities.User));

            List <ReservationViewModel> reservationViewModels = new List<ReservationViewModel>();

            foreach (var item in reservations.Data)
            {
                var bookEditions = _bookEditionNumberManager.GetListReference(x => x.BookEditionNumberID == item.BookEditionNumberID, nameof(Book),nameof(EditionNumber));

                ReturnValueServiceResult<List<BookDto>> books = new ReturnValueServiceResult<List<BookDto>>();

                foreach (var bookEditionDatas in bookEditions.Data)
                {
                    books = _bookManager.GetListReference(x => x.BookID == bookEditionDatas.BookID, nameof(Publisher));
                }

                reservationViewModels.Add(new ReservationViewModel()
                {
                    UserFullName = reservations.Data[0].UserName,
                    ISBN = bookEditions.Data[0].ISBN,
                    PubliserName = books.Data[0].PublisherName,
                    BookName = books.Data[0].BookName,
                    EditionNumberBook = bookEditions.Data[0].EditionNumber,
                    BookReceivedDate = item.BookReceivedDate,
                    DeliveryDate = item.DeliveryDate,
                    ReservationDate = item.ReservationDate
                });
            }
            return View(reservationViewModels);
        }

        public IActionResult Create(int editionNumberID)
        {
            var bookResult = _bookEditionNumberManager.Find(x => x.BookEditionNumberID == editionNumberID);
            GetUsers();
            if (bookResult.Data != null)
            {
                if (ViewBag.BookEditionNumberID!=null)
                {
                    editionNumberID = (int)ViewBag.BookEditionNumberID;
                }
                else
                {
                    ViewBag.BookEditionNumberID = editionNumberID;
                }
                ViewBag.BookEditionNumberID = editionNumberID;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private void GetUsers()
        {
            var users = _userManager.GetList().Data;
            var selectListItem = users.Select(x => new SelectListItem(x.UserFullName, x.UserID.ToString())).ToList();
            ViewData["users"] = selectListItem;
        }

        [HttpPost]
        public IActionResult Create(ReservationCrudViewModel bookEditionNumberCrudViewModel)
        {
            ViewBag.BookEditionNumberID = bookEditionNumberCrudViewModel.BookEditionNumberID;
            GetUsers();
            var result = _reservationManager.GetList(x => (x.UserID == bookEditionNumberCrudViewModel.UserID&& DateTime.Today != bookEditionNumberCrudViewModel.ReservationDate.Date) && x.BookReceivedDate == null);
            if (result.Data.Count != 0)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Kullanıcı Daha Önce Kitap Aldığı İçin Teslim İşlemi Gerçekleşmeden Kitap Alamaz. ");
                return View(bookEditionNumberCrudViewModel);
            }
            if (bookEditionNumberCrudViewModel.UserID == 0)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Kullanıcı Seçmelisiniz.");
                return View(bookEditionNumberCrudViewModel);
            }
            if (DateTime.Today != bookEditionNumberCrudViewModel.ReservationDate.Date)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Rezervasyon Tarihi Sadece Bugün İçin Ayarlanabilir.");
                return View(bookEditionNumberCrudViewModel);
            }
            if (DateTime.Today >= bookEditionNumberCrudViewModel.DeliveryDate)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Kitap Teslim Tarihi Yarın Ve Sonrası İçin Ayarlanabilir.");
                return View(bookEditionNumberCrudViewModel);
            }
            if (ModelState.IsValid)
            {
                var bookEditionResult = _bookEditionNumberManager.Find(x => x.BookEditionNumberID == bookEditionNumberCrudViewModel.BookEditionNumberID);

                if (bookEditionResult.Data == null)
                {
                    foreach (var error in bookEditionResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return View(bookEditionNumberCrudViewModel);
                }
                if (bookEditionResult.Data.NumberOfBook == 0)
                {
                    ModelState.Clear();
                    foreach (var error in bookEditionResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, "Adet Sayısı Rezervasyon İçin Yetersiz.");
                    }
                    return View(bookEditionNumberCrudViewModel);
                }

                var userResult = _userManager.Find(x => x.UserID == bookEditionNumberCrudViewModel.UserID);

                if (userResult.Data == null)
                {
                    foreach (var error in userResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return View(bookEditionNumberCrudViewModel);
                }

                ReservationCrudDto reservationCrudDto = new ReservationCrudDto()
                {
                    BookEditionNumberID = bookEditionNumberCrudViewModel.BookEditionNumberID,
                    DeliveryDate = bookEditionNumberCrudViewModel.DeliveryDate,
                    UserID = bookEditionNumberCrudViewModel.UserID,
                    ReservationDate = bookEditionNumberCrudViewModel.ReservationDate,
                };

                var serviceResult = _reservationManager.Insert(reservationCrudDto);

                if (serviceResult.Errors.Count == 0)
                {
                    int stock = bookEditionResult.Data.NumberOfBook - 1;

                    var model = _bookEditionNumberManager.GetList(x =>x.BookEditionNumberID == reservationCrudDto.BookEditionNumberID);

                    BookEditionNumberCrudDto bookEditionNumberCrudDto = new BookEditionNumberCrudDto();

                    foreach (var item in model.Data)
                    {
                        item.NumberOfBook = item.NumberOfBook - 1;

                        bookEditionNumberCrudDto = new BookEditionNumberCrudDto()
                        {
                            BookID = item.BookID,
                            BookEditionNumberID = item.BookEditionNumberID,
                            EditionNumberID = item.EditionNumberID,
                            NumberOfBook =item.NumberOfBook,
                            ISBN = item.ISBN,
                            ReleaseDate = item.ReleaseDate,
                            PicturePath = item.PicturePath
                        };
                    }

                    _bookEditionNumberManager.Update(bookEditionNumberCrudDto);

                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (string item in serviceResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    return View(bookEditionNumberCrudViewModel);
                }

            }
            return View(bookEditionNumberCrudViewModel);
        }
    }
}
