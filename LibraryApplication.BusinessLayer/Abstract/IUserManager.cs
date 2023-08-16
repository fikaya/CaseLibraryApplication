using LibraryApplication.BusinessLayer.Abstract.Managment;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface IUserManager :
        ICrudManager<UserCrudDto>,
        IGetListConditionalManager<UserDto, User>,
        IGetListManager<UserDto>,
        IFindManager<UserDto, User>,
        IGetListCollectionConditionalManager<UserDto, User>,
        IGetListCollectionManager<UserDto>
    {
    }
}
