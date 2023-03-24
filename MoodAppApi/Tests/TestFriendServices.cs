// using System.Collections.Generic;
// using Models;
// using DataAccess;
// using Xunit;

// namespace Tests
// {
//     public class FriendServiceTests
//     {
//         private readonly FriendService _friendService;

//         public FriendServiceTests()
//         {
//             // Use a mock repository for testing
//             _friendService = new FriendService(new MockRepo());
//         }

//         [Fact]
//         public void GetFriendsByUserID_ReturnsFriends()
//         {
//             // Arrange
//             int userId = 1;

//             // Act
//             List<User> friends = _friendService.GetFriendsByUserID(userId);

//             // Assert
//             Assert.NotNull(friends);
//             Assert.Equal(2, friends.Count);
//         }

//         [Fact]
//         public void CreateNewFriend_ReturnsNewFriend()
//         {
//             // Arrange
//             Friend newFriend = new Friend
//             {
//                 Id = 3,
//                 UserId = 1,
//                 FriendId = 2
//             };

//             // Act
//             Friend createdFriend = _friendService.CreateNewFriend(newFriend);

//             // Assert
//             Assert.NotNull(createdFriend);
//             Assert.Equal(newFriend.Id, createdFriend.Id);
//             Assert.Equal(newFriend.UserId, createdFriend.UserId);
//             Assert.Equal(newFriend.FriendId, createdFriend.FriendId);
//         }
//     }

//     // Mock repository for testing
//     public class MockRepo : IRepo
//     {
//         public List<User> GetFriendsByUserID(int U_Id)
//         {
//             return new List<User>
//             {
//                 new User { Id = 2, Name = "Friend 1" },
//                 new User { Id = 3, Name = "Friend 2" }
//             };
//         }

//         public Friend CreateNewFriend(Friend friend)
//         {
//             return friend;
//         }
//     }
// }
