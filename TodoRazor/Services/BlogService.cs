using Microsoft.EntityFrameworkCore;
using BlogRazor.Models;

namespace BlogRazor.Services
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllBlogs();
        Task<Blog?> GetBlog(int id);
        Task<Blog> AddBlog(Blog blog);
        Task<Blog> UpdateBlog(Blog blog);
        Task DeleteBlog(int id);

        Task AddCommentToBlog(int blogId, Comment comment);
        Boolean BlogExists(int id);
    }

    public class BlogService : IBlogService
    {
        private BlogRazor.Data.BlogRazorContext _context;

        public BlogService(BlogRazor.Data.BlogRazorContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogs()
        {
            return await _context.Blog.ToListAsync();
        }

        public async Task<Blog?> GetBlog(int id)
        {
            return await _context.Blog.Include(b => b.Comments).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> AddBlog(Blog blog)
        {
            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<Blog> UpdateBlog(Blog blog)
        {
            _context.Blog.Update(blog);
            await _context.SaveChangesAsync();
            return blog;
        }
  
        public async Task DeleteBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return;
            }
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public bool BlogExists(int id)
        {
            return (_context.Blog?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task AddCommentToBlog(int blogId, Comment comment)
        {
            var blog = await _context.Blog.Include(b => b.Comments).FirstOrDefaultAsync(b => b.Id == blogId);

            if (blog == null)
            {
                return;
            }

            if (blog.Comments == null)
            {
                blog.Comments = new List<Comment>();
            }


            blog.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
