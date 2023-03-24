using System.Collections.Generic;
using DataAccess;
using Models;
using Moq;
using Xunit;

namespace Services.Tests
{
    public class FriendServiceTests
    {
        [Fact]
        public void GetFriendsByUserID_ShouldCallRepoMethod()
        {
            // Arrange
            int userId = 1;
            var expectedFriends = new List<Users>();
            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(repo => repo.GetFriendsByUserID(userId)).Returns(expectedFriends);
            var friendService = new FriendService(mockRepo.Object);

            // Act
            var actualFriends = friendService.GetFriendsByUserID(userId);

            // Assert
            mockRepo.Verify(repo => repo.GetFriendsByUserID(userId), Times.Once);
            Assert.Equal(expectedFriends, actualFriends);
        }

        [Fact]
        public void CreateNewFriend_ShouldCallRepoMethod()
        {
            // Arrange
            var friendToCreate = new Friend();
            var expectedCreatedFriend = new Friend();
            var mockRepo = new Mock<IRepo>();
            mockRepo.Setup(repo => repo.CreateNewFriend(friendToCreate)).Returns(expectedCreatedFriend);
            var friendService = new FriendService(mockRepo.Object);

            // Act
            var actualCreatedFriend = friendService.CreateNewFriend(friendToCreate);

            // Assert
            mockRepo.Verify(repo => repo.CreateNewFriend(friendToCreate), Times.Once);
            Assert.Equal(expectedCreatedFriend, actualCreatedFriend);
        }
    }
}
