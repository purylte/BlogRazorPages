using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogRazor.Data;
using BlogRazor.Models;
using BlogRazor.Services;

namespace BlogRazor.Pages.Blogs
{
    public class EditModel : PageModel
    {
        private readonly IBlogService _blogService;

        public EditModel(IBlogService blogService)
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

            var blog =  await _blogService.GetBlog(id.Value);
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _blogService.UpdateBlog(Blog);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_blogService.BlogExists(Blog.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

    
    }
}
