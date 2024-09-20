using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet2.Data;
using pet2.Models;
using pet2.Models.Entities;
using pet2.Services;

namespace pet2.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        private readonly IUrlShortenerService _urlShortenerService;

        public AddController(IUrlShortenerService urlShortenerService, ApplicationDbContext dbContext)
        {
            this.dbcontext = dbContext;
            _urlShortenerService = urlShortenerService;
        }


        [HttpPost]
        [Route("Add/CreateNote")]
        public async Task<IActionResult> CreateNote([FromBody] AddNoteViewModel model)
        {
            if (string.IsNullOrEmpty(model.Text))
            {
                return BadRequest(new { error = "Text is missing." });
            }

            var note = new Note
            {
                Text = model.Text,
                CreationTime = DateTime.Now,
                Language = model.Language,
                ShortUrl = string.Empty
            };

            await dbcontext.AddAsync(note);
            await dbcontext.SaveChangesAsync();

            var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/{note.Id}";

            note.ShortUrl = await _urlShortenerService.ShortenUrlAsync(url);

            dbcontext.Notes.Update(note);
            await dbcontext.SaveChangesAsync();

            return Json(new { note });
        }


    }
}
