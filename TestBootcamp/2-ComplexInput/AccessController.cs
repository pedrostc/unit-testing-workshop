using TestBootcamp._2_ComplexInput.Models;

namespace TestBootcamp._2_ComplexInput;

public class AccessController
{
    public bool CanEnter(User user)
    {
        return !user.MissingRequireData && (user.Age >= 21 || user.LastName == "Smith");
    }
}