using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CENG408.Pages
{
    public class paperDetailModel : PageModel
    {
        private readonly ILogger<paperDetailModel> _logger;

        public paperDetailModel(ILogger<paperDetailModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
