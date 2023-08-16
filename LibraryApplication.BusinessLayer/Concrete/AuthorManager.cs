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
    public class AuthorManager : ServiceResultSetting<AuthorDto>, IAuthorManager
    {
        private readonly IAuthorRepository _repository;
        public AuthorManager(IAuthorRepository authorRepository)
        {
            _repository = authorRepository;
        }
        public ServiceResult Delete(AuthorDto authorDto)
        {
            var author = new Author()
            {
                AuthorID = authorDto.AuthorID,
            };

            int serviceResult = 0;
            try
            {
                var value = _repository.Find(x => x.AuthorID == author.AuthorID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Yazar Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Yazar Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(AuthorDto authorDto)
        {
            var author = new Author()
            {
                AuthorName = authorDto.AuthorName,
                AuthorSurname = authorDto.AuthorSurname
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(author);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Yazar Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(AuthorDto authorDto)
        {
            var author = new Author()
            {
                AuthorID = authorDto.AuthorID,
                AuthorName = authorDto.AuthorName,
                AuthorSurname = authorDto.AuthorSurname
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(author);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kitap Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<AuthorDto> Find(Expression<Func<Author, bool>> where)
        {
            Author author;
            try
            {
                author = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (author == null)
                _returnValueServiceResultFind.AddError("Yazar Kaydı Bulunamadı.");
            else
            {
                AuthorDto authorDto = new AuthorDto()
                {
                    AuthorID = author.AuthorID,
                    AuthorName = author.AuthorName,
                    AuthorSurname = author.AuthorSurname
                };
                _returnValueServiceResultFind.Data = authorDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<AuthorDto>> GetList()
        {
            List<AuthorDto> authorDtoList;
            try
            {
                var authors = _repository.List();
                authorDtoList = new List<AuthorDto>();

                foreach (var item in authors)
                {
                    authorDtoList.Add(new AuthorDto()
                    {
                        AuthorID = item.AuthorID,
                        AuthorName = item.AuthorName,
                        AuthorSurname = item.AuthorSurname
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorDtoList;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<AuthorDto>> GetList(Expression<Func<Author, bool>> where)
        {
            List<AuthorDto> authorDtoList;
            try
            {
                var authors = _repository.List(where);
                authorDtoList = new List<AuthorDto>();

                foreach (var item in authors)
                {
                    authorDtoList.Add(new AuthorDto()
                    {
                        AuthorID = item.AuthorID,
                        AuthorName = item.AuthorName,
                        AuthorSurname = item.AuthorSurname
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = authorDtoList;

            return _returnValueServiceResultList;
        }

    }
}
