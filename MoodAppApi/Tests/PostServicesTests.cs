using Xunit;
using Moq;
using Models;
using DataAccess;
using Services;
using System.Collections.Generic;

public class PostServiceTests
{
    [Fact]
    public void GetPostsByUId_Should_Call_GetPostsByUserID_Method_In_Repo()
    {
        // Arrange
        var userId = 1;
        var expectedPosts = new List<Post>();
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.GetPostsByUserID(userId)).Returns(expectedPosts);
        var postService = new PostService(repoMock.Object);

        // Act
        var result = postService.GetPostsByUId(userId);

        // Assert
        repoMock.Verify(x => x.GetPostsByUserID(userId), Times.Once);
        Assert.Equal(expectedPosts, result);
    }

    [Fact]
    public void CreatePost_Should_Call_CreateNewPost_Method_In_Repo()
    {
        // Arrange
        var post = new Post();
        var expectedPost = new Post { PostId = 1 };
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.CreateNewPost(post)).Returns(expectedPost);
        var postService = new PostService(repoMock.Object);

        // Act
        var result = postService.CreatePost(post);

        // Assert
        repoMock.Verify(x => x.CreateNewPost(post), Times.Once);
        Assert.Equal(expectedPost, result);
    }
}
