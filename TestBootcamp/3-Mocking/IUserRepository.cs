using TestBootcamp._3_Mocking.Models;

namespace TestBootcamp._3_Mocking;

public interface IUserRepository
{
    User GetUserById(Guid id);
}