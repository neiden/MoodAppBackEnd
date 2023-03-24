using System.Collections.Generic;
using DataAccess;
using Models;
using Moq;
using Services;
using Xunit;

public class PlaylistServiceTests
{
    [Fact]
    public void GetPlaylistsByUserID_ShouldReturnList_WhenValidIdProvided()
    {
        // Arrange
        int userId = 1;
        var expectedPlaylists = new List<Playlist> { new Playlist { PlaylistId = 1, Name = "My Playlist" } };
        var mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.GetPlaylistsByUserID(userId)).Returns(expectedPlaylists);
        var service = new PlaylistService(mockRepo.Object);

        // Act
        var actualPlaylists = service.GetPlaylistsByUserID(userId);

        // Assert
        Assert.Equal(expectedPlaylists, actualPlaylists);
    }

    [Fact]
    public void CreatePlaylist_ShouldReturnCreatedPlaylist_WhenValidPlaylistProvided()
    {
        // Arrange
        var playlist = new Playlist { Name = "My Playlist" };
        var mockRepo = new Mock<IRepo>();
        mockRepo.Setup(repo => repo.CreateNewPlaylist(playlist)).Returns(playlist);
        var service = new PlaylistService(mockRepo.Object);

        // Act
        var createdPlaylist = service.CreatePlaylist(playlist);

        // Assert
        Assert.Equal(playlist, createdPlaylist);
    }
}
