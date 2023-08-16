using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Constans;
using LibraryApplication.Entities.Dtos;
using LibraryApplication.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Controllers
{
    public class BookEditionNumberController : Controller
    {
        IBookManager _bookManager;
        IBookEditionNumberManager _bookEditionNumberManager;
        IEditionNumberManager _editionNumberManager;

        public BookEditionNumberController(IBookManager bookManager, IEditionNumberManager editionNumberManager, IBookEditionNumberManager bookEditionNumberManager)
        {
            _bookEditionNumberManager = bookEditionNumberManager;
            _bookManager = bookManager;
            _editionNumberManager = editionNumberManager;
        }
        private void GetEditionNumbers()
        {
            var editionNumbers = _editionNumberManager.GetList().Data;
            var selectListItem = editionNumbers.Select(x => new SelectListItem(x.EditionNumberBook, x.EditionNumberID.ToString())).ToList();
            ViewData["editionNumbers"] = selectListItem;
        }
        public IActionResult Index(int bookID)
        {
            var bookResult = _bookManager.Find(x => x.BookID == bookID);

            List<BookEditionNumberViewModel> bookEditionViewModels = new List<BookEditionNumberViewModel>();

            if (bookResult.Data != null)
            {
                var bookEditionResult = _bookEditionNumberManager.GetListReference(nameof(Book), nameof(EditionNumber));

                foreach (var item in bookEditionResult.Data)
                {
                    bookEditionViewModels.Add(new BookEditionNumberViewModel()
                    {
                        BookID = bookID,
                        BookName = item.BookName,
                        BookEditionNumberID=item.BookEditionNumberID,
                        EditionNumber = item.EditionNumber,
                        ISBN = item.ISBN,
                        NumberOfBook = item.NumberOfBook,
                        ReleaseDate = item.ReleaseDate,
                        ReleasePage = item.ReleasePage,
                        PicturePath = item.PicturePath
                    });
                }
                ViewBag.BookID = bookID;
                return View(bookEditionViewModels);
            }
            else
            {
                foreach (var item in bookResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, item);
                }
            }
            return View(bookEditionViewModels);
        }
        public IActionResult Create(int bookID)
        {
            var bookResult = _bookManager.Find(x => x.BookID == bookID);
            GetEditionNumbers();

            if (bookResult.Data != null)
            {
                ViewBag.BookID = bookID;
                return View();
            }
            else
            {
                return Redirect($"/BookEditionNumber/Index?bookID={bookID}");
            }
        }

        [HttpPost]
        public IActionResult Create(BookEditionNumberCrudViewModel bookEditionNumberCrudViewModel)
        {
            ViewBag.BookID = bookEditionNumberCrudViewModel.BookID;
            GetEditionNumbers();

            if (DateTime.Now < bookEditionNumberCrudViewModel.ReleaseDate)
            {
                ModelState.AddModelError(string.Empty, "Kitap Yayınlanma Tarihi Bugünden Büyük Olamaz.");
                return View(bookEditionNumberCrudViewModel);
            }

            if (bookEditionNumberCrudViewModel.EditionNumberID <= 0)
            {
                ModelState.Clear();
                ModelState.AddModelError(string.Empty, "Lütfen Basım Numarasını Seçiniz.");
            }

            if (ModelState.IsValid)
            {
                var editionNumber = _editionNumberManager.Find(x => x.EditionNumberID == bookEditionNumberCrudViewModel.EditionNumberID);

                if (editionNumber.Data == null)
                {
                    ModelState.AddModelError(string.Empty, "Seçilen Kitap Numarası Değeri Geçerli Değil.");

                    return View(bookEditionNumberCrudViewModel);
                }

                var bookEditionNumber = _bookEditionNumberManager.Find(x => x.EditionNumberID == bookEditionNumberCrudViewModel.EditionNumberID && x.BookID == bookEditionNumberCrudViewModel.BookID);

                if (bookEditionNumber.Data != null)
                {
                    ModelState.AddModelError(string.Empty, " Bu Kitap Basım Numarası İlgili Kitap İçin Daha Önceden Kayıt Edilmiş.Başka Bir Kitap Basım Numarasını Deneyebilirsiniz.");

                    return View(bookEditionNumberCrudViewModel);
                }

                if (bookEditionNumberCrudViewModel.NumberOfBook <= 0 || bookEditionNumberCrudViewModel.ReleasePage <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Eksili Değer Girmeyiniz.");
                    return View(bookEditionNumberCrudViewModel);
                }

                var isbnValue = _bookEditionNumberManager.Find(x => x.ISBN == bookEditionNumberCrudViewModel.ISBN);

                if (isbnValue.Data != null)
                {
                    ModelState.AddModelError(string.Empty, "Kayıt Edilmeye Çalışılan ISBN Numarası Daha Önceden Girildi.");
                    return View(bookEditionNumberCrudViewModel);
                }

                BookEditionNumberCrudDto bookEditionNumberCrudDto = new BookEditionNumberCrudDto()
                {
                    BookID = bookEditionNumberCrudViewModel.BookID,
                    EditionNumberID = bookEditionNumberCrudViewModel.EditionNumberID,
                    ISBN = bookEditionNumberCrudViewModel.ISBN,
                    NumberOfBook = bookEditionNumberCrudViewModel.NumberOfBook,
                    ReleaseDate = bookEditionNumberCrudViewModel.ReleaseDate,
                    ReleasePage = bookEditionNumberCrudViewModel.ReleasePage
                };

                var serviceResult = _bookEditionNumberManager.Insert(bookEditionNumberCrudDto);

                if (!serviceResult.IsError)
                {
                    return Redirect($"/BookEditionNumber/Index?bookID={bookEditionNumberCrudDto.BookID}");
                }

                foreach (string error in serviceResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

            }
            return View(bookEditionNumberCrudViewModel);
        }
    }
}
