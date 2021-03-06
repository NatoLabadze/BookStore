using Core.Application.Paging;
using Core.Domain.Models;
using System.Collections.Generic;

namespace Core.Application.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooks(PageRequest pageRequest, out PageResponse pageResponse);
    }
}
