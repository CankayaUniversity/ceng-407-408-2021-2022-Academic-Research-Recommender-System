using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class Task
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AreaType { get; set; }
    }
}
