using Xunit;
using Moq;
using Models;
using DataAccess;
using Services;
using System.Collections.Generic;

public class CommentServiceTests
{
    [Fact]
    public void GetCommentsByPostId_Should_Call_GetCommentsByPostID_Method_In_Repo()
    {
        // Arrange
        var postId = 1;
        var expectedComments = new List<Comment>();
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.GetCommentsByPostID(postId)).Returns(expectedComments);
        var commentService = new CommentService(repoMock.Object);

        // Act
        var result = commentService.GetCommentsByPostId(postId);

        // Assert
        repoMock.Verify(x => x.GetCommentsByPostID(postId), Times.Once);
        Assert.Equal(expectedComments, result);
    }

    [Fact]
    public void CreateComment_Should_Call_CreateNewComment_Method_In_Repo()
    {
        // Arrange
        var comment = new Comment();
        var expectedComment = new Comment { CommentId = 1 };
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.CreateNewComment(comment)).Returns(expectedComment);
        var commentService = new CommentService(repoMock.Object);

        // Act
        var result = commentService.CreateComment(comment);

        // Assert
        repoMock.Verify(x => x.CreateNewComment(comment), Times.Once);
        Assert.Equal(expectedComment, result);
    }
}
