using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Concrete
{
    public class BookEditionNumberManager :ServiceResultSetting<BookEditionNumberDto>,IBookEditionNumberManager
    {
        private readonly IBookEditionNumberRepository _repository;
        public BookEditionNumberManager(IBookEditionNumberRepository bookEditionNumberRepository)
        {
            _repository = bookEditionNumberRepository;
        }
        public ServiceResult Delete(BookEditionNumberCrudDto bookEditionNumberDto)
        {
            var bookEditionNumber = new BookEditionNumberCrudDto()
            {
                BookEditionNumberID=bookEditionNumberDto.BookEditionNumberID,
            };

            int serviceResult = 0;

            try
            {
                var value = _repository.Find(x => x.BookEditionNumberID == bookEditionNumber.BookEditionNumberID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Kitap Basım Numarası Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Basım Numarası Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(BookEditionNumberCrudDto bookEditionNumberDto)
        {
            var bookEditionNumber = new BookEditionNumber()
            {
                BookID = bookEditionNumberDto.BookID,
                EditionNumberID = bookEditionNumberDto.EditionNumberID,
                ISBN = bookEditionNumberDto.ISBN,
                NumberOfBook = bookEditionNumberDto.NumberOfBook,
                ReleasePage = bookEditionNumberDto.ReleasePage,
                ReleaseDate = bookEditionNumberDto.ReleaseDate,
                PicturePath = bookEditionNumberDto.PicturePath
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(bookEditionNumber);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Basım Numarası Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(BookEditionNumberCrudDto bookEditionNumberDto)
        {
            var bookEditionNumber = new BookEditionNumber()
            {
                BookID = bookEditionNumberDto.BookID,
                EditionNumberID = bookEditionNumberDto.EditionNumberID,
                ISBN = bookEditionNumberDto.ISBN,
                NumberOfBook = bookEditionNumberDto.NumberOfBook,
                ReleasePage = bookEditionNumberDto.ReleasePage,
                ReleaseDate = bookEditionNumberDto.ReleaseDate,
                PicturePath = bookEditionNumberDto.PicturePath
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(bookEditionNumber);
            }
            catch (Exception ex)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Basım Numarası Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<BookEditionNumberDto> Find(Expression<Func<BookEditionNumber, bool>> where)
        {
            BookEditionNumber bookEditionNumber;
            try
            {
                bookEditionNumber = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (bookEditionNumber == null)
                _returnValueServiceResultFind.AddError("Kitap Basım Numarası Kaydı Bulunamadı.");
            else
            {
                BookEditionNumberDto BookEditionNumberDto = new BookEditionNumberDto()
                {
                    BookEditionNumberID= bookEditionNumber.BookEditionNumberID,
                    BookID = bookEditionNumber.BookEditionNumberID,
                    EditionNumberID = bookEditionNumber.BookEditionNumberID,
                    ISBN = bookEditionNumber.ISBN,
                    NumberOfBook = bookEditionNumber.NumberOfBook,
                    ReleasePage = bookEditionNumber.ReleasePage,
                    ReleaseDate = bookEditionNumber.ReleaseDate,
                    PicturePath = bookEditionNumber.PicturePath
                };
                _returnValueServiceResultFind.Data = BookEditionNumberDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<BookEditionNumberDto>> GetList()
        {
            List<BookEditionNumberDto>  bookEditionNumberDtos;
            try
            {
                var  bookEditionNumbers = _repository.List();
                bookEditionNumberDtos = new List<BookEditionNumberDto>();

                foreach (var item in bookEditionNumbers)
                {
                    bookEditionNumberDtos.Add(new BookEditionNumberDto()
                    {
                        BookEditionNumberID = item.BookEditionNumberID,
                        BookID = item.BookEditionNumberID,
                        EditionNumberID = item.BookEditionNumberID,
                        ISBN = item.ISBN,
                        NumberOfBook = item.NumberOfBook,
                        ReleasePage = item.ReleasePage,
                        ReleaseDate = item.ReleaseDate,
                        PicturePath = item.PicturePath
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookEditionNumberDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<BookEditionNumberDto>> GetList(Expression<Func<BookEditionNumber, bool>> where)
        {
            List<BookEditionNumberDto>  bookEditionNumberDtos;
            try
            {
                var  bookEditionNumbers = _repository.List(where);
                bookEditionNumberDtos = new List<BookEditionNumberDto>();

                foreach (var item in bookEditionNumbers)
                {
                    bookEditionNumberDtos.Add(new BookEditionNumberDto()
                    {
                        BookEditionNumberID = item.BookEditionNumberID,
                        BookID = item.BookEditionNumberID,
                        EditionNumberID = item.BookEditionNumberID,
                        ISBN = item.ISBN,
                        NumberOfBook = item.NumberOfBook,
                        ReleasePage = item.ReleasePage,
                        ReleaseDate = item.ReleaseDate,
                        PicturePath = item.PicturePath
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookEditionNumberDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<BookEditionNumberDto>> GetListReference(params string[] referenceNames)
        {
            List<BookEditionNumberDto>  bookEditionNumberDtos;
            try
            {
                var  bookEditionNumbers = _repository.ListReference(referenceNames);

                bookEditionNumberDtos = new List<BookEditionNumberDto>();

                foreach (var item in bookEditionNumbers)
                {
                    bookEditionNumberDtos.Add(new BookEditionNumberDto()
                    {
                        BookEditionNumberID = item.BookEditionNumberID,
                        EditionNumber=item.EditionNumber.EditionNumberBook,
                        BookName = item.Book.BookName,
                        BookID = item.BookEditionNumberID,
                        EditionNumberID = item.BookEditionNumberID,
                        ISBN = item.ISBN,
                        NumberOfBook = item.NumberOfBook,
                        ReleasePage = item.ReleasePage,
                        ReleaseDate = item.ReleaseDate,
                        PicturePath = item.PicturePath
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookEditionNumberDtos;

            return _returnValueServiceResultList;

        }
        public ReturnValueServiceResult<List<BookEditionNumberDto>> GetListReference(Expression<Func<BookEditionNumber, bool>> where, params string[] referenceNames)
        {
            List<BookEditionNumberDto>  bookEditionNumberDtos;
            try
            {
                var  bookEditionNumbers = _repository.ListReference(where, referenceNames);

                bookEditionNumberDtos = new List<BookEditionNumberDto>();

                foreach (var item in bookEditionNumbers)
                {
                    bookEditionNumberDtos.Add(new BookEditionNumberDto()
                    {
                        BookEditionNumberID = item.BookEditionNumberID,
                        BookID = item.BookID,
                        EditionNumber = item.EditionNumber.EditionNumberBook,
                        BookName = item.Book.BookName,
                        EditionNumberID = item.BookEditionNumberID,
                        ISBN = item.ISBN,
                        NumberOfBook = item.NumberOfBook,
                        ReleasePage = item.ReleasePage,
                        ReleaseDate = item.ReleaseDate,
                        PicturePath = item.PicturePath
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = bookEditionNumberDtos;

            return _returnValueServiceResultList;
        }
    }
}
