using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class TitAbsVec
    {
        public string Id { get; set; }
        public double[] Titvec { get; set; }
        public double[] Absvec { get; set; }
        public bool PreviouslyAdded { get; set; }
    }
}
