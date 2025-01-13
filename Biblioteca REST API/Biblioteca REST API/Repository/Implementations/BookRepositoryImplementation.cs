using Biblioteca_REST_API.Models;
using Biblioteca_REST_API.Models.Context;
using System;

namespace Biblioteca_REST_API.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        public MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));
            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            if (result is not null)
            {
                try
                {
                    _context.Books.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.Books.Any(b => b.Id.Equals(id));
        }
    }
}
