using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pet2.Data;
using pet2.Models;
using pet2.Models.Entities;

namespace pet2.Controllers
{
    public class AddController : Controller
    {
        private readonly ApplicationDbContext dbcontext;

        public AddController(ApplicationDbContext dbContext)
        {
            this.dbcontext = dbContext;
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
                Language = model.Language
            };

            await dbcontext.AddAsync(note);
            await dbcontext.SaveChangesAsync();

            return Json(new { note });
        }


    }
}
