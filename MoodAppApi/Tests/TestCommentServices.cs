// using System.Collections.Generic;
// using Models;
// using Services;
// // using DataAccess;

// using Xunit;

// namespace Tests
// {
//     public class TestCommentServices
//     {
//         private readonly CommentService _commentService;

//         public TestCommentServices()
//         {
//             // Use a mock repository for testing
//             _commentService = new CommentService(new MockRepo());
//         }

//         [Fact]
//         public void GetCommentsByPostId_ReturnsComments()
//         {
//             // Arrange
//             int postId = 1;

//             // Act
//             List<Comment> comments = _commentService.GetCommentsByPostId(postId);

//             // Assert
//             Assert.NotNull(comments);
//             Assert.Equal(2, comments.Count);
//         }

//         [Fact]
//         public void CreateComment_ReturnsNewComment()
//         {
//             // Arrange
//             Comment newComment = new Comment
//             {
//                 Id = 3,
//                 PostId = 1,
//                 Text = "New comment"
//             };

//             // Act
//             Comment createdComment = _commentService.CreateComment(newComment);

//             // Assert
//             Assert.NotNull(createdComment);
//             Assert.Equal(newComment.Id, createdComment.Id);
//             Assert.Equal(newComment.PostId, createdComment.PostId);
//             Assert.Equal(newComment.Text, createdComment.Text);
//         }
//     }

//     // Mock repository for testing
//     public class MockRepo : IRepo
//     {
//         public List<Comment> GetCommentsByPostID(int P_Id)
//         {
//             return new List<Comment>
//             {
//                 new Comment { Id = 1, PostId = 1, Text = "Comment 1" },
//                 new Comment { Id = 2, PostId = 1, Text = "Comment 2" }
//             };
//         }

//         public Comment CreateNewComment(Comment com)
//         {
//             return com;
//         }
//     }
// }
