namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
        public int Song_Id { get; set; } //
        public Songs Songs { get; set; }
        public int Playlist_Id { get; set; }// 
        public Playlists Playlists { get; set; }
    }
}
