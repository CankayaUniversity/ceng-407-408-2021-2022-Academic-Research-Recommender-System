using System;
using System.Collections.Generic;

#nullable disable

namespace Hypercorrect.Models
{
    public partial class CosineSimilarity
    {
        public int SimilarityNumber { get; set; }
        public string NewPaperId { get; set; }
        public string ComparePaperId { get; set; }
        public double? Similarity { get; set; }
    }
}
