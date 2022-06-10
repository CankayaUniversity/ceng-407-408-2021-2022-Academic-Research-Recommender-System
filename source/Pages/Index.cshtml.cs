using Hypercorrect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hypercorrect.Pages
{
    public class IndexModel : PageModel
    {
        private readonly hypercorrectContext _context;
        //public string CurrentFilter { get; set; }
        public IndexModel(hypercorrectContext context)
        {
            _context = context;
        }

        public IList<Papers7> PaperList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            PaperList = await _context.Papers7s.OrderByDescending(i => i.ViewCounter).Take(3).ToListAsync();
            return Page();
        }

        public void OnPost()
        {
            string searchString = Request.Form["SearchString"];
            string url = "./searching?SearchString=" + searchString;
            Response.Redirect(url);
        }

    }
}
