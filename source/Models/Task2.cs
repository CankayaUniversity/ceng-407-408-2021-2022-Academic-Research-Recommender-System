using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class Task2
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string AreaType { get; set; }
        public int? Quantity { get; set; }
        public bool DoneQuantity { get; set; }
    }
}
