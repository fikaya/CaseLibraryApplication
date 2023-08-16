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
    public class EditionNumberManager : ServiceResultSetting<EditionNumberDto>, IEditionNumberManager
    {
        private readonly IEditionNumberRepository _repository;
        public EditionNumberManager(IEditionNumberRepository editionNumberRepository)
        {
            _repository = editionNumberRepository;
        }
        public ServiceResult Delete(EditionNumberDto editionNumberDto)
        {
            var editionNumber = new EditionNumber()
            {
                EditionNumberID = editionNumberDto.EditionNumberID,
            };

            int serviceResult = 0;

            try
            {
                var value = _repository.Find(x => x.EditionNumberID == editionNumber.EditionNumberID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Basım Numarası Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;           
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Basım Numarası Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(EditionNumberDto editionNumberDto)
        {
            var editionNumber = new EditionNumber()
            {
                EditionNumberBook = editionNumberDto.EditionNumberBook,
            };


            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(editionNumber);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Basım Numarası Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(EditionNumberDto editionNumberDto)
        {
            var editionNumber = new EditionNumber()
            {
                EditionNumberID = editionNumberDto.EditionNumberID,
                EditionNumberBook = editionNumberDto.EditionNumberBook,
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(editionNumber);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Basım Numarası Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<EditionNumberDto> Find(Expression<Func<EditionNumber, bool>> where)
        {
            EditionNumber editionNumber;
            try
            {
                editionNumber = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (editionNumber == null)
                _returnValueServiceResultFind.AddError("Basım Numarası Kaydı Bulunamadı.");
            else
            {
                EditionNumberDto editionNumberDto = new EditionNumberDto()
                {
                    EditionNumberID = editionNumber.EditionNumberID,
                    EditionNumberBook = editionNumber.EditionNumberBook
                };
                _returnValueServiceResultFind.Data = editionNumberDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<EditionNumberDto>> GetList()
        {
            List<EditionNumberDto> editionNumberDtoList;
            try
            {
                var editionNumbers = _repository.List();
                editionNumberDtoList = new List<EditionNumberDto>();

                foreach (var item in editionNumbers)
                {
                    editionNumberDtoList.Add(new EditionNumberDto()
                    {
                        EditionNumberID = item.EditionNumberID,
                        EditionNumberBook = item.EditionNumberBook
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = editionNumberDtoList;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<EditionNumberDto>> GetList(Expression<Func<EditionNumber, bool>> where)
        {
            List<EditionNumberDto> editionNumberDtoList;
            try
            {
                var editionNumbers = _repository.List(where);
                editionNumberDtoList = new List<EditionNumberDto>();

                foreach (var item in editionNumbers)
                {
                    editionNumberDtoList.Add(new EditionNumberDto()
                    {
                        EditionNumberID = item.EditionNumberID,
                        EditionNumberBook = item.EditionNumberBook
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = editionNumberDtoList;

            return _returnValueServiceResultList;
        }
    }
}
