using LayeredArchitecture.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayeredArchitecture.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _dbContext.Books.FindAsync(id);
        }

        public async Task<int> AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book.Id;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            _dbContext.Books.Update(book);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = await GetBookById(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                return await _dbContext.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
