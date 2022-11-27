# Part 1 - Testing Basics with FizzBuzz
In this part, we'll start writing some tests using a fizzbuzz application as an example.
We'll explore some testing basics, like, test structure, naming conventions, objectives, and refactoring.

## FizzBuzz
Our first example is a game of FizzBuzz. The rules are simple: Given a list of numbers, we should replace any number divisible by 3 with the word "Fizz," any number divisible by 5 with the word "Buzz," and any number divisible by both with "FizzBuzz." Otherwise, we say the number itself.

Ex.: Counting from 1 to 15 would look like this:
> 1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz.

## The implementation
We have an implementation for FizBuzz on our solution in the [FizzBuzz class](../TestBootcamp/1-FizzBuzz/FizzBuzz.cs). The current implementation is, let's say, limited. But it works if the game goes up to 100, at least. We probably want to refactor that in the future, but let's use it as it is for now, and let's focus on writing our tests to make sure it works as expected.

## Testing our code.
A unit test is a piece of code that will execute our code (our unit) and run some checks against the results to verify its behavior. You can think of them as executable specifications for your code.
Let's write our first test for our `FizzBuzz` class. On the file [1-FizzBuzzTests.cs](../TestBootcamp.UnitTests/1-FizzBuzzTests.cs), we have a basic setup for a test, and it looks like this:

```csharp
[TestClass]
public class FizzBuzzTests
{
    [TestMethod]
    public void Translate_NumberNotDivisibleBy3or5_TheNumberItself()
    {
        //Arrange
        
        //Act
        
        //Assert
    }
}
```

Let's break it down a bit:

### Naming conventions
The convention for the test class name follows the pattern `{NameOfClassUnderTest}Tests`. In this example, we're testing the `FizzBuzz` class, so our test class is `FizzBuzzTests`.

For the test method, the convention follows the pattern `{NameOfMethodUnderTest}_{TestInput}_{ExpectedBehavior}`. 
Here we have `Translate_NumberNotDivisibleBy3or5_TheNumberItself`, which tells us that:
 - we're testing the `Translate` method
 - we're passing in a number that is not divisible by 3 or 5
 - we expect it to return the number itself

 These conventions make the test code more expressive and easier to navigate. If we think of our tests as usage examples of our code, a good naming convention helps to identify not just what the test is validating but also the capabilities of the unit under test.

### Test structure
Our test has three sections: Arrange, Act, and Assert. This structure reflects the necessary steps to test our code. We first must set up the class under test and any required data. Then we perform the action we want to test. Later we verify that the behavior matches what we expect from the class.

### Annotations
Each testing library has its own set of annotations to identify tests. MSTest uses `[TestClass]` to identify the classes containing our tests and `[TestMethod]` to identify the tests themselves. If we don't mark our tests with these, the test runner will not be able to identify the tests and will not execute them.

## Implementing the test
Let's begin with the `Arrange` section. We need to set our input value and instantiate our `FizzBuzz` class. It should look like this:

```csharp
// Arrange
var testInput = 1;
var fizzBuzz = new FizzBuzz();
```

We'll then perform the action we want to test for the Act section. In this case, we'll do that by calling the `Translate` method of our `FizzBuzz` class, passing our `testInput` variable, and let's save the value it returns into a new variable for later.

```csharp
// Act
var result = fizzBuzz.Translate(testInput);
```

Now we need to validate that our result is the one we expect. We do that on the `Assert` section of our test. The `MSTest` library exposes a utility called `Assert`, which contains many methods we can use to assert the results of our tests. Here we want to check if the result equals the string `"1"`. We can accomplish that by using the `Assert.AreEqual(expected, actual)`[^1] method.

```csharp
// Assert
Assert.AreEqual("1", result);
```

## Creating a couple of new tests

- translate_3_fizz
- translage_5_buzz

## Parameterized tests

- DataTest and DataRow Annotations
- Why not use generated data and a bit of logic for the tests?
- translate_divisibleBy15_fizzbuzz

## Refactoring our code

- refactor the fizzbuzz code so it doesn't use the hardcoded data anymore.
- use the tests as a guardrail for the refactoring process providing feedback throughout the process.


[^1]: It may seem a bit backward, but the first argument is the expected value, and the second is the actual result we want to check. If you invert them, the test will still work as expected, but the error message in case of a failure will be a bit confusing.

    Example:
    ```csharp
    Assert.AreEqual("1", result); // Assert.AreEqual failed. Expected:<1>. Actual:<SomethingElse>. 
    Assert.AreEqual(result, "1"); // Assert.AreEqual failed. Expected:<SomethingElse>. Actual:<1>.
    ```
