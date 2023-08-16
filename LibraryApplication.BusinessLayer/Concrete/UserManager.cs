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
    public class UserManager : ServiceResultSetting<UserDto>, IUserManager
    {
        private readonly IUserRepository _repository;
        public UserManager(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        public ServiceResult Delete(UserCrudDto userDto)
        {
            var user = new User()
            {
                UserID = userDto.UserID
            };
            int serviceResult = 0;
            try
            {
                var value = _repository.Find(x => x.UserID == user.UserID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Kullanıcı Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kullanıcı Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(UserCrudDto userDto)
        {
            var user = new User()
            {
                UserName = userDto.UserName,
                UserSurname = userDto.UserSurname,
                UserEMail = userDto.UserEMail,
                UserIdentityNumber = userDto.UserIdentityNumber,
                UserTelephoneNumber = userDto.UserTelephoneNumber,
                UserBirthDate = userDto.UserBirthDate
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(user);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kullanıcı Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(UserCrudDto userDto)
        {
            var user = new User()
            {
                UserName = userDto.UserName,
                UserSurname = userDto.UserSurname,
                UserEMail = userDto.UserEMail,
                UserIdentityNumber = userDto.UserIdentityNumber,
                UserTelephoneNumber = userDto.UserTelephoneNumber,
                UserBirthDate = userDto.UserBirthDate
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(user);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Kullanıcı Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<UserDto> Find(Expression<Func<User, bool>> where)
        {
            User user;
            try
            {
                user = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (user == null)
                _returnValueServiceResultFind.AddError("Kullanıcı Kaydı Bulunamadı.");
            else
            {
                UserDto UserDto = new UserDto()
                {
                    UserID=user.UserID,
                    UserFullName = user.UserFullName,
                    UserEMail = user.UserEMail,
                    UserAge = user.Age
                };
                _returnValueServiceResultFind.Data = UserDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<UserDto>> GetList()
        {
            List<UserDto> userDtos;
            try
            {
                var users = _repository.List();
                userDtos = new List<UserDto>();

                foreach (var item in users)
                {
                    userDtos.Add(new UserDto()
                    {
                        UserID = item.UserID,
                        UserFullName = item.UserFullName,
                        UserEMail = item.UserEMail,
                        UserAge = item.Age
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = userDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<UserDto>> GetList(Expression<Func<User, bool>> where)
        {
            List<UserDto> userDtos;
            try
            {
                var users = _repository.List(where);
                userDtos = new List<UserDto>();

                foreach (var item in users)
                {
                    userDtos.Add(new UserDto()
                    {
                        UserID = item.UserID,
                        UserFullName = item.UserFullName,
                        UserEMail = item.UserEMail,
                        UserAge = item.Age
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = userDtos;

            return _returnValueServiceResultList;
        }

        public ReturnValueServiceResult<List<UserDto>> GetListCollection(Expression<Func<User, bool>> where, params string[] collectionNames)
        {
            List<UserDto> userDtos;
            try
            {
                var users = _repository.ListCollection(where, collectionNames);

                userDtos = new List<UserDto>();

                foreach (var item in users)
                {
                    userDtos.Add(new UserDto()
                    {
                        UserID = item.UserID,
                        UserFullName = item.UserFullName,
                        UserEMail = item.UserEMail,
                        UserAge = item.Age
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = userDtos;

            return _returnValueServiceResultList;
        }

        public ReturnValueServiceResult<List<UserDto>> GetListCollection(params string[] collectionNames)
        {
            List<UserDto> userDtos;
            try
            {
                var users = _repository.ListCollection(collectionNames);

                userDtos = new List<UserDto>();

                foreach (var item in users)
                {
                    userDtos.Add(new UserDto()
                    {
                        UserID = item.UserID,
                        UserFullName = item.UserFullName,
                        UserEMail = item.UserEMail,
                        UserAge = item.Age
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = userDtos;

            return _returnValueServiceResultList;
        }
    }
}
