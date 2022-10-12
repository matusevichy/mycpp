using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task2_Radency.BLL.DTO;
using Task2_Radency.DAL.Database;
using Task2_Radency.DAL.Models;

namespace Task2_Radency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class genres : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public genres(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/genrestest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDTO>>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            return _mapper.Map<List<GenreDTO>>(genres);
        }

        // GET: api/genrestest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> GetGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return _mapper.Map<GenreDTO>(genre);
        }

        // PUT: api/genrestest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // POST: api/genrestest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // DELETE: api/genrestest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> DeleteGenre(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
