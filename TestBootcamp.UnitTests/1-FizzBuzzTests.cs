using TestBootcamp._1_FizzBuzz;

namespace TestBootcamp.UnitTests;

/*
 * A test class is a collection of tests.
 * The convention for the test class name is {NameOfClassUnderTest}Tests.
 * In this example we're testing the `FizzBuzz` class.
 */
[TestClass]
public class FizzBuzzTests
{
    /*
     * Each method inside of our test class marked with the `TestMethod` attribute is a test to be executed.
     * The naming convention for tests is {NameOfMethodUnderTest}_{TestInput}_{ExpectedBehavior}
     * In this example:
     *  - we're testing the `Translate` method
     *  - we're passing in a number that is not divisible by 3 or 5
     *  - we expect it to return the number itself
     */
    [TestMethod]
    public void Translate_NumberNotDivisibleBy3or5_TheNumberItself()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        
        //Act - Here we'll perform the action that we want to test
        
        //Assert - Here we'll verify the results of the action performed by our code.
    }
}