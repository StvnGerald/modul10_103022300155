using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Modul10;
using System.Diagnostics.Tracing;

namespace Modul10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private static List<Movie> daftarFilm = new List<Movie>
        {
            new Movie
            (
                "The Shawshank Redemption",
                "Frank Darabant",
                ["Tim Robbins", "Morgan Freeman", "Bob Gurton", "William Sadler"],
                "Two imprisoned men band over a number of years, finding solace and eventual redemption through acts of common decency."
            ),

            new Movie
            (
                "The Godfather",
                "Francis Ford Coppola",
                ["Marlon Brando", "Al Pacino", "James Caan", "Diane Keaton"],
                "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son."

            )
        };


        // GET: api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return (daftarFilm);
        }

        // POST: api/mahasiswa
        [HttpPost]
        public ActionResult<IEnumerable<Movie>> Post([FromBody] Movie film)
        {
            if (film == null)
            {
                return BadRequest(new { message = "Data film tidak valid." });
            }

            daftarFilm.Add(film);
            return Ok(daftarFilm);
        }

        // GET: api/mahasiswa/{id}
        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            if (id < 0 || id >= daftarFilm.Count)
                return NotFound(new { message = "Film tidak ditemukan." });

            return Ok(daftarFilm.ElementAt(id));
        }

        // DELETE: api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Movie>> Delete(int id)
        {
            if (id < 0 || id >= daftarFilm.Count)
                return NotFound(new { message = "Film tidak ditemukan." });

            daftarFilm.RemoveAt(id);
            return Ok(daftarFilm);
        }
    }
}