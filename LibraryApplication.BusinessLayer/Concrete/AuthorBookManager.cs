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
    public class AuthorBookManager : ServiceResultSetting<AuthorBookDto>, IAuthorBookManager
    {
        private readonly IAuthorBookRepository _repository;
        public AuthorBookManager(IAuthorBookRepository authorBookRepository)
        {
            _repository = authorBookRepository;
        }
        public ServiceResult Delete(AuthorBookDto authorBookDto)
        {
            var authorBook = new AuthorBook()
            {
                AuthorBookID= authorBookDto.AuthorBookID,
            };
            int serviceResult = 0;
            try
            {
                var value = _repository.Find(x => x.AuthorBookID == authorBook.AuthorBookID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Kitap Yazar Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Yazar Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(AuthorBookDto authorBookDto)
        {
            var authorBook = new AuthorBook()
            {
                AuthorID = authorBookDto.AuthorID,
                BookID = authorBookDto.BookID
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(authorBook);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Yazar Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(AuthorBookDto authorBookDto)
        {
            var authorBook = new AuthorBook()
            {
                AuthorBookID = authorBookDto.AuthorBookID,
                AuthorID = authorBookDto.AuthorID,
                BookID = authorBookDto.BookID
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(authorBook);
            }
            catch (Exception)
            {
                throw;  
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Yazar Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<AuthorBookDto> Find(Expression<Func<AuthorBook, bool>> where)
        {
            AuthorBook authorBook;
            try
            {
                authorBook = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (authorBook == null)
                _returnValueServiceResultFind.AddError("Kitap Yazar Kaydı Bulunamadı.");
            else
            {
                AuthorBookDto AuthorBookDto = new AuthorBookDto()
                {
                    AuthorBookID = authorBook.AuthorBookID,
                    AuthorID = authorBook.AuthorID,
                    BookID = authorBook.BookID
                };
                _returnValueServiceResultFind.Data = AuthorBookDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<AuthorBookDto>> GetList()
        {
            List<AuthorBookDto> authorBookDtoList;
            try
            {
                var  authorBooks = _repository.List();
                authorBookDtoList = new List<AuthorBookDto>();

                foreach (var item in authorBooks)
                {
                    authorBookDtoList.Add(new AuthorBookDto()
                    {
                        AuthorBookID = item.AuthorBookID,
                        AuthorID = item.AuthorID,
                        BookID = item.BookID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorBookDtoList;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<AuthorBookDto>> GetList(Expression<Func<AuthorBook, bool>> where)
        {
            List<AuthorBookDto> authorBookDtos;
            try
            {
                var authorBooks = _repository.List(where);
                authorBookDtos = new List<AuthorBookDto>();

                foreach (var item in authorBooks)
                {
                    authorBookDtos.Add(new AuthorBookDto()
                    {
                        AuthorBookID = item.AuthorBookID,
                        AuthorID = item.AuthorID,
                        BookID = item.BookID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorBookDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<AuthorBookDto>> GetListReference(params string[] referenceNames)
        {
            List<AuthorBookDto> authorBookDtos;
            try
            {
                var authorBooks = _repository.ListReference(referenceNames);

                authorBookDtos = new List<AuthorBookDto>();

                foreach (var item in authorBooks)
                {
                    authorBookDtos.Add(new AuthorBookDto()
                    {
                        AuthorBookID = item.AuthorBookID,
                        BookName = item.Book.BookName,
                        BookID = item.BookID,
                        AuthorFullName = item.Author.AuthorName + " " + item.Author.AuthorSurname,
                        AuthorID = item.AuthorID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorBookDtos;

            return _returnValueServiceResultList;

        }
        public ReturnValueServiceResult<List<AuthorBookDto>> GetListReference(Expression<Func<AuthorBook, bool>> where, params string[] referenceNames)
        {
            List<AuthorBookDto> authorBookDtos;
            try
            {
                var authorBooks = _repository.ListReference(where, referenceNames);

                authorBookDtos = new List<AuthorBookDto>();

                foreach (var item in authorBooks)
                {
                    authorBookDtos.Add(new AuthorBookDto()
                    {
                        AuthorBookID = item.AuthorBookID,
                        BookName = item.Book.BookName,
                        BookID = item.BookID,
                        AuthorFullName = item.Author.AuthorName + " " + item.Author.AuthorSurname,
                        AuthorID = item.AuthorID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorBookDtos;

            return _returnValueServiceResultList;
        }
    }
}
