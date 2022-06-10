using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Hypercorrect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hypercorrect.Pages
{
    public class AddRatingModel : PageModel
    {
        private readonly hypercorrectContext _context;
        //private readonly UserManager<User> _userManager;

        [BindProperty]
        public string Rate { get; set; }

        [BindProperty]
        public bool isAlreadyRated { get; set; }


        [BindProperty]
        public string RatedUSERID { get; set; }

        public AddRatingModel(hypercorrectContext context/* UserManager<User> userManager*/)
        {
            _context = context;
            //_userManager = userManager;
        }

        public void OnGet(string ratedUserID)
        {
            RatedUSERID = ratedUserID;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            var userRating = new Paperrating();



            userRating.Rating = Convert.ToInt32(Rate);
            userRating.Paperid = RatedUSERID;
            //userRating.whoRated = userId;

            await _context.Paperratings.AddAsync(userRating);
            await _context.SaveChangesAsync();

            return RedirectToPage("./AddRating");
        }
    }
}
