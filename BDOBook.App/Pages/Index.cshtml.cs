using BDOBook.App.DTOs;
using BDOBook.Data;
using BDOBook.Data.Entities;
using BDOBook.Services.Interfaces;
using BDOBook.Services.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDOBook.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Context _context;
        private readonly INewsService _newsService;

        private const int PageSize = 10;
        
        public IndexModel(Context context, INewsService newsService)
        {
            _context = context;
            _newsService = newsService;
        }

        public IQueryable<Post> Posts { get; private set; }

        public int Count { get; private set; }

        public int CurrentPage { get; private set; }

        public IEnumerable<NewsDto> News { get; private set; }

        public async Task OnGetAsync()
        {
            this.GetPostsData();
            await this.GetNews();
        }

        private void GetPostsData()
        {
            this.HttpContext.Request.Query.TryGetValue("pageNumber", out var page);

            this.CurrentPage = int.TryParse(page, out var parsedPage) ? parsedPage : 1;

            var baseQuery = _context.Post
                .Include(post => post.Author)
                .OrderByDescending(post => post.DateTimePosted);

            this.Posts = baseQuery
                .Skip((this.CurrentPage - 1) * PageSize)
                .Take(PageSize);
            this.Count = baseQuery.Count();
        }

        private async Task GetNews()
        {
            var response = await _newsService.GetMostRecent();

            this.News = response.Data
                .Select(article => new NewsDto
                {
                    Title = article.Title,
                    Description = article.Description,
                    Url = article.Url
                });
        }
    }
}
