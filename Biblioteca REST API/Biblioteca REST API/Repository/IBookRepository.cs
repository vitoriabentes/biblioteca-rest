using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        List<Book> FindAll();
        Book FindById(long id);
        bool Exists(long id);
    }
}
