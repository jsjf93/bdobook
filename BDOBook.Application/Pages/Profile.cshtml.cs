using BDOBook.Data;
using BDOBook.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace BDOBook.App.Pages
{
    public class ProfileModel : PageModel
    {
		private readonly Context _context;

		public ProfileModel(Context context)
        {
			_context = context;
		}

        public Profile Author { get; private set; }

        public IQueryable<Post> Posts { get; private set; }

        public void OnGet(int id)
        {
            this.Author = _context.Profile.Find(id);
            this.Posts = _context.Post
                .Where(post => post.AuthorId == this.Author.Id)
                .OrderByDescending(post => post.DateTimePosted);
        }
    }
}
