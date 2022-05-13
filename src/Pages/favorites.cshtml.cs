using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CENG408.Pages
{
    public class favoritesModel : PageModel
    {
        private readonly ILogger<favoritesModel> _logger;

        public favoritesModel(ILogger<favoritesModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
