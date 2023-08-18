using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogRazor.Data;
using BlogRazor.Models;
using BlogRazor.Services;

namespace BlogRazor.Pages.Blogs
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogService _blogService;

        public DeleteModel(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _blogService.GetBlog(id.Value);

            if (blog == null)
            {
                return NotFound();
            }
            else 
            {
                Blog = blog;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _blogService.DeleteBlog(id.Value);
            
            return RedirectToPage("./Index");
        }
    }
}
