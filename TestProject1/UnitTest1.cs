using Moq;
using System.Collections.Generic;
using Tunify_Platform.Data;
namespace TestProject1
{
    public class UnitTest1
    {
        private readonly Mock<AppDbContext> _mockContext;
        private readonly PlaylistsServices _service;

        public UnitTest1()
        {
            _mockContext = new Mock<AppDbContext>();
            _service = new PlaylistsServices(_mockContext.Object);
        }

      
        [Fact]
        public async Task GetSongsForPlaylist_ReturnsCorrectSongs()
        {
            // Arrange
            var playlistId = 1;
            var songs = new List<Song>
        {
            new Song { SongId = 1, Title = "Song 1", ArtistId = 1 },
            new Song { SongId = 2, Title = "Song 2", ArtistId = 1 }
        };

            var playlistSongs = songs.Select(s => new PlaylistSongs
            {
                Song_Id = s.SongId,
                Playlist_Id = playlistId,
                Song = s,
            }).ToList();

            var playlists = new List<PlaylistSongs> { new PlaylistSongs { Playlist_Id = playlistId, Song_Id = 1 } }.AsQueryable();

            // Mock the DbSet of PlaylistSongs
            var mockPlaylistSongsSet = new Mock<DbSet<PlaylistSongs>>();
            mockPlaylistSongsSet.As<IQueryable<PlaylistSongs>>().Setup(m => m.Provider).Returns(playlists.Provider);
            mockPlaylistSongsSet.As<IQueryable<PlaylistSongs>>().Setup(m => m.Expression).Returns(playlists.Expression);
            mockPlaylistSongsSet.As<IQueryable<PlaylistSongs>>().Setup(m => m.ElementType).Returns(playlists.ElementType);
            mockPlaylistSongsSet.As<IQueryable<PlaylistSongs>>().Setup(m => m.GetEnumerator()).Returns(playlists.GetEnumerator());

            // Setup the DbContext to return the mock DbSet
            _mockContext.Setup(c => c.PlaylistSongs).Returns(mockPlaylistSongsSet.Object);

            // Act
            var result = await _service.GetSongsForPlaylist(playlistId);

            // Assert
            Assert.Equal(2, result.Count());
            Assert.Equal("Song 1", result.First().Title);
            Assert.Equal("Song 2", result.Last().Title);
        }
    }
}
