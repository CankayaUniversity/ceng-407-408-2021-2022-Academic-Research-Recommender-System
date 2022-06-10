using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CENG408.Models;
using Hypercorrect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hypercorrect.Pages
{
    public class searchingModel : PageModel
    {
        private readonly hypercorrectContext _db;
        //public string searchString { get; set; }



        //ÇALIÞAN KOD

        /*public searchingModel(hypercorrectContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<Area2> PaperList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            PaperList = await _db.Area2s.ToListAsync();
            return Page();
        }*/




        //DATE ÝÇÝN
        /*public IEnumerable<Papers5> PaperList { get; set; }
        public void OnGet()
        {
            PaperList = _db.Papers5s.ToList();
        }
        public void OnPost(DateTime startDate, DateTime endDate)
        {
            PaperList = (from x in _db.Area2s where (x.PublishedDate <= startDate) && (x.PublishedDate >= endDate) select x).ToList();
        }*/


        private readonly IConfiguration Configuration;

        public searchingModel(hypercorrectContext db, IConfiguration configuration)
        {
            _db = db;
            Configuration = configuration;
        }

        [BindProperty, DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string enddate { get; set; }
        public string startdate { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Papers7> Students { get; set; }
        public IList<Papers7> ApplicationUserList { get; set; }
        public IList<Papers7> DateList { get; set; }

        public async System.Threading.Tasks.Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex, string startdate, string enddate)
        {
            searchString = Request.Query["SearchString"];
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;


            IQueryable<Papers7> studentsIQ = from s in _db.Papers7s
                                             where s.PublishedDate.HasValue
                                             orderby s.PublishedDate descending, s.PublishedDate
                                             select s;

            if (!String.IsNullOrEmpty(searchString) && (!String.IsNullOrEmpty(startdate) && !String.IsNullOrEmpty(enddate)))
            {
                startdate = "30/12/" + startdate;
                enddate = "30/12/" + enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(s => (s.Title.Contains(searchString)
                                       || s.TaskTypes.Contains(searchString)) && s.PublishedDate > test && s.PublishedDate < test2);

            }

            /*else if (!String.IsNullOrEmpty(searchString) || (!String.IsNullOrEmpty(startdate) || !String.IsNullOrEmpty(enddate)))
            {
                startdate = "30/12/" + startdate;
                enddate = "30/12/" + enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(s => (s.Title.Contains(searchString)
                                   || s.TaskTypes.Contains(searchString)) && s.PublishedDate > test && s.PublishedDate < test2);

            }*/
            else if (!String.IsNullOrEmpty(searchString) && (!String.IsNullOrEmpty(startdate)))
            {
                startdate = "30/12/" + startdate;
                enddate = "30/12/2022" + enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(s => (s.Title.Contains(searchString)
                               || s.TaskTypes.Contains(searchString)) && s.PublishedDate > test && s.PublishedDate < test2);

            }
            /*else if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(enddate)))
            {
                startdate = "30/12/" + startdate;
                enddate = "30/12/" + enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(s => (s.Title.Contains(searchString)
                               || s.TaskTypes.Contains(searchString)) && s.PublishedDate > test && s.PublishedDate < test2);

            }*/
            else if (!String.IsNullOrEmpty(searchString))
            {
                /*DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                test = DateTime.Now;
                test2 = DateTime.Now.AddDays(-60);*/
                studentsIQ = studentsIQ.Where(s => s.Title.Contains(searchString)
                                       || s.TaskTypes.Contains(searchString));
            }

            /*else if (!String.IsNullOrEmpty(startdate))
            {
                var res = _db.Papers7s.Select(w => w.PublishedDate.ToString());
                startdate = "30/12/" + startdate;
                enddate = "30/12/2022"+enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(x => x.PublishedDate >= test).Where(x => x.PublishedDate <= test2);
            }*/

            else if (!String.IsNullOrEmpty(startdate) && !String.IsNullOrEmpty(enddate))
            {
                var res = _db.Papers7s.Select(w => w.PublishedDate.ToString());
                startdate = "30/12/" + startdate;
                enddate = "30/12/" + enddate;
                DateTime test = Convert.ToDateTime(startdate);
                DateTime test2 = Convert.ToDateTime(enddate);
                studentsIQ = studentsIQ.Where(x => x.PublishedDate >= test).Where(x => x.PublishedDate <= test2);
            }
            /*switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.PublishedDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.PublishedDate);
                    break;
                /*default:
                    studentsIQ = studentsIQ.OrderBy(s => s.TaskTypes);
                    break;
            }*/

            var pageSize = Configuration.GetValue("PageSize", 4);
            Students = await PaginatedList<Papers7>.CreateAsync(
                studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);

            //DateList = await studentsIQ.AsNoTracking().ToListAsync();
            //ApplicationUserList = await studentsIQ.AsNoTracking().ToListAsync();
            await ListRatings();
        }

        public List<RatedPaper> UserRatingsList { get; set; }
        public async System.Threading.Tasks.Task ListRatings()
        {


            var AllRatings = await (from r in _db.Paperratings
                                    select r).ToListAsync();
            UserRatingsList = new();
            foreach (var item in Students)
            {
                //if user has roles (in our demo application only admins have a role), do not add this user to the list
                //find all ratings of the current user in foreach loop
                List<int> userrate = await (from x in _db.Paperratings where x.Paperid == item.Id select x.Rating).ToListAsync();
                var userating = new RatedPaper();
                if (userrate.Count >= 1)
                {
                    //calculate current user's average rating
                    double avg = CalculateRate.GetRating(userrate);
                    //avg = Math.Round(avg, 1); //round to 1 decimal place

                    //set values
                    userating.AvgRating = avg.ToString();
                    userating.Title = item.Title;
                    userating.Abstract = item.Abstract;
                    userating.PaperId = item.Id;
                    UserRatingsList.Add(userating);
                }
                else  //if user has no ratings do NOT calculate average
                {
                    //set values
                    userating.AvgRating = "0";
                    userating.Title = item.Title;
                    userating.Abstract = item.Abstract;
                    userating.PaperId = item.Id;
                    UserRatingsList.Add(userating);
                }
            }
        }
            public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //List users and their average ratings in each post
            await ListRatings();

            return Page();
        }
    }
}
