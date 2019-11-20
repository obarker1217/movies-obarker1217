using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        MovieDatabase movieDatabase = new MovieDatabase();

        public List<Movie> Movies;
        
        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> rating { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDb { get; set; }

        [BindProperty]
        public float? maxIMDb { get; set; }

        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {
            Movies = MovieDatabase.All;

            if(rating.Count != 0)
            {
                Movies = MovieDatabase.Filter(Movies, rating);
            }

            if(search != null)
            {
                Movies = MovieDatabase.Search(Movies, search);
            }

            if(minIMDb != null)
            {
                Movies = MovieDatabase.FilterByMinIMDb(Movies, (float)minIMDb);
            }
        }
    }
}
