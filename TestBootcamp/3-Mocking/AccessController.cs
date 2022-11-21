using TestBootcamp._3_Mocking.Models;

namespace TestBootcamp._3_Mocking;

public class AccessController
{
    private readonly IUserRepository _userRepository;

    public AccessController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public bool CanEnter(Guid userId)
    {
        var user = GetUser(userId);

        if (user.Id != userId)
        {
            return true;
        }
        
        return CanUserEnter(user);
    }

    private User GetUser(Guid userId)
    {
        return _userRepository.GetUserById(userId);
    }

    private bool CanUserEnter(User user)
    {
        return !user.MissingRequireData && (user.Age >= 21 || user.LastName == "Smith");
    }
}