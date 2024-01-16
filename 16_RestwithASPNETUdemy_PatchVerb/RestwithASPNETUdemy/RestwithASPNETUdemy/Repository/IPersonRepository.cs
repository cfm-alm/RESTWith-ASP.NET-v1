using RestwithASPNETUdemy.Data.VO;
using RestwithASPNETUdemy.Model;

namespace RestwithASPNETUdemy.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person Disable(long id);
    }
}
