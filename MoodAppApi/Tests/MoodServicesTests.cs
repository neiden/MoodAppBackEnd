using Xunit;
using Moq;
using Models;
using DataAccess;
using Services;
using System.Collections.Generic;

public class MoodServiceTests
{
    [Fact]
    public void GetMoodsByUserID_Should_Call_GetMoodsByUserID_Method_In_Repo()
    {
        // Arrange
        var userId = 1;
        var expectedMoods = new List<Mood>();
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.GetMoodsByUserID(userId)).Returns(expectedMoods);
        var moodService = new MoodService(repoMock.Object);

        // Act
        var result = moodService.GetMoodsByUserID(userId);

        // Assert
        repoMock.Verify(x => x.GetMoodsByUserID(userId), Times.Once);
        Assert.Equal(expectedMoods, result);
    }

    [Fact]
    public void CreateMood_Should_Call_CreateNewMood_Method_In_Repo()
    {
        // Arrange
        var mood = new Mood();
        var expectedMood = new Mood { MoodId = 1 };
        var repoMock = new Mock<IRepo>();
        repoMock.Setup(x => x.CreateNewMood(mood)).Returns(expectedMood);
        var moodService = new MoodService(repoMock.Object);

        // Act
        var result = moodService.CreateMood(mood);

        // Assert
        repoMock.Verify(x => x.CreateNewMood(mood), Times.Once);
        Assert.Equal(expectedMood, result);
    }
}
