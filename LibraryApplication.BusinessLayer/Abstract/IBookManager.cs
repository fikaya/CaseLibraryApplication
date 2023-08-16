using LibraryApplication.BusinessLayer.Abstract.Managment;
using LibraryApplication.DataLayer.Abstract;
using LibraryApplication.Entities;
using LibraryApplication.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.BusinessLayer.Abstract
{
    public interface IBookManager :
        ICrudManager<BookCrudDto>,
        IGetListConditionalManager<BookDto, Book>,
        IFindManager<BookDto,Book>,
        IGetListManager<BookDto>,
        IGetListReferenceConditionalManager<BookDto, Book>,
        IGetListReferenceManager<BookDto>
    {

    }
}
