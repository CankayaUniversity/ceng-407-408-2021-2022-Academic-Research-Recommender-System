using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class Paperrating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Paperid { get; set; }
    }
}
