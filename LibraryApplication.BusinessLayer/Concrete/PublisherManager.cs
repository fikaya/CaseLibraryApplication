using LibraryApplication.BusinessLayer.Abstract;
using LibraryApplication.BusinessLayer.ServiceResults;
using LibraryApplication.DataLayer.EntityFrameworkCore.Abstract.Repository;
using LibraryApplication.DataLayer.EntityFrameworkCore.Concrete.Repository;
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
    public class PublisherManager : ServiceResultSetting<PublisherDto>,IPublisherManager
    {
        private readonly IPublisherRepository _repository;
        public PublisherManager(IPublisherRepository publisherRepository)
        {
            _repository = publisherRepository;
        }
        public ServiceResult Delete(PublisherDto  publisherDto)
        {
            var publisher = new Publisher()
            {
                PublisherID = publisherDto.PublisherID
            };

            int serviceResult = 0;

            try
            {
                var value = _repository.Find(x => x.PublisherID == publisher.PublisherID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Yayınevi Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Yayınevi Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(PublisherDto publisherDto)
        {
            var publisher = new Publisher()
            {
                PublisherName = publisherDto.PublisherName,
                PublisherID = publisherDto.PublisherID
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(publisher);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Yayınevi Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(PublisherDto publisherDto)
        {
            var publisher = new Publisher()
            {
                PublisherName = publisherDto.PublisherName,
                PublisherID = publisherDto.PublisherID
            };
            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Update(publisher);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Yayınevi Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<PublisherDto> Find(Expression<Func<Publisher, bool>> where)
        {
            Publisher publisher;
            try
            {
                publisher = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (publisher == null)
                _returnValueServiceResultFind.AddError("Yayınevi Kaydı Bulunamadı.");
            else
            {
                PublisherDto  publisherDto = new PublisherDto()
                {
                    PublisherName = publisher.PublisherName,
                    PublisherID = publisher.PublisherID
                };
                _returnValueServiceResultFind.Data = publisherDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<PublisherDto>> GetList()
        {
            List<PublisherDto>  publisherDtos;
            try
            {
                var  publishers = _repository.List();
                publisherDtos = new List<PublisherDto>();

                foreach (var item in publishers)
                {
                    publisherDtos.Add(new PublisherDto()
                    {
                        PublisherName = item.PublisherName,
                        PublisherID = item.PublisherID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = publisherDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<PublisherDto>> GetList(Expression<Func<Publisher, bool>> where)
        {
            List<PublisherDto> publisherDtos;
            try
            {
                var publishers = _repository.List(where);
                publisherDtos = new List<PublisherDto>();

                foreach (var item in publishers)
                {
                    publisherDtos.Add(new PublisherDto()
                    {
                        PublisherName = item.PublisherName,
                        PublisherID = item.PublisherID
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = publisherDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<PublisherDto>> GetListReference(params string[] referenceNames)
        {
            List<PublisherDto> publisherDtos;
            try
            {
                var publishers = _repository.ListReference(referenceNames);

                publisherDtos = new List<PublisherDto>();

                foreach (var item in publishers)
                {
                    publisherDtos.Add(new PublisherDto()
                    {
                        PublisherID = item.PublisherID,
                        PublisherName = item.PublisherName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = publisherDtos;

            return _returnValueServiceResultList;

        }
        public ReturnValueServiceResult<List<PublisherDto>> GetListReference(Expression<Func<Publisher, bool>> where, params string[] referenceNames)
        {
            List<PublisherDto> publisherDtos;
            try
            {
                var publishers = _repository.ListReference(where,referenceNames);

                publisherDtos = new List<PublisherDto>();

                foreach (var item in publishers)
                {
                    publisherDtos.Add(new PublisherDto()
                    {
                        PublisherID = item.PublisherID,
                        PublisherName = item.PublisherName
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = publisherDtos;

            return _returnValueServiceResultList;

        }


    }
}
