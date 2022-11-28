namespace TestBootcamp._1_FizzBuzz;

public class FizzBuzz
{
    public string Translate(int number)
    {
        if (number % 15 == 0)
        {
            return "FizzBuzz";
        }
        if (number % 3 == 0)
        {
            return "Fizz";
        }
        if (number % 5 == 0)
        {
            return "Buzz";
        }
        return number.ToString();
    }
}