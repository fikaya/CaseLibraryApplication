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
    public interface IAuthorBookManager :
        ICrudManager<AuthorBookDto>,
        IFindManager<AuthorBookDto,AuthorBook>,
        IGetListConditionalManager<AuthorBookDto,AuthorBook>, 
        IGetListManager<AuthorBookDto>,
        IGetListReferenceConditionalManager<AuthorBookDto, AuthorBook>,
        IGetListReferenceManager<AuthorBookDto>
    {

    }
}
