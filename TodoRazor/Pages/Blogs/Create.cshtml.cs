using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogRazor.Data;
using BlogRazor.Models;
using BlogRazor.Services;

namespace BlogRazor.Pages.Blogs
{
    public class CreateModel : PageModel
    {
        private readonly IBlogService _blogService;

        public CreateModel(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _blogService.AddBlog(Blog);
            return RedirectToPage("./Index");
        }
    }
}
