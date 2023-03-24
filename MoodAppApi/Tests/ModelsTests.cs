using Models;
using System;

namespace Models.Tests
{
    public class AccountTests
    {
        [Fact]
        public void CanCreateAccount()
        {
            var account = new Account
            {
                Username = "testuser",
                Password = "testpassword",
                Email = "test@example.com",
                User_Id = 1,
                Firstname = "Test",
                Lastname = "User",
                PhoneNumber = "123-456-7890",
                Zipcode = "12345",
                Birthdate = new DateTime(2000, 1, 1)
            };

            Assert.NotNull(account);
            Assert.Equal("testuser", account.Username);
            Assert.Equal("testpassword", account.Password);
            Assert.Equal("test@example.com", account.Email);
            Assert.Equal(1, account.User_Id);
            Assert.Equal("Test", account.Firstname);
            Assert.Equal("User", account.Lastname);
            Assert.Equal("123-456-7890", account.PhoneNumber);
            Assert.Equal("12345", account.Zipcode);
            Assert.Equal(new DateTime(2000, 1, 1), account.Birthdate);
        }
    }

    public class CommentTests
    {
        [Fact]
        public void CanCreateComment()
        {
            var comment = new Comment
            {
                Content = "Test comment",
                CommentId = 1,
                PostId = 1,
                Likes = 0,
                CommentDate = new DateTime(2022, 1, 1)
            };

            Assert.NotNull(comment);
            Assert.Equal("Test comment", comment.Content);
            Assert.Equal(1, comment.CommentId);
            Assert.Equal(1, comment.PostId);
            Assert.Equal(0, comment.Likes);
            Assert.Equal(new DateTime(2022, 1, 1), comment.CommentDate);
        }
    }

    public class FriendTests
    {
        [Fact]
        public void CanCreateFriend()
        {
            var friend = new Friend
            {
                FriendId = 1,
                SourceId = 1,
                TargetId = 2
            };

            Assert.NotNull(friend);
            Assert.Equal(1, friend.FriendId);
            Assert.Equal(1, friend.SourceId);
            Assert.Equal(2, friend.TargetId);
        }
    }

    public class MoodTests
    {
        [Fact]
        public void CanCreateMood()
        {
            var mood = new Mood
            {
                MoodId = 1,
                UserId = 1,
                Date = new DateTime(2022, 1, 1),
                Category = "Happiness",
                Score = 0.8m
            };

            Assert.NotNull(mood);
            Assert.Equal(1, mood.MoodId);
            Assert.Equal(1, mood.UserId);
            Assert.Equal(new DateTime(2022, 1, 1), mood.Date);
            Assert.Equal("Happiness", mood.Category);
            Assert.Equal(0.8m, mood.Score);
        }
    }

    public class PlaylistTests
    {
        [Fact]
        public void CanCreatePlaylist()
        {
            var playlist = new Playlist
            {
                PlaylistId = 1,
                UserId = 1,
                Name = "Test Playlist",
                SpotifyLink = "https://open.spotify.com/playlist/123"
            };

            Assert.NotNull(playlist);
            Assert.Equal(1, playlist.PlaylistId);
            Assert.Equal(1, playlist.UserId);
            Assert.Equal("Test Playlist", playlist.Name);
            Assert.Equal("https://open.spotify.com/playlist/123", playlist.SpotifyLink);
        }

        public class PostTests
        {
            [Fact]
            public void CanCreatePost()
            {
                // Arrange
                var post = new Post
                {
                    Content = "Hello world",
                    PostId = 1,
                    Likes = 0,
                    PostDate = DateTime.Now,
                    UserID = 1
                };

                // Assert
                Assert.Equal("Hello world", post.Content);
                Assert.Equal(1, post.PostId);
                Assert.Equal(0, post.Likes);
                Assert.IsType<DateTime>(post.PostDate);
                Assert.Equal(1, post.UserID);
            }
        }

        public class UsersTests
        {
            [Fact]
            public void CanCreateUser()
            {
                // Arrange
                var user = new Users
                {
                    User_Id = 1,
                    F_Name = "John",
                    L_Name = "Doe",
                    Phone_Number = "123-456-7890",
                    Zipcode = "12345",
                    Birthdate = new DateTime(1990, 1, 1)
                };

                // Act

                // Assert
                Assert.Equal(1, user.User_Id);
                Assert.Equal("John", user.F_Name);
                Assert.Equal("Doe", user.L_Name);
                Assert.Equal("123-456-7890", user.Phone_Number);
                Assert.Equal("12345", user.Zipcode);
                Assert.Equal(new DateTime(1990, 1, 1), user.Birthdate);
            }
        }
    }
}
