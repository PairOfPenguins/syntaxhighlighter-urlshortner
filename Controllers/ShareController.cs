using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pet2.Data;
using pet2.Models;
using System.Text;

namespace pet2.Controllers
{
    public class ShareController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ShareController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> NoteShare(Guid Id)
        {

            var code = await dbContext.Notes.FirstOrDefaultAsync(x => x.Id == Id);

            if (code == null)
            {
                return NotFound();
            }

            return View(code);
        }
    }
}
