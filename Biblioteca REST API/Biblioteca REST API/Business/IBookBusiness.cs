using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book Update(Book book);
        void Delete(long id);
        List<Book> FindAll();
        Book FindById(long id);
    }
}
