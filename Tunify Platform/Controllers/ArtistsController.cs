using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models;
using Tunify_Platform.Repositories.Interfaces;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtists _artistsService;

        public ArtistsController(IArtists artistsService)
        {
            _artistsService = artistsService;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artists>>> GetArtists()
        {
            var artists = await _artistsService.GetAllArtists();
            if (artists == null)
            {
                return NotFound();
            }
            return Ok(artists);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artists>> GetArtists(int id)
        {
            var artist = await _artistsService.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist);
        }

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(int id, Artists artists)
        {
            if (id != artists.ArtistsId)
            {
                return BadRequest();
            }

            var updatedArtist = await _artistsService.UpdateArtist(id, artists);
            if (updatedArtist == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Artists
        [HttpPost]
        public async Task<ActionResult<Artists>> PostArtists(Artists artists)
        {
            var createdArtist = await _artistsService.AddArtist(artists);
            return CreatedAtAction("GetArtists", new { id = createdArtist.ArtistsId }, createdArtist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtists(int id)
        {
            var artist = await _artistsService.GetArtist(id);
            if (artist == null)
            {
                return NotFound();
            }

            await _artistsService.DeleteArtist(artist);

            return NoContent();
        }

        // Custom method: Add song to artist
        [HttpPost("{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            await _artistsService.AddSongToArtist(songId, artistId);
            return NoContent();
        }
    }
}
