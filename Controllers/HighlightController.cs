using Microsoft.AspNetCore.Mvc;
using pet2.Models;

namespace pet2.Controllers
{
    public class HighlightController : Controller
    {

        [HttpPost]
        [Route("Highlight/HighlightSyntax")]
        public IActionResult HighlightSyntax([FromBody] AddNoteViewModel model)
        {
            string language;

            switch (model.Language?.ToLower())
            {
                case "csharp":
                    language = "csharp"; break;
                case "python":
                    language = "python"; break;
                case "javascript":
                    language = "javascript"; break;
                case "kotlin":
                    language = "kotlin"; break;
                default:
                    language = "csharp"; break;
            }

            var highlightedCode = $"<pre><code class='language-{language}'>{model.Text}</code></pre>";

            return Json(new { highlightedCode });

        }
    }
}
