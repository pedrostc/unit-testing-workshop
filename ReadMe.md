# C# unit testing workshop

This is the base repository for a C# unit testing workshop using MSTest, Moq, and AutoFixture.

The code is separated into 3 section and the solutions will be built live during the workshop together with the necessary explanations and theory.

It's encouraged to try and use this repository to practice the content of the workshop.

## Part 1 - Getting started with unit test - FizzBuzz

This parts uses FizzBuzz as an example to build the foundational knowledge on unit testing, like test structure, objectives, naming conventions, test parametrization and general patterns and good practices.

[Part 1 guide](./Docs/Part%201%20-%20Testing%20Basics%20with%20fizzbuzz.md)

## Part 2 - Complex inputs

This section uses an access control code that expects a `User` object and returns a `boolean` indicating if the user can access a facility or not.
Here we'll discuss how to create and manage data for our tests. How to use our test code as an example of code usage by making the test code reflect each use case being tested. We'll also have an introduction to AutoFixture and how we can use it to create meaningful data for our tests.
We'll also verify how can we test for exceptions.

## Part 3 - Handling dependencies

In this part we'll deal with dependencies of the code under test. We'll take a look on fake implementations an how Moq and AutoFixture can simplify our test code and make our lifes a bit easier.
We'll also use spies to assert on the utilization of certain dependencies and take a look on the `It` helper.