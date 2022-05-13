using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CENG408.Pages
{
    public class searchingModel : PageModel
    {
        private readonly ILogger<searchingModel> _logger;

        public searchingModel(ILogger<searchingModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
