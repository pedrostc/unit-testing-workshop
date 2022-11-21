namespace TestBootcamp._3_Mocking.Models;

public class User
{
    private const double AvgDaysPerYear = 365.242199;
    public Guid Id { get; set; } = Guid.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
    public double Age => Math.Floor((DateTime.Today - DateOfBirth).TotalDays / AvgDaysPerYear);

    public bool MissingRequireData => Id == Guid.Empty
                                      || string.IsNullOrWhiteSpace(FirstName)
                                      || string.IsNullOrWhiteSpace(LastName)
                                      || DateTime.MinValue == DateOfBirth;
}