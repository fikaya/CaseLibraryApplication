using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using LibraryApplication.Entities.Entities;
using LibraryApplication.WebApp.Filters;
using LibraryApplication.WebApp.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.WebApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;
        private readonly IPublisherManager _publisherManager;
        private readonly IAuthorBookManager _authorBookManager;
        private readonly IAuthorManager _authorManager;

        public BookController(IBookManager bookManager, IPublisherManager publisherManager, IAuthorBookManager authorBookManager, IAuthorManager authorManager)
        {
            _publisherManager = publisherManager;
            _bookManager = bookManager;
            _authorBookManager = authorBookManager;
            _authorManager = authorManager;
        }
        public IActionResult Index()
        {
            var list = _bookManager.GetListReference(nameof(Publisher));
            List<BookViewModel> bookViewModels = new List<BookViewModel>();
            foreach (var item in list.Data)
            {
                bookViewModels.Add(new BookViewModel()
                {
                    BookID=item.BookID,
                    BookName = item.BookName,
                    PublisherName = item.PublisherName
                });
            }
            return View(bookViewModels);
        }

        public IActionResult Create()
        {
            GetAuthors();
            GetPublishers();
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCrudViewModel bookCreateViewModel, List<int> authorID)
        {
            GetAuthors();
            GetPublishers();
            ModelState.Remove(nameof(bookCreateViewModel.PublisherName));
            if (ModelState.IsValid)
            {
                List<ReturnValueServiceResult<AuthorDto>> authorResults = new List<ReturnValueServiceResult<AuthorDto>>();

                for (int i = 0; i < authorID.Count; i++)
                {
                    var authorResult = _authorManager.Find(x => x.AuthorID == bookCreateViewModel.AuthorID);
                    if (authorResult.Data != null)
                    {
                        //İki kayıt da bulundu ise iki kere eklenecek. Ama eğer biri bulunamadı veya ikisi bulunamadı ise authorResults ve authorID count değerlerini aynı olmayacak
                        authorResults.Add(authorResult);
                    }
                }

                if (authorResults.Count != authorID.Count)
                {
                    foreach (var item in authorResults)
                    {
                        foreach (var error in item.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error);
                        }
                    }
                    return View(bookCreateViewModel);
                }

                var publisherResult = _publisherManager.Find(x => x.PublisherID == bookCreateViewModel.PublisherID);

                if (publisherResult.Data != null)
                {
                    var bookResult = _bookManager.Find(x => x.BookName.ToUpper() == bookCreateViewModel.BookName.ToUpper() && x.PublisherID == bookCreateViewModel.PublisherID);

                    if (bookResult.Data != null)
                    {
                        ModelState.AddModelError(string.Empty, "Aynı Kitap Ve Yayınevi Daha Önceden Kayıt Edilmiş.");
                        return View(bookCreateViewModel);
                    }
                    else
                    {
                        BookCrudDto bookCrudDto = new BookCrudDto()
                        {
                            BookName = bookCreateViewModel.BookName,
                            PublisherID = bookCreateViewModel.PublisherID
                        };

                        var serviceResult = _bookManager.Insert(bookCrudDto);

                        if (serviceResult.Errors.Count == 0)
                        {
                            //Kayıt edilen Book u çektik.
                            var book = _bookManager.Find(x => x.BookName.ToUpper() == bookCrudDto.BookName.ToUpper() && x.PublisherID == bookCrudDto.PublisherID);
                            //Yani kitap kayıt altına alındıysa Index e git demiş oldum.
                            //Ama gitmeden önce kayıt edilen kitabı bulup AuthorBook tablosuna da kayıt yaptıracağım.
                            foreach (var item in authorID)
                            {
                                AuthorBookDto authorBookDto = new AuthorBookDto()
                                {
                                    BookID = book.Data.BookID,
                                    AuthorID = item
                                };

                                var authorBookManagerServiceResult = _authorBookManager.Insert(authorBookDto);

                                if (serviceResult.Errors.Count != 0)
                                {
                                    ModelState.AddModelError(string.Empty, "Kitabın Yazar Kaydı Oluşturulamadığı İçin Kitap Eklenemedi.");

                                   
                                    //Author Book tablosuna kayıt oluşturulamadığı için kitabı da silmiş olduk.
                                    _bookManager.Delete(new BookCrudDto() { BookID = book.Data.BookID });
                                    return View(bookCreateViewModel);
                                }
                            }
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            foreach (string item in serviceResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item);
                            }
                            return View(bookCreateViewModel);
                        }
                    }
                }
                else
                {
                    foreach (string item in publisherResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item);
                    }
                    return View(bookCreateViewModel);
                }
            }
            else if (bookCreateViewModel.PublisherID == 0 && bookCreateViewModel.AuthorID == 0)
            {
                //İki select box ın seçilmediği durumu canlandırıyoruz.
                ModelState.Remove(nameof(bookCreateViewModel.PublisherID));
                ModelState.Remove(nameof(bookCreateViewModel.AuthorID));
                ModelState.AddModelError(string.Empty, "Lütfen Yayınevi Seçiniz.");
                ModelState.AddModelError(string.Empty, "Lütfen Yazar Seçiniz.");
                return View(bookCreateViewModel);
            }
            else if (bookCreateViewModel.PublisherID != 0 && bookCreateViewModel.AuthorID == 0)
            {
                ModelState.Remove(nameof(bookCreateViewModel.AuthorID));
                ModelState.AddModelError(string.Empty, "Lütfen Yazar Seçiniz.");
                return View(bookCreateViewModel);
            }
            else
            {
                ModelState.Remove(nameof(bookCreateViewModel.PublisherID));
                ModelState.AddModelError(string.Empty, "Lütfen Yayınevi Seçiniz.");
                return View(bookCreateViewModel);
            }
        }
        private void GetPublishers()
        {
            var publishers = _publisherManager.GetList().Data;
            var selectListItem = publishers.Select(x => new SelectListItem(x.PublisherName, x.PublisherID.ToString())).ToList();
            ViewData["publishers"] = selectListItem;
        }
        private void GetAuthors()
        {
            var authors = _authorManager.GetList().Data;
            var selectListItem = authors.Select(x => new SelectListItem(x.AuthorName + " " + x.AuthorSurname, x.AuthorID.ToString())).ToList();
            ViewData["authors"] = selectListItem;
        }
    }
}
