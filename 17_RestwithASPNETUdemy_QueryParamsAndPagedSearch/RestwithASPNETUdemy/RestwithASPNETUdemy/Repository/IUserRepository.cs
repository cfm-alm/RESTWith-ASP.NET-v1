using RestwithASPNETUdemy.Data.VO;
using RestwithASPNETUdemy.Model;

namespace RestwithASPNETUdemy.Repository
{
    public interface IUserRepository
    {
        User? ValidateCredentials(UserVO user);

        User? ValidateCredentials(string username);

        bool RevokeToken(string username);

        User? RefreshUserInfo(User user);
    }
}
