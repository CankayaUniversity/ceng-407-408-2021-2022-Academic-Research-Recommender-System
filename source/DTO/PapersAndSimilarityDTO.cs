﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hypercorrect.DTO
{
    public class PapersAndSimilarityDTO
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
        public bool DoneTask { get; set; }
        public bool RsponseFourzrofour { get; set; }
        public bool DoneTasksStr { get; set; }
        public bool DoneVec { get; set; }
        public double? Similarity { get; set; }
    }
}
