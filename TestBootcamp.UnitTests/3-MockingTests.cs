using AutoFixture;
using AutoFixture.AutoMoq;
using Moq;
using TestBootcamp._3_Mocking;
using TestBootcamp._3_Mocking.Models;

namespace TestBootcamp.UnitTests;

[TestClass]
public class MockingTests
{
    [TestMethod]
    public void CanAccess_IdForUserYoungerThan21FromTheSmithClan_True()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var userId = Guid.NewGuid();
        
        var repo = fixture.Freeze<Mock<IUserRepository>>();
        repo.Setup(r => r.GetUserById(userId))
            .Returns<Guid>((id) =>
            {
                return fixture.Build<User>()
                    .With(u => u.Id, id)
                    .With(u => u.LastName, "Smith")
                    .With(u => u.DateOfBirth, new DateTime(2006, 3, 18))
                    .Create();
            });
        
        var controller = fixture.Create<AccessController>();
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(userId);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void CanAccess_IdForUserOlderThan21_True()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var userId = Guid.NewGuid();

        var repo = new Mock<IUserRepository>();
        repo.Setup(r => r.GetUserById(userId))
            .Returns(new User
            {
                Id = userId,
                FirstName = "Gatty",
                LastName = "Smith",
                DateOfBirth = new DateTime(2000, 3, 18)
            });
        var logger = new Mock<ILogger>();

        var controller = new AccessController(repo.Object, logger.Object);
        
        //Act - Here we'll perform the action that we want to test
        var result = controller.CanEnter(userId);

        //Assert - Here we'll verify the results of the action performed by our code.
        Assert.IsTrue(result);
    }
    
    [TestMethod]
    public void CanAccess_MissingData_LogsInfo()
    {
        //Arrange - Here we're setting up the necessary data or dependencies for our test
        var fixture = new Fixture().Customize(new AutoMoqCustomization());

        var userId = Guid.NewGuid();
        
        var repo = fixture.Freeze<Mock<IUserRepository>>();
        repo.Setup(r => r.GetUserById(userId))
            .Returns<Guid>((id) =>
            {
                return fixture.Build<User>()
                    .With(u => u.Id, id)
                    .Without(u => u.LastName)
                    .With(u => u.DateOfBirth, new DateTime(2006, 3, 18))
                    .Create();
            });
        
        var logger = fixture.Freeze<Mock<ILogger>>();
        logger.Setup((l) => l.LogInformation(It.IsAny<string>()))
            .Callback<string>(v => Console.WriteLine(v));

        var controller = fixture.Create<AccessController>();
        
        //Act - Here we'll perform the action that we want to test
        controller.CanEnter(userId);

        //Assert - Here we'll verify the results of the action performed by our code.
        logger.Verify(l => l.LogInformation("User is missing data"), Times.Once);
    }
}
