using Xunit;
using Moq;
using Models;
using DataAccess;
using Services;

public class UserServiceTests
{
    [Fact]
    public void Authenticate_Should_Call_Authenticate_Method_In_Repo()
    {
        // Arrange
        var loginInfo = new string[] { "username", "password" };
        var repoMock = new Mock<IRepo>();
        var userService = new UserService(repoMock.Object);

        // Act
        userService.Authenticate(loginInfo);

        // Assert
        repoMock.Verify(x => x.Authenticate(loginInfo), Times.Once);
    }

    [Fact]
    public void RegisterUser_Should_Call_CreateNewUser_Method_In_Repo()
    {
        // Arrange
        var account = new Account { Username = "testuser", PhoneNumber = "12345644" };
        var repoMock = new Mock<IRepo>();
        var userService = new UserService(repoMock.Object);

        // Act
        userService.RegisterUser(account);

        // Assert
        repoMock.Verify(x => x.CreateNewUser(account), Times.Once);
    }

    [Fact]
    public void RegisterUser_Should_Set_Username_To_Testuser_If_Username_Is_Empty()
    {
        // Arrange
        var account = new Account { Username = "", PhoneNumber = "12345644" };
        var repoMock = new Mock<IRepo>();
        var userService = new UserService(repoMock.Object);

        // Act
        userService.RegisterUser(account);

        // Assert
        Assert.Equal("Testuser", account.Username);
    }

    [Fact]
    public void GetUserByUsername_Should_Call_GetUserByUsername_Method_In_Repo()
    {
        // Arrange
        var username = "testuser";
        var repoMock = new Mock<IRepo>();
        var userService = new UserService(repoMock.Object);

        // Act
        userService.GetUserByUsername(username);

        // Assert
        repoMock.Verify(x => x.GetUserByUsername(username), Times.Once);
    }

    [Fact]
    public void GetAccountByUserID_Should_Call_GetAccountByUserID_Method_In_Repo()
    {
        // Arrange
        var userId = 1;
        var repoMock = new Mock<IRepo>();
        var userService = new UserService(repoMock.Object);

        // Act
        userService.GetAccountByUserID(userId);

        // Assert
        repoMock.Verify(x => x.GetAccountByUserID(userId), Times.Once);
    }
}
