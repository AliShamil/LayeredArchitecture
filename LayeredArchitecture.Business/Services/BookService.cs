using LayeredArchitecture.Business.Interfaces;
using LayeredArchitecture.Data.Entities;
using LayeredArchitecture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredArchitecture.Data.Repositories;

namespace LayeredArchitecture.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }

        public async Task<int> AddBook(Book book)
        {
            return await _bookRepository.AddBook(book);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            return await _bookRepository.UpdateBook(book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            return await _bookRepository.DeleteBook(id);
        }
    }
}
