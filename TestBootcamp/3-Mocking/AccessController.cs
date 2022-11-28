using TestBootcamp._3_Mocking.Models;

namespace TestBootcamp._3_Mocking;

public class AccessController
{
    private readonly IUserRepository _userRepository;
    private readonly ILogger _logger;

    public AccessController(IUserRepository userRepository, ILogger logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public bool CanEnter(Guid userId)
    {
        var user = GetUser(userId);
        
        return CanUserEnter(user);
    }

    private User GetUser(Guid userId)
    {
        return _userRepository.GetUserById(userId);
    }

    private bool CanUserEnter(User user)
    {
        if (user.MissingRequireData)
        {
            _logger.LogInformation("User is missing data");
            _logger.LogInformation("Yup it is");
        }

        return !user.MissingRequireData && (user.Age >= 21 || user.LastName == "Smith");
    }
}