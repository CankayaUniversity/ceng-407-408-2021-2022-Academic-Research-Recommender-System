using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class User
    {
        public string UserName { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
        public int? PaperNumber { get; set; }
        public double? SimilarityRate { get; set; }
        public bool? Preference { get; set; }
    }
}
