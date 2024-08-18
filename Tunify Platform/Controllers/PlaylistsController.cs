using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly IPlaylists _playlistsService;

        public PlaylistsController(IPlaylists playlistsService)
        {
            _playlistsService = playlistsService;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlists>>> GetPlaylists()
        {
            var playlists = await _playlistsService.GetAllPlaylists();
            return Ok(playlists);
        }

        // GET: api/Playlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlists>> GetPlaylists(int id)
        {
            var playlist = await _playlistsService.GetPlaylist(id);
            if (playlist == null)
            {
                return NotFound();
            }
            return Ok(playlist);
        }

        // PUT: api/Playlists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylists(int id, Playlists playlists)
        {
            if (id != playlists.PlaylistsId)
            {
                return BadRequest();
            }

            var updatedPlaylist = await _playlistsService.UpdatePlaylist(id, playlists);
            if (updatedPlaylist == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Playlists
        [HttpPost]
        public async Task<ActionResult<Playlists>> PostPlaylists(Playlists playlists)
        {
            var createdPlaylist = await _playlistsService.AddPlaylist(playlists);
            return CreatedAtAction("GetPlaylists", new { id = createdPlaylist.PlaylistsId }, createdPlaylist);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylists(int id)
        {
            var playlist = await _playlistsService.GetPlaylist(id);
            if (playlist == null)
            {
                return NotFound();
            }

            await _playlistsService.DeletePlaylist(playlist);
            return NoContent();
        }

        // POST: api/Playlists/{playlistId}/songs/{songId}
        [HttpPost("{playlistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToPlaylist(int playlistId, int songId)
        {
            var result = await _playlistsService.AddSongsToPlaylist(songId, playlistId);
            return result;
        }

        private bool PlaylistsExists(int id)
        {
            return _playlistsService.GetPlaylist(id) != null;
        }
    }
}
