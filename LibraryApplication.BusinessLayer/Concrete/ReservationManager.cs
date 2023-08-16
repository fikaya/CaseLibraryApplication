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
    public class ReservationManager : ServiceResultSetting<ReservationDto>, IReservationManager
    {
        private readonly IReservationRepository _repository;
        public ReservationManager(IReservationRepository reservationRepository)
        {
            _repository = reservationRepository;
        }
        public ServiceResult Delete(ReservationCrudDto reservationDto)
        {
            var reservation = new Reservation()
            {
                ReservationID = reservationDto.ReservationID
            };
            int serviceResult = 0;
            try
            {
                var value = _repository.Find(x => x.ReservationID == reservation.ReservationID);

                if (value != null)
                {
                    serviceResult = _repository.Delete(value);
                }
                else
                {
                    _serviceResult.AddError("Rezervasyon Kaydı Bulunamadı.");
                    serviceResult = 2;
                }
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Rezervasyon Kaydı Silinemedi.");

            return _serviceResult;
        }
        public ServiceResult Insert(ReservationCrudDto reservationDto)
        {
            var reservation = new Reservation()
            {
                DeliveryDate = reservationDto.DeliveryDate,
                ReservationDate = reservationDto.ReservationDate,
                UserID = reservationDto.UserID,
                BookEditionNumberID = reservationDto.BookEditionNumberID,
            };

            int serviceResult = 0;
            try
            {
                serviceResult = _repository.Insert(reservation);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Rezervasyon Kaydı Yapılamadı.");

            return _serviceResult;
        }
        public ServiceResult Update(ReservationCrudDto reservationDto)
        {
            var reservation = new Reservation()
            {
                ReservationID=20,
                DeliveryDate = reservationDto.DeliveryDate,
                ReservationDate = reservationDto.ReservationDate,
                UserID = reservationDto.UserID,
                BookEditionNumberID = reservationDto.BookEditionNumberID,
            };

            int serviceResult = 0;

            try
            {
                serviceResult = _repository.Update(reservation);
            }
            catch (Exception)
            {
                throw;
            }

            if (serviceResult <= 0)
                _serviceResult.AddError("Rezervasyon Kaydı Güncellenemedi.");

            return _serviceResult;
        }
        public ReturnValueServiceResult<ReservationDto> Find(Expression<Func<Reservation, bool>> where)
        {
            Reservation reservation;
            try
            {
                reservation = _repository.Find(where);
            }
            catch (Exception)
            {
                throw;
            }

            if (reservation == null)
                _returnValueServiceResultFind.AddError("Rezervasyon Kaydı Bulunamadı.");
            else
            {
                ReservationDto ReservationDto = new ReservationDto()
                {
                    ReservationID = reservation.ReservationID,
                    DeliveryDate = reservation.DeliveryDate,
                    ReservationDate = reservation.ReservationDate,
                    BookReceivedDate = reservation.BookReceivedDate,
                    UserID = reservation.UserID,
                    BookEditionNumberID = reservation.BookEditionNumberID,
                };
                _returnValueServiceResultFind.Data = ReservationDto;
            }

            return _returnValueServiceResultFind;
        }
        public ReturnValueServiceResult<List<ReservationDto>> GetList()
        {
            List<ReservationDto> reservationDtos;
            try
            {
                var reservations = _repository.List();
                reservationDtos = new List<ReservationDto>();

                foreach (var item in reservations)
                {
                    reservationDtos.Add(new ReservationDto()
                    {
                        DeliveryDate = item.DeliveryDate,
                        ReservationDate = item.ReservationDate,
                        ReservationID=item.ReservationID,
                         UserName=item.User.UserName,
                        BookReceivedDate = item.BookReceivedDate,
                        UserID = item.UserID,
                        BookEditionNumberID = item.BookEditionNumberID,
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = reservationDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<ReservationDto>> GetList(Expression<Func<Reservation, bool>> where)
        {
            List<ReservationDto> reservationDtos;
            try
            {
                var reservations = _repository.List(where);
                reservationDtos = new List<ReservationDto>();

                foreach (var item in reservations)
                {
                    reservationDtos.Add(new ReservationDto()
                    {
                        UserName = item.User.UserName,
                        DeliveryDate = item.DeliveryDate,
                        ReservationDate = item.ReservationDate,
                        ReservationID=item.ReservationID,
                        BookReceivedDate = item.BookReceivedDate,
                        UserID = item.UserID,
                        BookEditionNumberID = item.BookEditionNumberID,
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = reservationDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<ReservationDto>> GetListReference(params string[] referenceNames)
        {
            List<ReservationDto> reservationDtos;
            try
            {
                var reservations = _repository.ListReference(referenceNames);

                reservationDtos = new List<ReservationDto>();

                foreach (var item in reservations)
                {
                    reservationDtos.Add(new ReservationDto()
                    {
                        UserName = item.User.UserName,
                        BookReceivedDate = item.BookReceivedDate,
                        BookEditionNumberID=item.BookEditionNumberID,
                        ReservationID=item.ReservationID,
                        UserID=item.UserID,
                        DeliveryDate = item.DeliveryDate,
                        ReservationDate = item.ReservationDate
                    });
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            _returnValueServiceResultList.Data = reservationDtos;

            return _returnValueServiceResultList;
        }
        public ReturnValueServiceResult<List<ReservationDto>> GetListReference(Expression<Func<Reservation, bool>> where, params string[] referenceNames)
        {
            List<ReservationDto> reservationDtos;
            try
            {
                var reservations = _repository.ListReference(where, referenceNames);

                reservationDtos = new List<ReservationDto>();

                foreach (var item in reservations)
                {
                    reservationDtos.Add(new ReservationDto()
                    {
                        UserName = item.User.UserName,
                        BookReceivedDate = item.BookReceivedDate,
                        BookEditionNumberID = item.BookEditionNumberID,
                        ReservationID = item.ReservationID,
                        UserID = item.UserID,
                        DeliveryDate = item.DeliveryDate,
                        ReservationDate = item.ReservationDate
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            _returnValueServiceResultList.Data = reservationDtos;

            return _returnValueServiceResultList;
        }
    }
}
