using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryApplication.BusinessLayer.Concrete
{
    public class BookManager : ServiceResultSetting<BookDto>, IBookManager
    {
        private readonly IBookRepository _repository;
        public BookManager(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }
        public ServiceResult Delete(BookCrudDto bookDto)
        {
            var book = new Book()
            {
                BookID = bookDto.BookID,
            };

            int serviceResult = 0;

            try
            {
                var value = _repository.Find(x => x.BookID == book.BookID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Kitap Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(BookCrudDto bookDto)
        {
            var book = new Book()
            {
                BookName = bookDto.BookName,
                PublisherID = bookDto.PublisherID
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(book);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(BookCrudDto bookDto)
        {
            var book = new Book()
            {
                BookName = bookDto.BookName,
                PublisherID = bookDto.PublisherID
            };
            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Update(book);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Yazar Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<BookDto> Find(Expression<Func<Book, bool>> where)
        {
            Book book;
            try
            {
                book = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (book == null)
                _returnValueServiceResultFind.AddError("Kitap Yazar Kaydı Bulunamadı.");
            else
            {
                BookDto bookDto = new BookDto()
                {
                    BookID=book.BookID,
                    BookName = book.BookName,
                    PublisherID = book.PublisherID
                };
                _returnValueServiceResultFind.Data = bookDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<BookDto>> GetList()
        {
            List<BookDto> bookDtoList;
            try
            {
                var bookList = _repository.List();
                bookDtoList = new List<BookDto>();

                foreach (var item in bookList)
                {
                    bookDtoList.Add(new BookDto()
                    {
                        BookName = item.BookName,
                        PublisherID = item.PublisherID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookDtoList;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<BookDto>> GetList(Expression<Func<Book, bool>> where)
        {
            List<BookDto> bookDtoList;
            try
            {
                var bookList = _repository.List(where);
                bookDtoList = new List<BookDto>();

                foreach (var item in bookList)
                {
                    bookDtoList.Add(new BookDto()
                    {
                        BookName = item.BookName,
                        PublisherID = item.PublisherID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookDtoList;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<BookDto>> GetListReference(params string[] referenceNames)
        {
            List<BookDto> bookDtoList;
            try
            {
                var bookList = _repository.ListReference(referenceNames);

                bookDtoList = new List<BookDto>();

                foreach (var item in bookList)
                {
                    bookDtoList.Add(new BookDto()
                    {
                        BookID=item.BookID,
                        BookName = item.BookName,
                        PublisherID = item.PublisherID,
                        PublisherName = item.Publisher.PublisherName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookDtoList;

            return _returnValueServiceResultList;

        }
        public ReturnValueServiceResult<List<BookDto>> GetListReference(Expression<Func<Book, bool>> where, params string[] referenceNames)
        {
            List<BookDto> bookDtoList;
            try
            {
                var bookList = _repository.ListReference(where, referenceNames);

                bookDtoList = new List<BookDto>();

                foreach (var item in bookList)
                {
                    bookDtoList.Add(new BookDto()
                    {
                        BookID = item.BookID,
                        BookName = item.BookName,
                        PublisherID = item.PublisherID,
                        PublisherName = item.Publisher.PublisherName
                    });
                }
            }
            catch (Exception)
            {
                throw;
             }

            _returnValueServiceResultList.Data = bookDtoList;

            return _returnValueServiceResultList;

        }
 
    }
}
