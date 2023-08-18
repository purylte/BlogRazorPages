using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogRazor.Models;
using BlogRazor.Services;
using System.Threading.Tasks;

namespace BlogRazor.Pages.Blogs
{
    public class CreateCommentModel : PageModel
    {
        private readonly IBlogService _blogService;

        public CreateCommentModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        public int BlogId { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Request.Query.TryGetValue("id", out var idValue) && int.TryParse(idValue, out int parsedId))
            {
                await _blogService.AddCommentToBlog(parsedId, Comment);
                return RedirectToPage("./Index");
            }

            else
            {
                return NotFound();
            }

        }
    }
}
