using Commentflix.Api.Database;
using Commentflix.Api.Database.Entities;
using Commentflix.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commentflix.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentflixController : ControllerBase
    {
        private DBConnection _context;
        private ProfanityFilter.ProfanityFilter _profanityFilter;
        public CommentflixController(DBConnection context)
        {
            _profanityFilter = new ProfanityFilter.ProfanityFilter();
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var comment = _context.Comments.Where(x => x.NetflixVideoId == id).ToList();
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CommentRequest request)
        {
            if (_profanityFilter.DetectAllProfanities(request.Content).Any() || _profanityFilter.DetectAllProfanities(request.Name).Any())
                return BadRequest("Profanity not allowed!");
            var comment = new Comment
            {
                Content = request.Content,
                Name = request.Name,
                NetflixVideoId = long.Parse(request.NetflixVideoId),
                TimeStamp = DateTime.Now
            };
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return Ok();
        }
    }
}
