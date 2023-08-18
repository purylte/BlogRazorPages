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
    public class IndexModel : PageModel
    {

        private readonly IBlogService _blogService;
        
        public IndexModel(IBlogService blogService)
        {
            this._blogService = blogService;
        }

        public IList<Blog> Blog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Blog = await _blogService.GetAllBlogs();
        }
    }
}
