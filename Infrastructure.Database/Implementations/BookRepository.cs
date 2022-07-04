using Core.Application.Interfaces.Repositories;
using Core.Application.Paging;
using Core.Domain.Models;
using Infrastructure.Database.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreDbContext context) : base(context)
        {

        }
        public IEnumerable<Book> GetBooks(PageRequest pageRequest, out PageResponse pageResponse)
        {
            pageResponse = new PageResponse();
            var result = context.Books.Include(x => x.Author).TakePage(pageRequest, out pageResponse).ToList();
            return result;
        }
    }
}
