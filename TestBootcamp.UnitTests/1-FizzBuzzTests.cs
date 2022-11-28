using TestBootcamp._1_FizzBuzz;

namespace TestBootcamp.UnitTests;

[TestClass]
public class FizzBuzzTests
{
    [DataTestMethod]
    [DataRow(1, "1")]
    [DataRow(2, "2")]
    [DataRow(3, "Fizz")]
    [DataRow(4, "4")]
    [DataRow(5, "Buzz")]
    [DataRow(15, "FizzBuzz")]
    [DataRow(45, "FizzBuzz")]
    [DataRow(60, "FizzBuzz")]
    [DataRow(101, "101")]
    public void Translate_Something_SomethingElse(int inputValue, string expectedResult)
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var fizzBuzz = new FizzBuzz();
        
        //Act - Here we'll perform the action that we want to test
        var result = fizzBuzz.Translate(inputValue);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.AreEqual(expectedResult, result);
    }
}