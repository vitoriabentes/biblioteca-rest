using Biblioteca_REST_API.Data.VO;
using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Repository
{
    public interface IUserRepository
    {
        User? ValidateCredentials(UserVO user);

        User? ValidateCredentials(string username);

        bool RevokeToken(string username);

        User? RefreshUserInfo(User user);
    }
}
