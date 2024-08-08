﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SongsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Songs>>> Getsongs()
        {
          if (_context.songs == null)
          {
              return NotFound();
          }
            return await _context.songs.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
          if (_context.songs == null)
          {
              return NotFound();
          }
            var songs = await _context.songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (id != songs.SongsId)
            {
                return BadRequest();
            }

            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
          if (_context.songs == null)
          {
              return Problem("Entity set 'AppDbContext.songs'  is null.");
          }
            _context.songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongs", new { id = songs.SongsId }, songs);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongs(int id)
        {
            if (_context.songs == null)
            {
                return NotFound();
            }
            var songs = await _context.songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.songs.Remove(songs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongsExists(int id)
        {
            return (_context.songs?.Any(e => e.SongsId == id)).GetValueOrDefault();
        }
    }
}
