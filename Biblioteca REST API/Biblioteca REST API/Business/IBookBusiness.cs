
using Biblioteca_REST_API.Data.VO;

namespace Biblioteca_REST_API.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO Update(BookVO book);
        void Delete(long id);
        List<BookVO> FindAll();
        BookVO FindById(long id);
    }
}
