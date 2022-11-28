using AutoFixture;
using TestBootcamp._2_ComplexInput;
using TestBootcamp._2_ComplexInput.Models;

namespace TestBootcamp.UnitTests;

[TestClass]
public class AccessControllerTests {

    
    
    [TestMethod]
    public void CanAccess_EmptyUser_False()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var user = new User();
        var controller = new AccessController();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(user);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void CanAccess_UserYoungerThan21_False()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var user = new User
        {
            FirstName = "Gatty",
            LastName = "Ungatekeeper",
            DateOfBirth = new DateTime(2006,3,18),
            Id= Guid.NewGuid()
        };
        var controller = new AccessController();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(user);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void CanAccess_UserYoungerThan21FromTheSmithClan_True()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var fixture = new Fixture();

        var user = fixture.Build<User>()
            .With(u => u.LastName, "Smith")
            .With(u => u.DateOfBirth, new DateTime(2006, 3, 18))
            .Create();
        
        var controller = new AccessController();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(user);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void CanAccess_UserOlderThan21_True()
    {
        var fixture = new Fixture();

        var user = fixture.Build<User>()
            .With(u => u.DateOfBirth, new DateTime(2000, 3, 18))
            .Create();
        
        //Arrange - Here we're setting up the necessary data or dependencies for our test

        var controller = new AccessController();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(user);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void CanAccess_UserNotBornYet_False()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var user = new User
        {
            FirstName = "Gatty",
            LastName = "Ungatekeeper",
            DateOfBirth = new DateTime(2050,3,18),
            Id = Guid.NewGuid()
        };
        var controller = new AccessController();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(user);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsFalse(result);
    }
}