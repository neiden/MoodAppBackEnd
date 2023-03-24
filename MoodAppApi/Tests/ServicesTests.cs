using DataAccess;
using Models;
using Moq;
using Xunit;

namespace Tests
{
    public class RepoTests
    {
        private readonly Mock<IRepo> _repoMock;

        public RepoTests()
        {
            // create a mock of the IRepo interface
            _repoMock = new Mock<IRepo>();
        }

        [Fact]
        public void Authenticate_Returns_Users_Object_With_Valid_Login_Info()
        {
            // Arrange
            string[] loginInfo = { "username", "password" };
            Users expectedUser = new Users { Username = "username", Password = "password" };
            _repoMock.Setup(repo => repo.Authenticate(loginInfo)).Returns(expectedUser);

            // Act
            Users result = _repoMock.Object.Authenticate(loginInfo);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUser.Username, result.Username);
            Assert.Equal(expectedUser.Password, result.Password);
        }

        public void GetAllUsers_Should_Return_ListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<Users>
            {
                new Users { User_Id = 1, F_Name = "John" },
                new Users { User_Id = 2, F_Name = "Jane" }
            };
            _repoMock.Setup(repo => repo.GetAllUsers()).Returns(expectedUsers);

            // Act
            var result = _repoMock.Object.GetAllUsers();

            // Assert
            Assert.Equal(expectedUsers, result);
        }

        public void GetUserByUsername_Should_Return_Login()
        {
            // Arrange
            var expectedLogin = new Login { Username = "john.doe", Pwd = "password" };
            _repoMock.Setup(repo => repo.GetUserByUsername(expectedLogin.Username)).Returns(expectedLogin);

            // Act
            var result = _repoMock.Object.GetUserByUsername(expectedLogin.Username);

            // Assert
            Assert.Equal(expectedLogin, result);
        }
    
        public void GetUserByUserID_Should_Return_User()
        {
            // Arrange
            var expectedUser = new Users { User_Id = 1, Username = "John" };
            _repoMock.Setup(repo => repo.GetUserByUserID(expectedUser.User_Id)).Returns(expectedUser);

            // Act
            var result = _repoMock.Object.GetUserByUserID(expectedUser.User_Id);

            // Assert
            Assert.Equal(expectedUser, result);
        }

    }
}
