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
    }
}
