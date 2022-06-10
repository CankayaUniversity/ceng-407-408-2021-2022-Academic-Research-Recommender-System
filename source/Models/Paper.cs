using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class Paper
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public DateTime? PublishedDate { get; set; }
        public string Authors { get; set; }
        public string PdfUrl { get; set; }
        public string GithubUrl { get; set; }
        public int? VoteCounter { get; set; }
        public int? VoteTotal { get; set; }
        public int? ViewCounter { get; set; }
        public string TaskTypes { get; set; }
    }
}
