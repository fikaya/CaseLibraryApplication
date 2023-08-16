﻿using LibraryApplication.BusinessLayer.Abstract.Managment;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface IReservationManager :
        ICrudManager<ReservationCrudDto>,
        IGetListConditionalManager<ReservationDto, Reservation>,
        IGetListManager<ReservationDto>,
        IFindManager<ReservationDto,Reservation>,
        IGetListReferenceConditionalManager<ReservationDto, Reservation>,
        IGetListReferenceManager<ReservationDto>
    {

    }
}
