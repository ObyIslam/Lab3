using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Data;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab3.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Lab3.Data.Lab3Context _context;

        public IndexModel(Lab3.Data.Lab3Context context)
        {
            _context = context;
        }
        public IList<Book> Books { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookTitle { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Books
                                            orderby m.Title
                                            select m.Title;

            var movies = from m in _context.Books
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookTitle))
            {
                movies = movies.Where(x => x.Title == BookTitle);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Books = await movies.ToListAsync();
        }
    }
}
